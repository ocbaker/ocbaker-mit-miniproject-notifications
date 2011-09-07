using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

[Serializable()]
public class apiSendSms 
    {
        private string _ticket;
        private string _sms_from;
        private string _sms_to;
        private string _msg_content;
        private string _msg_type = "text";
        private string _unicode = "0";
        private string _schedule;
        public string _responce;
       
          public apiSendSms()
        {
        }
        public apiSendSms(string t, string from, string to, string content, string sch)
        {
            ticket = t;
            sms_from = from;
            sms_to = to;
            msg_content = content;
            schedule = sch;
        }
    /// <summary>
    /// The apiSendSms object accepts a ticket, sms_from, sms_to, message content, message type, unicode and the schedule.
    /// </summary>
        public string ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }
    /// <summary>
    /// The login ticket so we can connect to the SMSGlobal API
    /// </summary>
        public string sms_from
        {
            get { return _sms_from; }
            set { 
                Regex r = new Regex(@"[\D]+");  Regex rplus = new Regex(@"^[\+]");
                if (rplus.IsMatch(value))
                {
                    value = value.Replace("+", String.Empty);
                }
                if (r.IsMatch(value)) 
                {
                    throw new NullReferenceException();
                } else {
                    _sms_from = value; 
                }
               
            }
        }
    /// <summary>
    /// Number who the SMS is from. 
    /// </summary>
        public string sms_to
        {
            get { return _sms_to; }
            set {

                Regex r = new Regex(@"[\D]+"); Regex rplus = new Regex(@"^[\+]");
                if (rplus.IsMatch(value))
                {
                    value = value.Replace("+", String.Empty);
                }
                if (r.IsMatch(value))
                {
                 
                    throw new ArgumentException();
                }
                else
                {
                    _sms_to = value;
                }           
            }
        }
    /// <summary>
    /// Who the recipient of the text is (number)
    /// </summary>
        public string msg_content
        {
            get { return _msg_content; }
            set {

                if (value.Length > 160)
                {
                    throw new ArgumentException();
                } else {
                    _msg_content = value;
                }      
            }
        }
    /// <summary>
    /// The message to be included in the text
    /// </summary>
        public string msg_type
        {
            get { return _msg_type; }
        }
    /// <summary>
    /// This is ALWAYS text, meaning, the text is in text form.
    /// </summary>
        public string unicode
        {
            get { return _unicode; }
        }
    /// <summary>
    /// Unicode
    /// </summary>
        public string schedule
        {
            //Need to convert to yyyy‐mm‐dd hh:mm:ss
            get { return _schedule; }
            set {
                //Look at some type of converting? if needed?
                _schedule = value; 
            }
        }
   ///When the text should be sent (if not included the text sends immediatly).

    }