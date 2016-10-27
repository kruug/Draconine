using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draconine
{
  public class clsForecast
  {
    string date = ""; // Forecast for this date
    string longDate = "";
    string summary = ""; // A human-readable text summary
    string icon = ""; // A machine-readable text summary of this data point
    string sunrise = ""; // The UNIX time of the last sunrise before the solar noon closest to local noon on the given day
    string sunset = ""; // The UNIX time of the first sunset after the solar noon closest to local noon on the given day
    float moonPhase = 0; // A number representing the fractional part of the lunation number of the given day. 0 = new moon, 0.5 = full
    string moonPhaseString = "";
    float precipIntensity = 0; // A numerical value representing the average expected intensity (in inches per hour) of precipitation occurring at the given time
    float precipIntensityMax = 0; // A numerical values representing the maximumum expected intensity of precipitation
    float precipProbability = 0; // A numerical value between 0 and 1 (inclusive) representing the probability of precipitation occuring at the given time
    string precipType = ""; // A string representing the type of precipitation occurring at the given time (rain, snow, sleet, hail)
    float precipAccumulation = 0; // The amount of snowfall accumulation expected to occur on the given day, in inches
    float low = 0; // A numerical value representing the minimum temperature
    string lowTime = ""; // Unix time of when it's the minimum temperature
    float high = 0; // A numerical value representing the maximumum temperature
    string highTime = ""; // Unix time of when it's the maximumum temperature
    float feelsLow = 0; // A numerical value representing the minimum apparent (or “feels like”) temperature
    string feelsLowTime = ""; // Unix time of when it's the minimum apparent (or “feels like”) temperature
    float feelsHigh = 0; // A numerical value representing the maximum apparent (or “feels like”) temperature
    string feelsHighTime = ""; // Unix time of when it's the maximumum apparent (or “feels like”) temperature
    float dewPoint = 0; // A numerical value representing the dew point at the given time
    float humidity = 0; // A numerical value between 0 and 1 (inclusive) representing the relative humidity
    float windSpeed = 0; //  A numerical value representing the wind speed
    int windBearing = 0; // A numerical value representing the direction that the wind is coming from in degrees, with true north at 0° and progressing clockwise
    float visibility = 0; // A numerical value representing the average visibility in miles, capped at 10 miles
    float cloudCover = 0; // A numerical value between 0 and 1 (inclusive) representing the percentage of sky occluded by clouds
    float pressure = 0; // A numerical value representing the sea-level air pressure in millibars
    float ozone = 0; // A numerical value representing the columnar density of total atmospheric ozone at the given time in Dobson units

    string alertTitle = "";
    string alertTime = "";
    string alertExpire = "";
    string alertDescription = "";
    string alertURL = "";

    float temp = 0; // A numerical value representing the temperature
    float feelsLike = 0; // A numerical value representing the apparent (or “feels like”) temperature

    string forecastUnits = "";
    Uri image = new Uri("pack://application:,,,/Resources/weather-icons/clear-day.png");
    Uri phase = new Uri("pack://application:,,,/Resources/weather-icons/clear-night.png");
    Uri windBearingImage = new Uri("pack://application:,,,/Resources/weather-icons/compass.png");

    Uri icon_tmp = new Uri("pack://application:,,,/Resources/weather-icons/cloudy.png");
    Uri phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/clear-night.png");
    Uri windBearingImage_tmp = new Uri("pack://application:,,,/Resources/weather-icons/compass.png");

    public void setIcon(string value)
    {
      icon = value;
    }

    public Uri getIcon()
    {
      return new Uri("pack://application:,,,/Resources/weather-icons/" + icon + ".png");
    }

    public Uri convertPhase(float phase)
    {
      if (phase == 0)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-new.png");
        getSetMoonPhaseString = "New Moon";
      }
      else if (phase < 0.25 && phase > 0)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-wax-cresc.png");
        getSetMoonPhaseString = "Waxing Crescent";
      }
      else if (phase == 0.25)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-first.png");
        getSetMoonPhaseString = "First Quarter";
      }
      else if (phase < 0.50 && phase > 0.25)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-wax-gibb.png");
        getSetMoonPhaseString = "Waxing Gibbous";
      }
      else if (phase == 0.50)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-full.png");
        getSetMoonPhaseString = "Full Moon";
      }
      else if (phase < 0.75 && phase > 0.50)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-wane-gibb.png");
        getSetMoonPhaseString = "Waning Gibbous";
      }
      else if (phase == 0.75)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-last.png");
        getSetMoonPhaseString = "Last Quarter";
      }
      else if (phase < 1.0 && phase > 0.75)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-wane-cresc.png");
        getSetMoonPhaseString = "Waning Crescent";
      }
      else if (phase == 1.0)
      {
        phase_tmp = new Uri("pack://application:,,,/Resources/weather-icons/moon-new.png");
        getSetMoonPhaseString = "New Moon";
      }

      return phase_tmp;
    }

    public Uri convertWindBearing(float bearing)
    {
      if (bearing <= 45 || bearing > 315)
      {
        windBearingImage_tmp = new Uri("pack://application:,,,/Resources/weather-icons/south.png");
      }
      else if (bearing > 45 && bearing <= 135)
      {
        windBearingImage_tmp = new Uri("pack://application:,,,/Resources/weather-icons/west.png");
      }
      else if (bearing > 135 && bearing <= 225)
      {
        windBearingImage_tmp = new Uri("pack://application:,,,/Resources/weather-icons/north.png");
      }
      else if (bearing > 225 && bearing <= 315)
      {
        windBearingImage_tmp = new Uri("pack://application:,,,/Resources/weather-icons/png");
      }

      return windBearingImage_tmp;
    }

    public string getSetSummary
    {
      get
      {
        return summary;
      }
      set
      {
        summary = value;
      }
    }

    public float getSetTemp
    {
      get
      {
        return temp;
      }
      set
      {

        temp = value;
      }
    }

    public float getSetHigh
    {
      get
      {
        return high;
      }
      set
      {

        high = value;
      }
    }

    public float getSetLow
    {
      get
      {
        return low;
      }
      set
      {

        low = value;
      }
    }

    public string getSetDate
    {
      get
      {
        return date;
      }
      set
      {
        date = UnixTimeStampToDateTime(double.Parse(value));
      }
    }

    public string getSetLongDate
    {
      get
      {
        return longDate;
      }
      set
      {
        longDate = UnixTimeStampToLongDateTime(double.Parse(value));
      }
    }

    public string Units
    {
      get
      {
        if (forecastUnits == "si")
        {
          return "C";
        }
        else
        {
          return "F";
        }
      }
      set
      {
        forecastUnits = value;
      }
    }

    public string getSetSunrise
    {
      get
      {
        return sunrise;
      }
      set
      {
        sunrise = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public string getSetSunset
    {
      get
      {
        return sunset;
      }
      set
      {
        sunset = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public string getSetMoonPhaseString
    {
      get
      {
        return moonPhaseString;
      }
      set
      {
        moonPhaseString = value;
      }
    }

    public void setMoonPhase(float value)
    {
      moonPhase = value;
    }

    public Uri getMoonPhase()
    {
      phase = convertPhase(moonPhase);
      return phase;
    }

    public float getSetPrecipIntensity
    {
      get
      {
        return precipIntensity;
      }
      set
      {

        precipIntensity = value;
      }
    }

    public float getSetPrecipIntensityMax
    {
      get
      {
        return precipIntensityMax;
      }
      set
      {

        precipIntensityMax = value;
      }
    }

    public float getSetPrecipProbability
    {
      get
      {
        return precipProbability;
      }
      set
      {

        precipProbability = value * 100;
      }
    }

    public string getSetPrecipType
    {
      get
      {
        return precipType;
      }
      set
      {

        precipType = value;
      }
    }

    public float getSetPrecipAccumulation
    {
      get
      {
        return precipAccumulation;
      }
      set
      {

        precipAccumulation = value;
      }
    }

    public string getSetLowTime
    {
      get
      {
        return lowTime;
      }
      set
      {

        lowTime = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public string getSetHighTime
    {
      get
      {
        return highTime;
      }
      set
      {

        highTime = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public float getSetFeelsLow
    {
      get
      {
        return feelsLow;
      }
      set
      {

        feelsLow = value;
      }
    }

    public string getSetFeelsLowTime
    {
      get
      {
        return feelsLowTime;
      }
      set
      {

        feelsLowTime = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public float getSetFeelsHigh
    {
      get
      {
        return feelsHigh;
      }
      set
      {

        feelsHigh = value;
      }
    }

    public string getSetFeelsHighTime
    {
      get
      {
        return feelsHighTime;
      }
      set
      {

        feelsHighTime = UnixTimeStampToTime(double.Parse(value));
      }
    }

    public float getSetDewPoint
    {
      get
      {
        return dewPoint;
      }
      set
      {

        dewPoint = value;
      }
    }

    public float getSetHumidity
    {
      get
      {
        return humidity;
      }
      set
      {

        humidity = value * 100;
      }
    }

    public float getSetWindSpeed
    {
      get
      {
        return windSpeed;
      }
      set
      {

        windSpeed = value;
      }
    }

    public int getSetWindBearing
    {
      get
      {
        return windBearing;
      }
      set
      {

        windBearing = value;
      }
    }

    public Uri getWindBearing()
    {
      windBearingImage = convertWindBearing(windBearing);
      return windBearingImage;
    }

    public float getSetVisibility
    {
      get
      {
        return visibility;
      }
      set
      {

        visibility = value;
      }
    }

    public float getSetCloudCover
    {
      get
      {
        return cloudCover;
      }
      set
      {

        cloudCover = value * 100;
      }
    }

    public float getSetPressure
    {
      get
      {
        return pressure;
      }
      set
      {

        pressure = value;
      }
    }

    public float getSetOzone
    {
      get
      {
        return ozone;
      }
      set
      {

        ozone = value;
      }
    }

    public float getSetFeelsLike
    {
      get
      {
        return feelsLike;
      }
      set
      {

        feelsLike = value;
      }
    }

    public string getSetAlertTitle
    {
      get
      {
        return alertTitle;
      }
      set
      {
        alertTitle = value;
      }
    }

    public string getSetAlertTime
    {
      get
      {
        return alertTime;
      }
      set
      {

        alertTime = UnixTimeStampToFullDateTime(double.Parse(value));
      }
    }

    public string getSetAlertExpire
    {
      get
      {
        return alertExpire;
      }
      set
      {

        alertExpire = UnixTimeStampToFullDateTime(double.Parse(value));
      }
    }

    public string getSetAlertDescription
    {
      get
      {
        return alertDescription;
      }
      set
      {
        alertDescription = value;
      }
    }

    public string getSetAlertURL
    {
      get
      {
        return alertURL;
      }
      set
      {
        alertURL = value;
      }
    }

    public static string UnixTimeStampToTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      string stTime = dtDateTime.ToString("HH:mm:ss");
      return stTime;
    }

    public static string UnixTimeStampToDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      string stMonthDay = dtDateTime.ToString("MM'/'dd");
      return stMonthDay;
    }

    public static string UnixTimeStampToLongDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      string stLongMonthDay = dtDateTime.ToString("dddd, MMMM dd, yyyy");
      return stLongMonthDay;
    }

    public static string UnixTimeStampToFullDateTime(double unixTimeStamp)
    {
      // Unix timestamp is seconds past epoch
      System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
      string stLongMonthDay = dtDateTime.ToString("dddd, MMMM dd, yyyy HH:mm:ss");
      return stLongMonthDay;
    }
  }
}
