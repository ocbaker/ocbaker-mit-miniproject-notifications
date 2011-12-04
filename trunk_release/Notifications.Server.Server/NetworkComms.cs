using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nito.Async.Sockets;
using Nito.Async;
using Notifications.Global.Core.Utils;
using Notifications.Global.Core.Communication.Base.BaseObjects;

namespace Notifications.Server.Server
{
    public class NetworkComms
    {

        
        internal static SimpleServerTcpSocket ListeningSocket;
        private static Dictionary<Type, Func<object, object>> DataHandlers;
        /// <summary>
        /// A mapping of sockets (with established connections) to their state.
        /// </summary>
        private static Dictionary<SimpleServerChildTcpSocket, Interop.SocketInformation> ChildSockets = new Dictionary<SimpleServerChildTcpSocket, Interop.SocketInformation>();
        private static Dictionary<Guid, SimpleServerChildTcpSocket> RecivedMessages = new Dictionary<System.Guid, SimpleServerChildTcpSocket>();
        //private static Dictionary<SimpleServerChildTcpSocket,

        public NetworkComms(){
            SynchronizationManager.letMeHandleIt();
            DataHandlers = new Dictionary<Type, Func<object, object>>();
            //DataHandler((new comdata_rqFile.bject>)testFunction);
            
        }

        /// <summary>
        /// The state of a child socket connection.
        /// </summary>
        private enum ChildSocketState
        {
            /// <summary>
            /// The child socket has an established connection.
            /// </summary>
            Connected,

            /// <summary>
            /// The child socket is disconnecting.
            /// </summary>
            Disconnecting
        }
        /// <summary>
        /// Closes and clears a child socket (established connection), without causing exceptions.
        /// </summary>
        /// <param name="childSocket">The child socket to close. May be null.</param>
        private void ResetChildSocket(SimpleServerChildTcpSocket childSocket)
        {
            // Close the child socket if possible
            Console.WriteLine("{" + ChildSockets[childSocket] + "} - Connection Closed");
            if (childSocket != null)
                childSocket.Close();

            // Remove it from the list of child sockets
            ChildSockets.Remove(childSocket);
        }

        
        public void startListening()
        {
            // Read the port number
            //string value = Interop.PropertiesManager.getSetting("network","port");
            string value = Interop.PropertiesManager.InIFile["network"]["port"];
            int port = int.Parse(value);

            //try
            //{
                // Define the socket, bind to the port, and start accepting connections
                ListeningSocket = new SimpleServerTcpSocket();
                ListeningSocket.ConnectionArrived += ListeningSocket_ConnectionArrived;
                ListeningSocket.Listen(port);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        private void ListeningSocket_ConnectionArrived(AsyncResultEventArgs<SimpleServerChildTcpSocket> e)
        {
            // Check for errors
            if (e.Error != null)
            {
                //throw new Exception("Unknown Exception");
            }

            SimpleServerChildTcpSocket socket = e.Result;

            try
            {
                // Save the new child socket connection
                Guid cliGuid = Guid.NewGuid();
                ChildSockets.Add(socket, new Interop.SocketInformation(cliGuid));
                Console.WriteLine("{" + cliGuid + "} - Connection Recived");
                socket.PacketArrived += (args) => ChildSocket_PacketArrived(socket, args);
                socket.WriteCompleted += (args) => ChildSocket_WriteCompleted(socket, args);
                socket.ShutdownCompleted += (args) => ChildSocket_ShutdownCompleted(socket, args);
                //Console.WriteLine("Client Connected");
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                ResetChildSocket(socket);
#endif
                //throw ex;
            }
            finally
            {
                //nothing to go here
            }
        }

        [Interop.StaticEventMethod("Server.Network.LoggedIn")]
        public static void UserLoggedIn(Guid messageID, Global.Core.Communication.Core.Data.UserInformation userInformation)
        {
            ChildSockets[RecivedMessages[messageID]].information.Add(userInformation);
        }

        private void ChildSocket_PacketArrived(SimpleServerChildTcpSocket socket, AsyncResultEventArgs<byte[]> e)
        {
            try
            {
                // Check for errors
                if (e.Error != null)
                {
                    ResetChildSocket(socket);
                    //throw new Exception("Unknown Exception");
                }
                else if (e.Result == null)
                {

                    // Close the socket and remove it from the list
                    ResetChildSocket(socket);
                    //throw new Exception("Unknown Exception");
                }
                else
                {
                    // At this point, we know we actually got a message.
                    
                    // Deserialize the message
                    object message = null;
                    try
                    {
                        message = Util.Deserialize(e.Result);
                        if (message.GetType().BaseType == typeof(aBaseRequest))
                        {
                            try
                            {
                                ((aBaseRequest)message)._userInformation = ChildSockets[socket].information.OfType<Global.Core.Communication.Core.Data.UserInformation>().First();
                            }
                            catch (Exception)
                            {
                                ((aBaseRequest)message)._userInformation = null;
                            }
                            Console.WriteLine("{" + ChildSockets[socket] + "} {" + ((aBaseRequest)message).messageID + "} - Message Recived");
                            RecivedMessages.Add(((aBaseRequest)message).messageID,socket);
                            HandleInboundData(message);
                        }
                        else
                        {
                            Console.WriteLine("{" + ChildSockets[socket] + "} - Message Recived (BAD_FORMAT)");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    //Action<object> act = HandleInboundData;
                    //ThreadPool.QueueUserWorkItem
                    //Nito.Async.ActionDispatcher.Current.QueueAction(act(message));
                    // Handle the message
                    //Messages.StringMessage stringMessage = message as Messages.StringMessage;
                    //if (stringMessage != null)
                    //{
                    //    textBoxLog.AppendText("Socket read got a string message from " + socket.RemoteEndPoint.ToString() + ": " + stringMessage.Message + Environment.NewLine);
                    //    return;
                    //}

                    //Messages.ComplexMessage complexMessage = message as Messages.ComplexMessage;
                    //if (complexMessage != null)
                    //{
                    //    textBoxLog.AppendText("Socket read got a complex message from " + socket.RemoteEndPoint.ToString() + ": (UniqueID = " + complexMessage.UniqueID.ToString() +
                    //        ", Time = " + complexMessage.Time.ToString() + ", Message = " + complexMessage.Message + ")" + Environment.NewLine);
                    //    return;
                    //}

                    //textBoxLog.AppendText("Socket read got an unknown message from " + socket.RemoteEndPoint.ToString() + " of type " + message.GetType().Name + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                ResetChildSocket(socket);
#endif
                //throw ex;
            }
            finally
            {
                //nothing to go here
            }
        }
        private void ChildSocket_ShutdownCompleted(object sender, AsyncCompletedEventArgs e)
        {
            SimpleServerChildTcpSocket socket = (SimpleServerChildTcpSocket)sender;

            // Check for errors
            if (e.Error != null)
            {
                ResetChildSocket(socket);
                //throw new Exception("Unknown Exception");
            }
            else
            {
                // Close the socket and remove it from the list
                ResetChildSocket(socket);
            }
            Console.WriteLine("{" + ChildSockets[socket] + "} - Client Disconnected");
        }
        private void ChildSocket_WriteCompleted(SimpleServerChildTcpSocket socket, AsyncCompletedEventArgs e)
        {
            //// Check for errors
            //if (e.Error != null)
            //{
            //    // Note: WriteCompleted may be called as the result of a normal write (SocketPacketizer.WritePacketAsync),
            //    //  or as the result of a call to SocketPacketizer.WriteKeepaliveAsync. However, WriteKeepaliveAsync
            //    //  will never invoke WriteCompleted if the write was successful; it will only invoke WriteCompleted if
            //    //  the keepalive packet failed (indicating a loss of connection).

            //    // If you want to get fancy, you can tell if the error is the result of a write failure or a keepalive
            //    //  failure by testing e.UserState, which is set by normal writes.
            //    if (e.UserState is string)
            //        textBoxLog.AppendText("Socket error during Write to " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message + Environment.NewLine);
            //    else
            //        textBoxLog.AppendText("Socket error detected by keepalive to " + socket.RemoteEndPoint.ToString() + ": [" + e.Error.GetType().Name + "] " + e.Error.Message + Environment.NewLine);

            //    ResetChildSocket(socket);
            //}
            //else
            //{
            //    string description = (string)e.UserState;
            //    textBoxLog.AppendText("Socket write completed to " + socket.RemoteEndPoint.ToString() + " for message " + description + Environment.NewLine);
            //}
            //Console.WriteLine("Message Sent");
            //RefreshDisplay();
            if (e.Error != null)
            {
                Console.WriteLine("{" + ChildSockets[RecivedMessages[((aBaseResponse)e.UserState).responseID]] + "} {" + ((aBaseResponse)e.UserState).responseID + "} - Message Send FAILED");
            }
            else
            {
                Console.WriteLine("{" + ChildSockets[RecivedMessages[((aBaseResponse)e.UserState).responseID]] + "} {" + ((aBaseResponse)e.UserState).responseID + "} - Message Sent");
            }
        }

        public static void writeMessage(object msg){
            RecivedMessages[((aBaseResponse)msg).responseID].WriteAsync(Util.Serialize(msg), msg);
            //ChildSockets.First().Key.WriteAsync(Util.Serialize(msg));
        }

        

        public static void addDataHandler(object key, Func<object, object> value)
        {
            Type tKey;
            if (key.GetType().BaseType != typeof(Notifications.Global.Core.Communication.Base.BaseObjects.aBaseRequest))
            {
                tKey = (Type)key;
            }
            else
            {
                tKey = key.GetType();
            }
            if (DataHandlers.ContainsKey(tKey))
            {
                throw new Exception("Duplicate Keys Not Allowed");
            }
            else
            {
                DataHandlers.Add(tKey, value);
            }
        }

        public static void removeDataHandler(object key)
        {
            Type tKey;
            if (key.GetType().BaseType == typeof(Type))
            {
                tKey = (Type)key;
            }
            else
            {
                tKey = key.GetType();
            }
            if (DataHandlers.ContainsKey(tKey))
            {
                throw new KeyNotFoundException();
            }
            else
            {
                DataHandlers.Remove(tKey);
            }
        }

        /// <summary>
        /// Called by PacketArrived Asynchroniously to handle the message.
        /// Decreases Client Hang Times
        /// </summary>
        /// <param name="data"></param>
        private void HandleInboundData(object message)
        {

            
            if (DataHandlers.ContainsKey(message.GetType()))
            {
                object result = null;
                try
                {
                   result = DataHandlers[message.GetType()](message);


                }
                catch (Exception e)
                {
                    Console.WriteLine("Plugin Thrown Exception! Client ID: {" + ((Global.Core.Communication.Base.BaseObjects.aBaseRequest)message).messageID + "}");
                }
                if (result.GetType().BaseType != typeof(Global.Core.Communication.Base.BaseObjects.aBaseResponse))
                {
                    //We will not be returning data
                }else{
                    writeMessage(result);
                }
            }
            else
            {
                throw new KeyNotFoundException("This Data Object is not handled by the executable");
            }
            string lol = "a";
        }


        public void addDefaultHandlers()
        {
            (new Core.Core.RequestHandlers.Login()).setupHandlers();
        }
    }
}
