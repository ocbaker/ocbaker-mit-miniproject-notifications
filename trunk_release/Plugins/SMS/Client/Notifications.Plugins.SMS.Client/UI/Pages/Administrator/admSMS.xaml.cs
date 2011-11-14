using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Notifications.Plugins.SMS.Server;

namespace Notifications.Plugins.SMS.Client.UI.Pages
{
    /// <summary>
    /// Interaction logic for admSMS.xaml
    /// </summary>

    public partial class admSMS : Page
    {
       // apiValidateLogin Login = pgeSMS.vlogin;
        
        
        public admSMS()
        {
            InitializeComponent();

            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpProxy(new Global.ComObjects.Requests.comdata_rqProxy())), Proxy);
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpEmail(new Global.ComObjects.Requests.comdata_rqEmail())), yougotMail);
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Global.ComObjects.Response.comdata_rpSMSGlobal(new Global.ComObjects.Requests.comdata_rqSMSGlobal())), SMS);

            loadPreviousData();
        }
        private void loadPreviousData() {

            Global.ComObjects.Requests.comdata_rqSMSGlobal rSMS = new Global.ComObjects.Requests.comdata_rqSMSGlobal();
            rSMS.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rSMS);

            Global.ComObjects.Requests.comdata_rqProxy rProxy = new Global.ComObjects.Requests.comdata_rqProxy();
            rProxy.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rProxy);

            Global.ComObjects.Requests.comdata_rqEmail rMail = new Global.ComObjects.Requests.comdata_rqEmail();
            rMail.getData = true;
            Notifications.Client.Interop.NetworkComms.sendMessage(rMail);
        }
        private object Proxy(Object response) {

            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpProxy)response;

            if (t.dataRetrieved == true)
            {
               
                txtProxyUsername.Text = t.username;
                pswProxyPassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblProxySave.Content = "Saved!";
                }
                else
                {
                    lblProxySave.Content = "Save failed";
                }
            }
            return false;
        }
        private object SMS(Object response)
        {

            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpSMSGlobal)response;

            if (t.dataRetrieved == true)
            {

                txtSMSUsername.Text = t.username;
                psbSMSpassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblSMSSave.Content = "Saved!";
                }
                else
                {
                    lblSMSSave.Content = "Save failed";
                }
            }
            return false;
        }
        private object yougotMail(Object response)
        {
            Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail t = (Notifications.Plugins.SMS.Global.ComObjects.Response.comdata_rpEmail)response;

            if (t.dataRetrieved == true)
            {
                txtGmailUserlogin.Text = t.username;
                psbGmailPassword.Password = t.password;
            }
            else
            {
                if (t.SaveSucessful == true)
                {
                    lblMailSave.Content = "Saved!";
                }
                else
                {
                    lblMailSave.Content = "Save failed";
                }
            }
            return false;
        }

        //public static string Encrypt(string toEncrypt, bool useHashing)
        //{
        //    byte[] keyArray;
        //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

        //    System.Configuration.AppSettingsReader settingsReader =
        //                                        new AppSettingsReader();
        //    // Get the key from config file

        //    string key = (string)settingsReader.GetValue("SecurityKey",
        //                                                     typeof(String));
        //    //System.Windows.Forms.MessageBox.Show(key);
        //    //If hashing use get hashcode regards to your key
        //    if (useHashing)
        //    {
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //Always release the resources and flush data
        //        // of the Cryptographic service provide. Best Practice

        //        hashmd5.Clear();
        //    }
        //    else
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes.
        //    //We choose ECB(Electronic code Book)
        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)

        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateEncryptor();
        //    //transform the specified region of bytes array to resultArray
        //    byte[] resultArray =
        //      cTransform.TransformFinalBlock(toEncryptArray, 0,
        //      toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor
        //    tdes.Clear();
        //    //Return the encrypted data into unreadable string format
        //    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        //}
        //public static string Decrypt(string cipherString, bool useHashing)
        //{
        //    byte[] keyArray;
        //    //get the byte code of the string

        //    byte[] toEncryptArray = Convert.FromBase64String(cipherString);

        //    System.Configuration.AppSettingsReader settingsReader =
        //                                        new AppSettingsReader();
        //    //Get your key from config file to open the lock!
        //    string key = (string)settingsReader.GetValue("SecurityKey",
        //                                                 typeof(String));

        //    if (useHashing)
        //    {
        //        //if hashing was used get the hash code with regards to your key
        //        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        //        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        //        //release any resource held by the MD5CryptoServiceProvider

        //        hashmd5.Clear();
        //    }
        //    else
        //    {
        //        //if hashing was not implemented get the byte code of the key
        //        keyArray = UTF8Encoding.UTF8.GetBytes(key);
        //    }

        //    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        //    //set the secret key for the tripleDES algorithm
        //    tdes.Key = keyArray;
        //    //mode of operation. there are other 4 modes. 
        //    //We choose ECB(Electronic code Book)

        //    tdes.Mode = CipherMode.ECB;
        //    //padding mode(if any extra byte added)
        //    tdes.Padding = PaddingMode.PKCS7;

        //    ICryptoTransform cTransform = tdes.CreateDecryptor();
        //    byte[] resultArray = cTransform.TransformFinalBlock(
        //                         toEncryptArray, 0, toEncryptArray.Length);
        //    //Release resources held by TripleDes Encryptor                
        //    tdes.Clear();
        //    //return the Clear decrypted TEXT
        //    return UTF8Encoding.UTF8.GetString(resultArray);
        //}

        private void btnLoginSave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.

            Global.ComObjects.Requests.comdata_rqSMSGlobal rSMS = new Global.ComObjects.Requests.comdata_rqSMSGlobal();
            rSMS.username = txtSMSUsername.Text;
            rSMS.password = psbSMSpassword.Password;
            rSMS.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rSMS);

        }
        private void btnProxySave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
            Global.ComObjects.Requests.comdata_rqProxy rProxy = new Global.ComObjects.Requests.comdata_rqProxy();
            rProxy.username = txtProxyUsername.Text;
            rProxy.password = pswProxyPassword.Password;
            rProxy.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rProxy);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
            Global.ComObjects.Requests.comdata_rqEmail rMail = new Global.ComObjects.Requests.comdata_rqEmail();
            rMail.username = txtGmailUserlogin.Text;
            rMail.password = psbGmailPassword.Password;
            rMail.getData = false;
            Notifications.Client.Interop.NetworkComms.sendMessage(rMail);
        }
        public void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }
        public void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void psbGmailPassword_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }

        private void tbGmailUserlogin_LostFocus(object sender, RoutedEventArgs e)
        {
        
        }

        private void pswProxyPassword_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void txtProxyUsername_LostFocus(object sender, RoutedEventArgs e)
        {
          
        }



    }

}
