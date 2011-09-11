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
        private NetworkCredential _cred;
        XNamespace soapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        public string requestLogin(apiValidateLogin vlogin)  {
            apiValidateLogin apiv = vlogin;
            string loginTicket = null;

            HttpWebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php") as HttpWebRequest;
            Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();

            if (!request.Proxy.IsBypassed(request.RequestUri))
            {
                a.Show();
                _cred = new NetworkCredential(a.UserData.Username, a.UserData.Password);
                request.Proxy.Credentials = _cred;
            }

            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("urn:MobileWorks#apiValidateLogin");

            var document = new XDocument(
                           new XDeclaration("1.0", String.Empty, String.Empty),
                           new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                               new XElement(soapenv + "Body",
                               new XElement("apiValidateLogin",
                               new XElement("user", apiv.APIusername),
                               new XElement("password", apiv.APIpassword)
                               ))));

           if (File.Exists(Environment.CurrentDirectory + @"\apiLogin.xml")) File.Delete(Environment.CurrentDirectory + @"\apiLogin.xml");
           File.WriteAllText(Environment.CurrentDirectory + @"\apiLogin.xml", "<?xml version='1.0' ?>" + Environment.NewLine);
           File.AppendAllText(Environment.CurrentDirectory + @"\apiLogin.xml", document.ToString());
           document = XDocument.Load(Environment.CurrentDirectory + @"\apiLogin.xml");

           var writer = new StreamWriter(request.GetRequestStream());
           writer.WriteLine(document);
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
                        Regex r = new Regex(@"(.*)ticket&gt;(.*)&lt;/ticket(.*)");
                        if (r.IsMatch(readString.ToString()))
                        {
                            Regex reg = new Regex(@"[A-Za-z0-9]{32}");
                            loginTicket = reg.Match(r.Match(readString.ToString()).ToString()).ToString();
                        }
                    }
                }
                
            }
            return loginTicket;
        }

        public string soapSMS(apiSendSms vSendSms)
        {
            apiSendSms apis = vSendSms;
            string msgid = null;

            WebRequest request = WebRequest.Create("http://www.smsglobal.com/mobileworks/soapserver.php");

            if (_cred != null) request.Proxy.Credentials = _cred;

            request.Method = "POST";
            request.ContentType = "text/xml";
            request.Headers.Add("urn:MobileWorks#apiSendSms");

            Windows_7_Dialogs.SecurityDialog a = new Windows_7_Dialogs.SecurityDialog();
            
             if (_cred == null)
            {
                a.Show();
                request.Proxy.Credentials = new NetworkCredential(a.UserData.Username, a.UserData.Password);
            }

            var document = new XDocument(
                                       new XDeclaration("1.0", "utf-8", String.Empty),
                                       new XElement(soapenv + "Envelope", new XAttribute(XNamespace.Xmlns + "SOAP-ENV", soapenv),
                                           new XElement(soapenv + "Body",
                                           new XElement("apiSendSms",
                                           new XElement("ticket", apis.ticket),
                                           new XElement("sms_from", apis.sms_from),
                                           new XElement("sms_to", apis.sms_to),
                                           new XElement("msg_content", System.Web.HttpUtility.HtmlEncode(apis.msg_content)),
                                           new XElement("msg_type", apis.msg_type),
                                           new XElement("unicode",apis.unicode),
                                           new XElement("schedule", apis.schedule)
                                           ))));

            if (File.Exists(Environment.CurrentDirectory + @"\sendSMS.xml")) File.Delete(Environment.CurrentDirectory + @"\sendSMS.xml");
            File.WriteAllText(Environment.CurrentDirectory + @"\sendSMS.xml", "<?xml version='1.0' ?>" + Environment.NewLine);
            File.AppendAllText(Environment.CurrentDirectory + @"\sendSMS.xml", document.ToString());
            document = XDocument.Load(Environment.CurrentDirectory + @"\sendSMS.xml");

            var writer = new StreamWriter(request.GetRequestStream());
            writer.WriteLine(document);
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
                        Regex r = new Regex(@"(.*)msgid&gt;(.*)&lt;/msgid(.*)");
                        if (r.IsMatch(readString.ToString()))
                        {
                            Regex reg = new Regex(@"[0-9]{16}");
                             msgid = reg.Match(r.Match(readString.ToString()).ToString()).ToString();
                        }
                    }

                }

            }

            return msgid;

        }

        public void HttpSMS(apiSendSms vSendSms, apiValidateLogin vlogin)
        {
            apiSendSms apis = vSendSms;
            apiValidateLogin apiv = vlogin;

            String encoded = System.Web.HttpUtility.HtmlEncode(vSendSms.msg_content);

            WebRequest request = WebRequest.Create("http://www.smsglobal.com/httpapi.php?action=sendsms&user=" + vlogin.APIusername + "&password=" + vlogin.APIpassword + "&from=" + vSendSms.sms_from + "&to=" + vSendSms.sms_to + "&text=" + encoded);

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
