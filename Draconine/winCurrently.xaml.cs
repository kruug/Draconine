using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Draconine
{
    /// <summary>
    /// Interaction logic for winCurrently.xaml
    /// </summary>
    public partial class winCurrently : Window
    {

    clsForecast[] forecast = new clsForecast[10];
    clsDataGetter data = new clsDataGetter();
    
    public winCurrently()
        {
            InitializeComponent();

      imgSettings.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/gear.png"));
      imgRefresh.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/refresh.png"));

      Left = System.Windows.SystemParameters.PrimaryScreenWidth - Width;
      Top = System.Windows.SystemParameters.PrimaryScreenHeight - (Height + 50);

      data.getLatLon();

      updateData();

      System.Timers.Timer aTimer = new System.Timers.Timer();
      aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
      aTimer.Interval = 3600000; // 1 Hour
      aTimer.Enabled = true;
    }

    // Specify what you want to happen when the Elapsed event is raised.
    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
      updateData();
    }

    private void updateData()
    {
      forecast = data.getForecast(forecast);

      lblCurrentTemp.Content = forecast[9].getSetTemp + "\u00B0" + forecast[9].Units;

      lblCurrentConditions.Content = forecast[9].getSetSummary;
      
      imgCurrentConditions.Source = new BitmapImage(forecast[9].getIcon());

      if (forecast[9].getSetAlertTitle != "")
      {
        imgAlert.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/weather_alert_yes.png"));
        btnAlert.IsEnabled = true;
      }
      else
      {
        imgAlert.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/weather_alert_no.png"));
        btnAlert.IsEnabled = false;
      }
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
      updateData();
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
      winSettings Settings = new winSettings();
      Settings.ShowDialog();
    }

    private void grpCurrent_MouseDown(object sender, EventArgs e)
    {
      winCurrentDetails currentDetails = new winCurrentDetails();
      currentDetails.showDetails(forecast[9]);
    }

    private void btnAlert_Click(object sender, EventArgs e)
    {
      winAlert currentAlerts = new winAlert();
      currentAlerts.showAlerts(forecast[9]);
    }
  }
}
