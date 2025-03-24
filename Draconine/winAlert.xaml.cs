using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Draconine
{
    /// <summary>
    /// Interaction logic for winAlert.xaml
    /// </summary>
    public partial class winAlert : Window
    {
        const Int32 CO_E_APPNOTFOUND = unchecked((Int32)0x800401F5);
        string alertURL = "";
        public winAlert()
        {
            InitializeComponent();
        }
        public void showAlerts(clsForecast forecast)
        {
            lblAlertTitle.Content = forecast.getSetAlertTitle;
            lblAlertTime.Content = "Alert time: " + forecast.getSetAlertTime;
            lblAlertExpire.Content = "Alert expires: " + forecast.getSetAlertExpire;

            string formattedDescription = forecast.getSetAlertDescription.Replace("\r\n", Environment.NewLine).Replace("\n", Environment.NewLine).Replace("\r", Environment.NewLine);

            txtDescription.Text = formattedDescription;

            lblAlertURL.Focus();

            alertURL = forecast.getSetAlertURL;

            this.Show();
        }

        private void lblAlertURL_MouseDown(object sender, EventArgs e)
        {
            // Navigate to a URL.
            //Process.Start(alertURL);

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(alertURL);
                psi.UseShellExecute = true;
                psi.Verb = "open";

                using (Process p = Process.Start(psi))
                {
                    p.WaitForExit();
                }
            }
            catch (Win32Exception w32Ex) when (w32Ex.NativeErrorCode == CO_E_APPNOTFOUND)
            {
                MessageBox.Show("You don't have a web-browser installed or configured correctly.");
            }
        }
    }
}
