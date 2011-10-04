using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using Notifications.Global.Core.Utils;
using Nito.Async.Sockets;
using Nito.Async;
using Notifications.Global.Core.Communication.Core.Requests;


namespace Notifications.Client.Executable
{
    public class NetworkComms
    {

        private static Dictionary<Type, Func<object, object>> DataHandlers;

        public NetworkComms(){
            DataHandlers = new Dictionary<Type, Func<object, object>>();
            addDataHandler((new comdata_rqFile()).GetType(),(Func<object,object>)testFunction);
        }

        public void addDataHandler(object key, Func<object, object> value){
            if (DataHandlers.ContainsKey(key.GetType()))
            {
                throw new Exception("Duplicate Keys Not Allowed");
            }else{
                DataHandlers.Add(key.GetType(), value);
            }
        }

        public void removeDataHandler(object key){
            if (DataHandlers.ContainsKey(key.GetType()))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                DataHandlers.Remove(key.GetType());
            }
        }

        /// <summary>
        /// Called by PacketArrived Asynchroniously to handle the message.
        /// Decreases Client Hang Times
        /// </summary>
        /// <param name="data"></param>
        private void HandleInboundData(object message){
            
            //string typen = message.GetType().FullName;

            //object compareValue = new comdata_rqFile();
            Type ty;
            if (DataHandlers.ContainsKey(message.GetType()))
            {
                object result = DataHandlers[message.GetType()](message);
            }
            string lol = "a";
        }

        public void connect(){
            try
            {
                // Read the IP address
                IPAddress serverIPAddress;
                IPAddress.TryParse("127.0.0.1", out serverIPAddress);

                // Read the port number
                int port = 55365;

                // Begin connecting to the remote IP
                ClientSocket = new SimpleClientTcpSocket();
                ClientSocket.ConnectCompleted += ClientSocket_ConnectCompleted;
                ClientSocket.PacketArrived += ClientSocket_PacketArrived;
                ClientSocket.WriteCompleted += (args) => ClientSocket_WriteCompleted(ClientSocket, args);
                ClientSocket.ShutdownCompleted += ClientSocket_ShutdownCompleted;
                ClientSocket.ConnectAsync(serverIPAddress, port);
                ClientSocketState = SocketState.Connecting;
            }
            catch (Exception ex)
            {
                ResetSocket();
            }
            finally
            {

            }
        }

        /// <summary>
        /// The connected state of the socket.
        /// </summary>
        private enum SocketState
        {
            /// <summary>
            /// The socket is closed; we are not trying to connect.
            /// </summary>
            Closed,

            /// <summary>
            /// The socket is attempting to connect.
            /// </summary>
            Connecting,

            /// <summary>
            /// The socket is connected.
            /// </summary>
            Connected,

            /// <summary>
            /// The socket is attempting to disconnect.
            /// </summary>
            Disconnecting
        }

        /// <summary>
        /// The socket that connects to the server. This is null if ClientSocketState is SocketState.Closed.
        /// </summary>
        private SimpleClientTcpSocket ClientSocket;

        /// <summary>
        /// The connected state of the socket. If this is SocketState.Closed, then ClientSocket is null.
        /// </summary>
        private SocketState ClientSocketState;

        /// <summary>
        /// Closes and clears the socket, without causing exceptions.
        /// </summary>
        private void ResetSocket()
        {
            // Close the socket
            ClientSocket.Close();
            ClientSocket = null;

            // Indicate there is no socket connection
            ClientSocketState = SocketState.Closed;
        }
        private void ClientSocket_ConnectCompleted(AsyncCompletedEventArgs e)
        {
            try
            {
                // Check for errors
                if (e.Error != null)
                {
                    ResetSocket();
                    
                    return;
                }

                // Adjust state
                ClientSocketState = SocketState.Connected;
            }
            catch (Exception ex)
            {
                ResetSocket();
                throw ex;
            }
            finally
            {
                //nothing to go here
            }
        }

        private void ClientSocket_WriteCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Check for errors
            if (e.Error != null)
            {
                // Note: WriteCompleted may be called as the result of a normal write or a keepalive packet.

                ResetSocket();

                // If you want to get fancy, you can tell if the error is the result of a write failure or a keepalive
                //  failure by testing e.UserState, which is set by normal writes.
                throw new Exception("Unknown Exception");
            }
            else
            {
                string description = (string)e.UserState;
            }
        }

        private void ClientSocket_ShutdownCompleted(AsyncCompletedEventArgs e)
        {
            // Check for errors
            if (e.Error != null)
            {
                ResetSocket();
                throw new Exception("Unknown Exception");
            }
            else
            {

                // Close the socket and set the socket state
                ResetSocket();
            }

        }
        
        private void ClientSocket_PacketArrived(AsyncResultEventArgs<byte[]> e)
        {
            try
            {
                // Check for errors
                if (e.Error != null)
                {
                    ResetSocket();
                }
                else if (e.Result == null)
                {

                    // Close the socket and handle the state transition to disconnected.
                    ResetSocket();
                }
                else
                {
                    // At this point, we know we actually got a message.

                    Sync.SynchronizeAction(() => HandleInboundData(Util.Deserialize(e.Result)));
                }
            }
            catch (Exception ex)
            {
                ResetSocket();
                throw new Exception("Unknown Exception");
            }
            finally
            {
                
            }
        }

        private object testFunction(object arg0)
        {
            comdata_rqFile data = (comdata_rqFile)arg0;
            System.IO.File.WriteAllBytes(data.FileName, data.File);
            return true;
        }
    }
}
