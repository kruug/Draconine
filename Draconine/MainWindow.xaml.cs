using System.Diagnostics;
using System.Text;
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
using System.Windows.Threading;

namespace Draconine;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    clsForecast[] forecast = new clsForecast[10];
    clsDataGetter data = new clsDataGetter();
    public MainWindow()
    {
        Debug.WriteLine("Initializing");
        InitializeComponent();
        Debug.WriteLine("Initialized");
        Debug.WriteLine("Getting LatLong");
        data.getLatLon();
        Debug.WriteLine("Got LatLong");

        Debug.WriteLine("Updating Data");
        updateData();
        Debug.WriteLine("Data Updated");

        Debug.WriteLine("Starting Timer");
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //aTimer.Interval = 3600000; // 1 Hour
        aTimer.Interval = 600000; // 10 Minutes
        aTimer.Enabled = true;
        aTimer.Start();
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        Application.Current.Dispatcher.BeginInvoke(
            DispatcherPriority.Background,
            new Action(() =>
            {
                updateData();
            })
            );
    }

    private void updateData()
    {
        Debug.WriteLine("Getting forecast");
        forecast = data.GetForecast(forecast).Result;
        Debug.WriteLine("Got forecast");

        lblCurrentTemp.Content = forecast[9].getSetTemp.ToString() + "\u00B0" + forecast[9].Units;
        lblTodayTemp.Content = forecast[0].getSetHigh.ToString("0") + "/" + forecast[0].getSetLow.ToString("0") + "\u00B0" + forecast[0].Units;
        lblTomorrowTemp.Content = forecast[1].getSetHigh.ToString("0") + "/" + forecast[1].getSetLow.ToString("0") + "\u00B0" + forecast[1].Units;
        lblDayAfterTemp.Content = forecast[2].getSetHigh.ToString("0") + "/" + forecast[2].getSetLow.ToString("0") + "\u00B0" + forecast[2].Units;

        txtCurrentConditions.Text = forecast[9].getSetSummary;
        txtTodayConditions.Text = forecast[0].getSetSummary;
        txtTomorrowConditions.Text = forecast[1].getSetSummary;
        txtDayAfterConditions.Text = forecast[2].getSetSummary;

        imgCurrentConditions.Source = new BitmapImage(forecast[9].getIcon());
        imgTodayConditions.Source = new BitmapImage(forecast[0].getIcon());
        imgTomorrowConditions.Source = new BitmapImage(forecast[1].getIcon());
        imgDayAfterConditions.Source = new BitmapImage(forecast[2].getIcon());

        lblTodayDate.Content = forecast[0].getSetDate;
        lblTomorrowDate.Content = forecast[1].getSetDate;
        lblDayAfterDate.Content = forecast[2].getSetDate;

        grpDay0.Header = forecast[0].getSetDay;
        grpDay1.Header = forecast[1].getSetDay;
        grpDay2.Header = forecast[2].getSetDay;

        lblLastUpdate.Content = "Last Updated: " + DateTime.Now.ToString();

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
    private void imgLogo_MouseDown(object sender, EventArgs e)
    {
        Process.Start("https://darksky.net/poweredby/");
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        updateData();
    }

    private void btnAbout_Click(object sender, EventArgs e)
    {
        winAbout about = new winAbout();
        about.ShowDialog();
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        /*winSettings Settings = new winSettings();
        Settings.ShowDialog();*/
    }

    private void btnAlert_Click(object sender, EventArgs e)
    {
        winAlert currentAlerts = new winAlert();
        currentAlerts.showAlerts(forecast[9]);
    }

    private void grpCurrent_MouseDown(object sender, EventArgs e)
    {
        winCurrentDetails currentDetails = new winCurrentDetails();
        currentDetails.showDetails(forecast[9]);
    }
    private void grpDay0_MouseDown(object sender, EventArgs e)
    {
        winForecastDetails forecastDetails = new winForecastDetails();
        forecastDetails.showDetails(forecast[0]);
    }

    private void grpDay1_MouseDown(object sender, EventArgs e)
    {
        winForecastDetails forecastDetails = new winForecastDetails();
        forecastDetails.showDetails(forecast[1]);
    }

    private void grpDay2_MouseDown(object sender, EventArgs e)
    {
        winForecastDetails forecastDetails = new winForecastDetails();
        forecastDetails.showDetails(forecast[2]);
    }
}