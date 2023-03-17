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
  /// Interaction logic for winDetails.xaml
  /// </summary>
  public partial class winCurrentDetails : Window
  {
    public winCurrentDetails()
    {
      InitializeComponent();
    }
    public void showDetails(clsForecast forecast)
    {
      this.Title = "Forecast details for " + forecast.getSetLongDate;
      lblDate.Content = forecast.getSetLongDate;
      lblSummary.Content = forecast.getSetSummary;
      
      imgIcon.Source = new BitmapImage(forecast.getIcon());

      lblPrecipIntensity.Content = "Intensity: " + forecast.getSetPrecipIntensity + " inches/hour";
      lblPrecipProbability.Content = "Probability: " + forecast.getSetPrecipProbability + "%";
      lblPrecipType.Content = "Type: " + forecast.getSetPrecipType;

      lblCurrentTemp.Content = "Temp: " + forecast.getSetTemp + "\u00B0" + forecast.Units;
      lblCurrentFeelsTemp.Content = "Temp: " + forecast.getSetFeelsLike + "\u00B0" + forecast.Units;
      
      lblWindSpeed.Content = "Speed: " + forecast.getSetWindSpeed + " miles/hour";
      lblWindBearing.Content = "Bearing: " + forecast.getSetWindBearing + "\u00B0";
      imgWindBearing.Source = new BitmapImage(forecast.getWindBearing());
      
      if (forecast.getSetVisibility == 11)
      {
        lblVisibility.Content = "Visibility: 10+ miles";
      }
      else
      {
        lblVisibility.Content = "Visibility: " + forecast.getSetVisibility + " miles";
      }
      lblCloudCover.Content = "Cloud Cover: " + forecast.getSetCloudCover + "%";
      
      lblDewPoint.Content = "Dew Point: " + forecast.getSetDewPoint + "\u00B0" + forecast.Units;
      lblHumidity.Content = "Humidity: " + forecast.getSetHumidity + "%";
      lblPressure.Content = "Pressure: " + forecast.getSetPressure + " millibars";
      lblOzone.Content = "Ozone: " + forecast.getSetOzone;
      
      this.Show();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void grpLogo_MouseDown(object sender, EventArgs e)
    {
      Process.Start("https://openweathermap.org/");
    }
  }
}
