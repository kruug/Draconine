using System;
using System.Collections.Generic;
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
  public partial class winDetails : Window
  {
    public winDetails()
    {
      InitializeComponent();
    }

    public void showDetails(clsForecast forecast)
    {
      this.Title = "Forecast details for " + forecast.getSetLongDate;
      lblDate.Content = forecast.getSetLongDate;
      lblSummary.Content = forecast.getSetSummary;

      //while (lblSummary.Width < System.Windows.Forms.TextRenderer.MeasureText(lblSummary.Text,
      //    new Font(lblSummary.Font.FontFamily, lblSummary.Font.Size, lblSummary.Font.Style)).Width)
      //{
      //  lblSummary.Font = new Font(lblSummary.Font.FontFamily, lblSummary.Font.Size - 0.5f, lblSummary.Font.Style);
      //}

      imgIcon.Source = new BitmapImage(forecast.getIcon());

      /*lblPrecipIntensity.Text = "Intensity: " + forecast.getSetPrecipIntensity + " inches/hour";
      lblPrecipProbability.Text = "Probability: " + forecast.getSetPrecipProbability + "%";
      lblPrecipType.Text = "Type: " + forecast.getSetPrecipType;

      lblCurrentTemp.Text = "Temp: " + forecast.getSetTemp + "\u00B0" + forecast.Units;

      lblCurrentFeelsTemp.Text = "Temp: " + forecast.getSetFeelsLike + "\u00B0" + forecast.Units;

      lblWindSpeed.Text = "Speed: " + forecast.getSetWindSpeed + " miles/hour";
      lblWindBearing.Text = "Bearing: " + forecast.getSetWindBearing + "\u00B0";
      pbWindBearing.Image = forecast.getWindBearing();

      if (forecast.getSetVisibility == 11)
      {
        lblVisibility.Text = "Visibility: 10+ miles";

      }
      else
      {
        lblVisibility.Text = "Visibility: " + forecast.getSetVisibility + " miles";
      }
      lblCloudCover.Text = "Cloud Cover: " + forecast.getSetCloudCover + "%";

      lblDewPoint.Text = "Dew Point: " + forecast.getSetDewPoint + "\u00B0" + forecast.Units;
      lblHumidity.Text = "Humidity: " + forecast.getSetHumidity + "%";
      lblPressure.Text = "Pressure: " + forecast.getSetPressure + " millibars";
      lblOzone.Text = "Ozone: " + forecast.getSetOzone;
      */
      this.Show();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
