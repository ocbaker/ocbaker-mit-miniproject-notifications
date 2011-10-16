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
using Extensions;
using System.Security.Cryptography;
using System.Configuration;

namespace wpfClient.Pages.Administration
{
    /// <summary>
    /// Interaction logic for admSMS.xaml
    /// </summary>
    public partial class admSMS : Page
    {
        apiValidateLogin Login = pgeSMS.vlogin;
        public admSMS()
        {
            InitializeComponent();
            
        }
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private void btnLoginSave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
        }
        private void btnProxySave_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Send the username/password to the Settings Project.
        }
        public void txtUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            try {
                Login.APIusername = txtSMSUsername.Text;

                string a =  Encrypt(txtSMSUsername.Text, true);
                MessageBox.Show("Encrypted text: " + a); 
                MessageBox.Show("Decrpted text: " + Decrypt(a, true));
                //psbSMSpassword.SetStatus("OK", TextBoxStatuses.OK);
            } catch (ArgumentException ex) {
               // txtUsername.SetStatus("Error", TextBoxStatuses.ERRORED);
            }
        }
        public void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            try {
                Login.APIpassword = psbSMSpassword.Password;
                //txtPassword.SetStatus("OK", TextBoxStatuses.OK);
            } catch (ArgumentException ex) {
               // txtPassword.SetStatus("Error", TextBoxStatuses.ERRORED);
            }

        }

        private void psbGmailPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.APIpassword = psbGmailPassword.Password;
   
            }
            catch (ArgumentException ex)
            {
     
            }
        }

        private void tbGmailUserlogin_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.APIpassword = txtGmailUserlogin.Text;
                //txtPassword.SetStatus("OK", TextBoxStatuses.OK);
            }
            catch (ArgumentException ex)
            {
                // txtPassword.SetStatus("Error", TextBoxStatuses.ERRORED);
            }
        }

        private void pswProxyPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.APIpassword = pswProxyPassword.Password;

            }
            catch (ArgumentException ex)
            {
    
            }
        }

        private void txtProxyUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                Login.APIpassword = txtProxyUsername.Text;
                //txtPassword.SetStatus("OK", TextBoxStatuses.OK);
            }
            catch (ArgumentException ex)
            {
                // txtPassword.SetStatus("Error", TextBoxStatuses.ERRORED);
            }
        }



    }
}
