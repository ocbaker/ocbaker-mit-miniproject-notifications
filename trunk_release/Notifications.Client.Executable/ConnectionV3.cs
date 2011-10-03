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

namespace Notifications.Client.Executable
{
        public class ConnectionV3
        {


            internal static SimpleServerTcpSocket ListeningSocket;
            /// <summary>
            /// A mapping of sockets (with established connections) to their state.
            /// </summary>
            private Dictionary<SimpleServerChildTcpSocket, ChildSocketState> ChildSockets = new Dictionary<SimpleServerChildTcpSocket, ChildSocketState>();

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
                if (childSocket != null)
                    childSocket.Close();

                // Remove it from the list of child sockets
                ChildSockets.Remove(childSocket);
            }


            public void startListening()
            {
                // Read the port number
                int port = 55365;

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
                    throw new Exception("Unknown Exception");
                }

                SimpleServerChildTcpSocket socket = e.Result;

                try
                {
                    // Save the new child socket connection
                    ChildSockets.Add(socket, ChildSocketState.Connected);

                    socket.PacketArrived += (args) => ChildSocket_PacketArrived(socket, args);
                    socket.WriteCompleted += (args) => ChildSocket_WriteCompleted(socket, args);
                    socket.ShutdownCompleted += (args) => ChildSocket_ShutdownCompleted(socket, args);

                }
                catch (Exception ex)
                {
                    ResetChildSocket(socket);
                    throw ex;
                }
                finally
                {
                    //nothing to go here
                }
            }
            private void ChildSocket_PacketArrived(SimpleServerChildTcpSocket socket, AsyncResultEventArgs<byte[]> e)
            {
                try
                {
                    // Check for errors
                    if (e.Error != null)
                    {
                        ResetChildSocket(socket);
                        throw new Exception("Unknown Exception");
                    }
                    else if (e.Result == null)
                    {

                        // Close the socket and remove it from the list
                        ResetChildSocket(socket);
                        throw new Exception("Unknown Exception");
                    }
                    else
                    {
                        // At this point, we know we actually got a message.

                        // Deserialize the message
                        object message = Util.Deserialize(e.Result);

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
                    ResetChildSocket(socket);
                    throw ex;
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
                    throw new Exception("Unknown Exception");
                }
                else
                {
                    // Close the socket and remove it from the list
                    ResetChildSocket(socket);
                }
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

                //RefreshDisplay();
            }
        }
    }

