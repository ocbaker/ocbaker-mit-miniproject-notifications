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

namespace SMS_API
{
    /// <summary>
    /// User: lolhi
    /// Password: 81953801
    ///  SEND TO http://www.smsglobal.com/mobileworks/soapserver.php
    ///  HTTP POST;  SOAP XML Formatted
    ///  http://msdn.microsoft.com/en-us/library/debx8sh9.aspx#Y100 - WebRequest Class
    ///  
    /// http://stackoverflow.com/questions/1799005/soap-object-over-http-post-in-c-net
    /// http post data soap c#
    /// </summary>
    public class notifications : iAPI
    {
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        public void requestLogin(apiValidateLogin vlogin) {
            apiValidateLogin apiv = vlogin;

            HttpWebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php") as HttpWebRequest;

            Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();

            if (!request.Proxy.IsBypassed(request.RequestUri))
            {
                a.Show();
                request.Proxy.Credentials = new NetworkCredential(a.UserData.Username, a.UserData.Password);
            }

            request.Method = "POST";
            request.ContentType = "text/xml";
            request.UseDefaultCredentials = true;
            request.Headers.Add("urn:MobileWorks#apiValidateLogin");


            var document = new XDocument(
                           new XDeclaration("1.0", String.Empty, String.Empty),
                           new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                               new XElement(soapenv + "Body"),
                               new XElement("apiValidateLogin",
                               new XElement("user", apiv.APIusername),
                               new XElement("password", apiv.APIpassword)

                               )));

            //var document = XDocument.Load("x.xml");

            var writer = new StreamWriter(request.GetRequestStream());
            writer.WriteLine(document.ToString());
            writer.Close();

            using (var rsp = request.GetResponse())
            {
               request.GetRequestStream().Close();
                if (rsp != null)
                {
                    using (var answerReader =
                                new StreamReader(rsp.GetResponseStream()))
                    {
                        var readString = answerReader.ReadToEnd();
                        //do whatever you want with it
                        Console.WriteLine(readString.ToString());
                        Console.ReadLine();
                    }
                }
            }


          
           

        }

        public void soapSMS()
        {
            WebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("urn:MobileWorks#apiSendSms");

            Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();
            if (!request.Proxy.IsBypassed(request.RequestUri))
            {
                a.Show();
                request.Proxy.Credentials = new NetworkCredential(a.UserData.Username, a.UserData.Password);
            }

            var document = new XDocument(
                                       new XDeclaration("1.0", "utf-8", String.Empty),
                                       new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                                           new XElement(soapenv + "Body"),
                                           new XElement("apiSendSms",
                                           new XElement("ticket", "t"),
                                           new XElement("sms_from", "s"),
                                           new XElement("sms_to", "st"),
                                           new XElement("msg_content", "Hello World"),
                                           new XElement("msg_type", "text"),
                                           new XElement("unicode", "0"),
                                           new XElement("schedule", "")

                                           )));


        }

        public void HttpSMS(apiSendSms vSendSms, apiValidateLogin vlogin)
        {
            apiSendSms apis = vSendSms;
            apiValidateLogin apiv = vlogin;

            String encoded = System.Web.HttpUtility.HtmlEncode(vSendSms.msg_content);

            WebRequest request = WebRequest.Create("http://www.smsglobal.com/httpapi.php?action=sendsms&user=" + vlogin.APIusername + "&password=" + vlogin.APIpassword + "&from=" + vSendSms.sms_from + "&to=" + vSendSms.sms_to + "&text=" + encoded);
            //WebRequest request = WebRequest.Create("http://google.co.nz");
            request.Method = "POST";
            Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();
            if (!request.Proxy.IsBypassed(request.RequestUri))
            {
                a.Show();
                request.Proxy.Credentials = new NetworkCredential(a.UserData.Username, a.UserData.Password);
            }

           

        }


    }
}
