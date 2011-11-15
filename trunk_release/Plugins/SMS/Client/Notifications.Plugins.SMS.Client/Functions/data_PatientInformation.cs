using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notifications.Plugins.SMS.Global.ComObjects.Data
{
   public class data_PatientInformation
    {
       private string _familyName;
       private string _givenName;
       private string _email;
       private string _mobile;
       private string _phone;
       private string _remindertext;
       private string _reminderDate;
       private string _doctor;
       public data_PatientInformation() { } 
       public data_PatientInformation(string fn, string gn, string e, string m, string p, string rt, string rd, string doctor)
       {
           _familyName = fn;
           _givenName = gn;
           _email = e;
           _mobile = m;
           _phone = p;
           _remindertext = rt;
           _reminderDate = rd;
           _doctor = doctor;
       }
     
       public string FamilyName
       {
           get { return _familyName; }
           set { _familyName = value; } 
       }
       public string GivenName
       {
           get { return _givenName; }
           set { _givenName = value; }
       }
       public string Email
       {
           get { return _email; }
           set { _email = value; }
       }
       public string Mobile
       {
           get { return _mobile; }
           set { _mobile = value; }
       }
       public string Phone
       {
           get { return _phone; }
           set { _phone = value; }
       }
       public string ReminderText
       {
           get { return _remindertext; }
           set { _remindertext = value; }
       }
       public string ReminderDate
       {
           get { return _reminderDate; }
           set { _reminderDate = value; }
       }
       public string Doctor
       {
           get { return _doctor; }
           set { _doctor = value; }
       }

    }
}
