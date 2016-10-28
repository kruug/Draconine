using System;
using System.Collections.Generic;
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
      Process.Start(alertURL);
    }
  }
}
