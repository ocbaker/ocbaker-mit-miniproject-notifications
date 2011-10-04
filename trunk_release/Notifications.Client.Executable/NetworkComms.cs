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

                    // Deserialize the message
                    object message = Util.Deserialize(e.Result);
                    string typen = message.GetType().FullName;

                    object compareValue = new comdata_rqLogin();

                    if (message.GetType() == compareValue.GetType())
                    {
                        testFunction((comdata_rqLogin)message);
                    }
                    string lol = "a";
                    //// Handle the message
                    //Messages.StringMessage stringMessage = message as Messages.StringMessage;
                    //if (stringMessage != null)
                    //{
                    //    textBoxLog.AppendText("Socket read got a string message: " + stringMessage.Message + Environment.NewLine);
                    //    return;
                    //}

                    //Messages.ComplexMessage complexMessage = message as Messages.ComplexMessage;
                    //if (complexMessage != null)
                    //{
                    //    textBoxLog.AppendText("Socket read got a complex message: (UniqueID = " + complexMessage.UniqueID.ToString() +
                    //        ", Time = " + complexMessage.Time.ToString() + ", Message = " + complexMessage.Message + ")" + Environment.NewLine);
                    //    return;
                    //}

                    //textBoxLog.AppendText("Socket read got an unknown message of type " + message.GetType().Name + Environment.NewLine);
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

        private void testFunction(comdata_rqLogin data){
            string a = "lol";
        }
    }
}
