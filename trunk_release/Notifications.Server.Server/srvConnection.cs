using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.ComponentModel;
using Notifications.Global.Core.Communication.Base;
using Notifications.Global.Core.Communication.Base.BaseObjects;
using Notifications.Global.Core.Communication.Core.Requests;
using Notifications.Global.Core.Communication.Core.Responses;

namespace ServerCode
{
    public class srvConnection
    {

        private TcpListener tcpListen;
        private List<TcpClient> tcpClients;

        /// <summary>
        /// Here we are setting up connection services
        /// </summary>
        public srvConnection()
        {
            // Initializing Stuff
            tcpListen = new TcpListener(15065);
            tcpClients = new List<TcpClient>();
            tcpListen.Start();

            // Begin Accepting Clients here, all future connection listeners will be handled by DoAcceptCallback()
            tcpListen.BeginAcceptTcpClient(new AsyncCallback(DoAcceptSocketCallback), tcpListen);

            //Return Control to setup here
        }

        public void DoAcceptSocketCallback(IAsyncResult ar)
        {
            //Get Client
            TcpListener listener = (TcpListener)ar.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(ar);
            Console.WriteLine("Accepted Client");
            //Set up client Handlers


            //Search for next TcpClient
            tcpListen.BeginAcceptTcpClient(new AsyncCallback(DoAcceptSocketCallback), tcpListen);
            //Handle Stream FOREVER
            while (client.Connected)
            {
                //If there is an object to be read!
                if (client.Available > 0)
                {
                    Console.WriteLine("Message Received");
                    //Read the Object
                    //long position = client.GetStream().Position;
                    Byte[] buffer = new Byte[client.Available];
                    StringBuilder JSONMSG = new StringBuilder();
                    int a = client.GetStream().Read(buffer, 0, client.Available);
                    String JSON = Encoding.ASCII.GetString(buffer);
                    RequestObject<comdata_Blank> request_blank = ObjectConverter.ToObject<RequestObject<comdata_Blank>>(JSON);
                    //RequestObject<comdata_Blank> request_blank = ObjectConverter.ToObject < RequestObject<comdata_Blank>>(client.GetStream());
                    Console.WriteLine("Message Action: " + request_blank.action);
                    //client.GetStream().Position = position;
                    //Handle the Object
                    
                    String lol = "lol";
                    switch (request_blank.action)
                    {
                        case "login":
                            RequestObject<comdata_rqLogin> request_login = ObjectConverter.ToObject<RequestObject<comdata_rqLogin>>(JSON);
                            Console.WriteLine("Username: "+request_login.data.username);
                            Console.WriteLine("Password: "+request_login.data.password);
                            ResponseObject<comdata_rtLogin> response_login = new ResponseObject<comdata_rtLogin>();
                            response_login.data = new comdata_rtLogin(new comdata_rqLogin());
                            response_login.repsoneid = request_login.responseid;
                            response_login.error_code = 0;
                        switch (request_login.data.username){
                                case "ocbaker":
                                    if (request_login.data.password == "cool")
                                    {
                                        response_login.data.loginSuccessful = true;
                                    }else{
                                        response_login.data.loginSuccessful = false;
                                    }
                                    break;
                                case "smurfd":
                                    if (request_login.data.password == "gayfag")
                                    {
                                        response_login.data.loginSuccessful = true;
                                    }
                                    else
                                    {
                                        response_login.data.loginSuccessful = false;
                                    }
                                    break;

                                default:
                                    response_login.data.loginSuccessful = false;
                                    break;
                            }
                        SendData(client, ObjectConverter.ToJSON<ResponseObject<comdata_rtLogin>>(response_login));
                            break;
                        case "logout":

                            break;
                        case "create_notification":

                            break;
                        case "create_user":

                            break;
                        case "edit_notification":

                            break;
                        case "edit_user":

                            break;
                        default:
                            break;
                    }

                    //Return a Response


                }


            }
            
        }
        public static void SendData(TcpClient client,String JSON)
        {
            //Data is Sent by:
            //
            UTF8Encoding encoding = new UTF8Encoding();
            client.GetStream().Write(encoding.GetBytes(JSON), 0, encoding.GetBytes(JSON).Count());

        }
    }
}
