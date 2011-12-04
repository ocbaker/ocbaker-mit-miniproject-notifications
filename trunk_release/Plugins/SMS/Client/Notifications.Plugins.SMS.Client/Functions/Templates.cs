using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Client.Functions
{
    public class Templates
    {
        private string temp;
        private string text;
        public Templates(string n, string t)
        {
            temp = n;
            text = t;
        }
        public String TemplateName
        {
            get { return temp; }
            set { temp = value; }
        }
        public string TemplateText
        {
            get { return text; }
            set { text = value; }
        }
    }
}
