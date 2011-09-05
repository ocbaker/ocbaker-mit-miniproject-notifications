using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace Client.SrvCon
{
    /// <summary>
    /// Used to connect and communicate to the server
    /// </summary>
    public static class Connection
    {
        //TODO: Make Asynchronous

        private static TcpClient socServer;
        private static bool isAuthenticated = false;
        private static string Encryption;
        private static int userSecurity;
        private static string IPAddress = "127.0.0.1";
        private static int Port = 15065;

        public static void connectAsync()
        {
            socServer = new TcpClient();
            socServer.Connect(IPAddress, Port);
            byte[] buffer = new byte[10];
            int offset = 0;
            int size = 0;

            //socServer.
            //socServer.BeginReceive(buffer, offset, size, new AsyncCallback(OnReceive), socServer);

        }

//private void OnReceive(IAsyncResult ar)
//{
//Socket s = (Socket)ar.AsyncState;

//try
//{
//int nread = s.EndReceive(ar);
//} catch (Exception e) {
//// socket error if here
//}
//}

        public static String SendData(String rqJSON)
        {
            //Data is Sent by:
            //
            UTF8Encoding encoding = new UTF8Encoding();
            socServer.GetStream().Write(encoding.GetBytes(rqJSON), 0, encoding.GetBytes(rqJSON).Count());
            while (socServer.Available == 0)
            {
                
            }
            byte[] buffer = new byte[socServer.Available];
            socServer.GetStream().Read(buffer, 0, socServer.Available);
            return encoding.GetString(buffer);
        }
    }
}
