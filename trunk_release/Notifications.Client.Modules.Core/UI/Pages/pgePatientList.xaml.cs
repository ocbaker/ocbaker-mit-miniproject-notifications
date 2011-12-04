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
using Microsoft.Win32;
using System.IO;

namespace Notifications.Client.Core.Core.UI.Pages
{
    /// <summary>
    /// Interaction logic for pgePatientList.xaml
    /// </summary>
    public partial class pgePatientList : Page
    {
        private string myfilename;
        public List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            try
            {
                using (StreamReader readFile = new StreamReader(myfilename))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return parsedData;
        }
        public pgePatientList()
        {
            InitializeComponent();
            Notifications.Client.Interop.NetworkComms.addDataHandler((new Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv(new Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv())), sentStatus, true);

            Microsoft.Win32.OpenFileDialog of = new Microsoft.Win32.OpenFileDialog();

            of.FileName = "";
            of.DefaultExt = ".csv";

            Nullable<bool> result = of.ShowDialog();

            if (result == true)
            {
                myfilename = of.FileName;
            }

            List<String[]> parsed = parseCSV(myfilename);

            Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv rsendCSV = new Notifications.Global.Core.Communication.Core.Requests.comdata_rqsendCsv();
            rsendCSV.parsedPatients = parsed;
            Notifications.Client.Interop.NetworkComms.sendMessage(rsendCSV);
        }

        public Object sentStatus(Object response) {
            Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv r = (Notifications.Global.Core.Communication.Core.Responses.comdata_rpsendCsv)response;

            lblStatus.Content = "Successful attatch to database?    " + r.sucessfullSend;

            if (r.sucessfullSend == true)
            {                
                this.DataContext = r.returnedPatients.Tables[0];
                InitializeComponent();
            }

            return false;
        }


    }
}
