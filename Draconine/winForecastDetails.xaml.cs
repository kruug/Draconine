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
  /// Interaction logic for winForecastDetails.xaml
  /// </summary>
  public partial class winForecastDetails : Window
  {
    public winForecastDetails()
    {
      InitializeComponent();
    }

    public void showDetails(clsForecast forecast)
    {
      imgSunrise.Source = new BitmapImage( new Uri("pack://application:,,,/Resources/weather-icons/sunrise.png"));
      imgSunset.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/weather-icons/sunset.png"));

      this.Title = "Forecast details for " + forecast.getSetLongDate;
      lblDate.Content = forecast.getSetLongDate;
      lblSummary.Content = forecast.getSetSummary;

      /*while (lblSummary.Width < System.Windows.Forms.TextRenderer.MeasureText(lblSummary.Text,
          new Font(lblSummary.Font.FontFamily, lblSummary.Font.Size, lblSummary.Font.Style)).Width)
      {
        lblSummary.Font = new Font(lblSummary.Font.FontFamily, lblSummary.Font.Size - 0.5f, lblSummary.Font.Style);
      }*/

      imgIcon.Source = new BitmapImage(forecast.getIcon());

      lblSunrise.Content = "Sunrise: " + forecast.getSetSunrise;
      lblSunset.Content = "Sunset: " + forecast.getSetSunset;

      imgMoonPhase.Source = new BitmapImage(forecast.getMoonPhase());
      lblMoonPhase.Content = "Phase: " + forecast.getSetMoonPhaseString;

      lblPrecipIntensity.Content = "Intensity: " + forecast.getSetPrecipIntensity + " inches/hour";
      lblPrecipIntensityMax.Content = "Max Intensity: " + forecast.getSetPrecipIntensityMax + " inches";
      lblPrecipProbability.Content = "Probability: " + forecast.getSetPrecipProbability + "%";
      lblPrecipType.Content = "Type: " + forecast.getSetPrecipType;
      lblPrecipAccumulation.Content = "Accumulation: " + forecast.getSetPrecipAccumulation + " inches";

      lblHigh.Content = "High: " + forecast.getSetHigh + "\u00B0" + forecast.Units;
      lblHighTime.Content = "High Time: " + forecast.getSetHighTime;
      lblLow.Content = "Low: " + forecast.getSetLow + "\u00B0" + forecast.Units;
      lblLowTime.Content = "Low Time: " + forecast.getSetLowTime;

      lblFeelsHigh.Content = "High: " + forecast.getSetFeelsHigh + "\u00B0" + forecast.Units;
      lblFeelsHighTime.Content = "High Time: " + forecast.getSetFeelsHighTime;
      lblFeelsLow.Content = "Low: " + forecast.getSetFeelsLow + "\u00B0" + forecast.Units;
      lblFeelsLowTime.Content = "Low Time: " + forecast.getSetFeelsLowTime;

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
    private void grpLogo_MouseDown(object sender, EventArgs e)
    {
      Process.Start("https://darksky.net/poweredby/");
    }
    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
