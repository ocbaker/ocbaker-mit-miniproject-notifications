using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Remoting.Metadata;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web.Mail;

namespace Notifications.Plugins.SMS.Server
{
    public class serverNotification
    {
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";

        private NetworkCredential _cred;
        private string ticket;
        public apiValidateLogin apiv;
        public string mail_response;

        /// <summary>
        /// Request a login from the SMSGlobal Soap API, get a ticket in return and put it into apiSendSMS class.
        /// </summary>
        /// <param name="_vlogin">ApiValidateLogin object</param>
        /// <param name="_sendSMS">apiSendSMS object</param> 

        public void requestLogin(apiValidateLogin vlogin)
        {
           
            // apiSendSMS apis = _sendSMS;

            string loginTicket = null;

            HttpWebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php") as HttpWebRequest;


            ///Get proxy information if needed.             

            //if (!request.Proxy.IsBypassed(request.RequestUri))
            if (isProxyActive(request.RequestUri, request) == true)
            {
                //a.Show("Proxy Authentication", "The server you are trying to access requires a username and password." + Environment.NewLine);
                //_cred = new NetworkCredential(a.UserData.Username, a.UserData.Password); //Data gotten from the server - Will have to make a request to the local database.
                request.Proxy.Credentials = _cred;
            }

            /// Add the needed headers for the SOAP API.
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("urn:MobileWorks#apiValidateLogin");

            ///Create an XML Document, with the needed data inside.
            var document = new XDocument(
                           new XDeclaration("1.0", String.Empty, String.Empty),
                           new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                               new XElement(soapenv + "Body",
                               new XElement("apiValidateLogin",
                               new XElement("user", ),
                               new XElement("password", )
                               ))));
            document.Declaration.Version = "1.0";

            ///Write the document to the requested place, in this case is the Soap API at SMSGLobal.com
            var writer = new StreamWriter(request.GetRequestStream());
            writer.WriteLine(document);
            writer.Close();

            ///Get the responce from the webserver after writing to the API.
            using (var rsp = request.GetResponse())
            {
                request.GetRequestStream().Close();
                if (rsp != null)
                {
                    using (var answerReader =
                                new StreamReader(rsp.GetResponseStream()))
                    {

                        ///Get the ticket which the server sent back using Regex to get the letter/digit mix of 32 characters.
                        var readString = answerReader.ReadToEnd();
                        Regex r = new Regex(@"(.*)ticket&gt;(.*)&lt;/ticket(.*)");
                        if (r.IsMatch(readString.ToString()))
                        {
                            Regex reg = new Regex(@"[A-Za-z0-9]{32}");
                            loginTicket = reg.Match(r.Match(readString.ToString()).ToString()).ToString();
                        }
                    }
                }
            }
            ticket = loginTicket;
        }
        private bool isProxyActive(Uri u, HttpWebRequest wr)
        {
            bool p = true;

            if (wr.Proxy.IsBypassed(u) == true)
            {
                p = false;
            }

            return p;
        }
        public void soapSMS(Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS apis)
        // Must accept Object from the request handler, (object requestedData), then apiSendSMS data = (apiSendSMS)requestedData
        {
            //apiSendSMS apis = vSendSms;
            //string msgid = null;

            WebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php");

            //if (_cred != null ) request.Proxy.Credentials = _cred;
            /// Needs a rework ^
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("urn:MobileWorks#apiSendSms");

            //Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();

            // if (_cred == null)
            //{
            //    a.Show();
            //    request.Proxy.Credentials = new NetworkCredential(a.UserData.Username, a.UserData.Password);
            //}

            var document = new XDocument(
                                           new XDeclaration("1.0", "utf-8", String.Empty),
                                           new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                                           new XElement(soapenv + "Body",
                                           new XElement("apiSendSms",
                                           new XElement("ticket", ticket),
                                           new XElement("sms_from", apis.sms_from),
                                           new XElement("sms_to", apis.sms_to),
                                           new XElement("msg_content", System.Web.HttpUtility.HtmlEncode(apis.msg_content)),
                                           new XElement("msg_type", apis.msg_type),
                                           new XElement("unicode", apis.unicode),
                                           new XElement("schedule", apis.schedule)
                                           ))));

            document.Declaration.Version = "1.0";

            var writer = new StreamWriter(request.GetRequestStream());
            writer.WriteLine(document);
            writer.Close();

           apis.response = getResponse(request);

        }
        public string getResponse(WebRequest request)
        {
            String responce = null;

            using (var rsp = request.GetResponse())
            {
                request.GetRequestStream().Close();
                if (rsp != null)
                {
                    using (var answerReader =
                                new StreamReader(rsp.GetResponseStream()))
                    {
                        var readString = answerReader.ReadToEnd();
                        Regex r = new Regex(@"((.*)msgid&gt;(.*)&lt;/msgid(.*))");
                        if (r.IsMatch(readString.ToString()))
                        {
                            Regex reg = new Regex(@"\d{16}");
                            responce = reg.Match(r.Match(readString.ToString()).ToString()).ToString();
                        }
                        else
                        {
                            Regex errCheck = new Regex(@"(.*)resp err=(.*)([0-9]{3})(.*)");
                            if (r.IsMatch(readString.ToString()))
                            {
                                responce = "Unknown error, please check over the details entered and try again";
                            }
                        }

                    }
                }
            }
            return responce;
        }
        public string getResponse(StreamReader sr)
        {
            String responce = null;
            using (sr)
            {
                var readstring = sr.ReadLine();

                Regex r = new Regex(@"((.*)queued message ID: (.*) SMSGlobalMsgID:(.*))");
                if (r.IsMatch(readstring.ToString()))
                {
                    Regex reg = new Regex(@"\d{16}");
                    responce = reg.Match(r.Match(readstring.ToString()).ToString()).ToString();
                }
                else
                {
                    Regex errCheck = new Regex(@"(.*)resp err=(.*)([0-9]{3})(.*)");
                    if (r.IsMatch(readstring.ToString()))
                    {
                        responce = "Unknown error, please check over the details entered and try again";
                    }
                }
            }
            return responce;
        }
        public void sendEmail(Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS vSendSms)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage("noreply-notifications-miniproject@itsasmurflife.com",
                vSendSms.email); // Here have the actual email address
           
            m.Subject = "Reminder: " + vSendSms.msg_content;
            m.Body = vSendSms.msg_content.Substring(0, 15) + "...";
            m.BodyEncoding = UTF8Encoding.UTF8;
            m.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;

            using (System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
            {
                s.EnableSsl = true;
                s.Timeout = 10000;
                s.UseDefaultCredentials = false;
                s.Credentials = new NetworkCredential("noreply-notifications-miniproject@itsasmurflife.com", "miniproject"); /// Get the username and password from server.core. / Utils
                s.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

                try
                {
                    s.Send(m);
                    mail_response = "The email was sent sucessfully";
                }
                catch (Exception e)
                {
                    mail_response = "The email was sent but failed";
                }
            }
        }
        public void HttpSMS(apiValidateLogin vlogin, Notifications.Plugins.SMS.Global.ComObjects.Requests.comdata_sendSMS vSendSms) // apiSendSMS vSendSms, apiValidateLogin vlogin
        {
            //apiValidateLogin apiv = vlogin;

            String encoded = System.Web.HttpUtility.HtmlEncode(vSendSms.msg_content);
            Uri smsUri = new Uri("http://www.smsglobal.com/http-api.php?action=sendsms&user=" + vlogin.APIusername + "&password=" + vlogin.APIpassword + "&from=" + vSendSms.sms_from + "&to=" + vSendSms.sms_to + "&text=" + encoded);


            /// Need to add proxy support when I have it working.

            try
            {
                WebClient wc = new WebClient();
                using (Stream s = wc.OpenRead(smsUri))
                {
                    using (StreamReader r = new StreamReader(s))
                    {
                        vSendSms.response = getResponse(r);
                    }
                }
            }
            catch (Exception e) { }


        }

    }
}
