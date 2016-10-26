using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Draconine
{
  class clsDataGetter
  {
    const string API_KEY = "";

    clsForecast current = new clsForecast();
    float flat = 0;
    float flon = 0;
    string lat = "";
    string lon = "";

    WebClient wcLatLon = new WebClient();

    public void getLatLon()
    {
      var data = wcLatLon.DownloadString("http://ip-api.com/json");
      JObject o = JObject.Parse(data);
      lat = o["lat"].ToString();
      lon = o["lon"].ToString();
      flat = float.Parse(lat, CultureInfo.InvariantCulture.NumberFormat);
      flon = float.Parse(lon, CultureInfo.InvariantCulture.NumberFormat);
    }

    public clsForecast[] getForecast(clsForecast[] forecast)
    {
      // API Key, Lat, Long, Unit

      string url = "https://api.forecast.io/forecast/" + API_KEY + "/" + flat + "," + flon;
      //var request = new ForecastIORequest(API_KEY, flat, flon, Unit.auto);
      var response = new WebClient().DownloadData(url);
      UTF32Encoding utf32 = new UTF32Encoding();
      byte[] utf32Array = Encoding.Convert(Encoding.UTF8, Encoding.UTF32, response);
      string finalString = utf32.GetString(utf32Array);
      dynamic weatherData = JObject.Parse(finalString.ToString());
      //var response = request.Get();

      for (int i = 0; i < 7; i++)
      {
        clsForecast tempForecast = new clsForecast();
        tempForecast.getSetDate = (string)weatherData.daily.data[i].time.ToString();
        tempForecast.getSetLongDate = (string)weatherData.daily.data[i].time.ToString();
        tempForecast.getSetSummary = (string)weatherData.daily.data[i].summary;
        tempForecast.setIcon((string)weatherData.daily.data[i].icon);
        tempForecast.getSetSunrise = (string)weatherData.daily.data[i].sunriseTime.ToString();
        tempForecast.getSetSunset = (string)weatherData.daily.data[i].sunsetTime.ToString();
        tempForecast.setMoonPhase((float)weatherData.daily.data[i].moonPhase);
        tempForecast.getSetPrecipIntensity = (float)weatherData.daily.data[i].precipIntensity;
        tempForecast.getSetPrecipIntensityMax = (float)weatherData.daily.data[i].precipIntensityMax;
        tempForecast.getSetPrecipProbability = (float)weatherData.daily.data[i].precipProbability;
        tempForecast.getSetPrecipType = (string)weatherData.daily.data[i].precipType;
        tempForecast.getSetLow = (float)weatherData.daily.data[i].temperatureMin;
        tempForecast.getSetLowTime = (string)weatherData.daily.data[i].temperatureMinTime.ToString();
        tempForecast.getSetHigh = (float)weatherData.daily.data[i].temperatureMax;
        tempForecast.getSetHighTime = (string)weatherData.daily.data[i].temperatureMaxTime.ToString();
        tempForecast.getSetFeelsLow = (float)weatherData.daily.data[i].apparentTemperatureMin;
        tempForecast.getSetFeelsLowTime = (string)weatherData.daily.data[i].apparentTemperatureMinTime.ToString();
        tempForecast.getSetFeelsHigh = (float)weatherData.daily.data[i].apparentTemperatureMax;
        tempForecast.getSetFeelsHighTime = (string)weatherData.daily.data[i].apparentTemperatureMaxTime.ToString();
        tempForecast.getSetDewPoint = (float)weatherData.daily.data[i].dewPoint;
        tempForecast.getSetHumidity = (float)weatherData.daily.data[i].humidity;
        tempForecast.getSetWindSpeed = (float)weatherData.daily.data[i].windSpeed;

        if (weatherData.daily.data[i].windBearing == null)
        {
          tempForecast.getSetWindBearing = 0;
        }
        else
        {
          tempForecast.getSetWindBearing = (int)weatherData.daily.data[i].windBearing;
        }

        if (weatherData.daily.data[i].visibility == null)
        {
          tempForecast.getSetVisibility = 11;
        }
        else
        {
          tempForecast.getSetVisibility = (float)weatherData.daily.data[i].visibility;
        }
        tempForecast.getSetCloudCover = (float)weatherData.daily.data[i].cloudCover;
        tempForecast.getSetPressure = (float)weatherData.daily.data[i].pressure;
        tempForecast.getSetOzone = (float)weatherData.daily.data[i].ozone;

        tempForecast.Units = (string)weatherData.flags.units;

        forecast[i] = tempForecast;
      }

      current.getSetDate = (string)weatherData.currently.time;
      current.getSetLongDate = (string)weatherData.currently.time;
      current.getSetSummary = (string)weatherData.currently.summary;
      current.setIcon((string)weatherData.currently.icon);
      current.getSetPrecipIntensity = (float)weatherData.currently.precipIntensity;
      current.getSetPrecipProbability = (float)weatherData.currently.precipProbability;
      current.getSetPrecipType = (string)weatherData.currently.precipType;
      current.getSetTemp = (float)weatherData.currently.temperature;
      current.getSetFeelsLike = (float)weatherData.currently.apparentTemperature;
      current.getSetDewPoint = (float)weatherData.currently.dewPoint;
      current.getSetHumidity = (float)weatherData.currently.humidity;
      current.getSetWindSpeed = (float)weatherData.currently.windSpeed;
      current.getSetWindBearing = (int)weatherData.currently.windBearing;
      current.getSetVisibility = (int)weatherData.currently.visibility;
      current.getSetCloudCover = (float)weatherData.currently.cloudCover;
      current.getSetPressure = (float)weatherData.currently.pressure;
      current.getSetOzone = (float)weatherData.currently.ozone;

      try
      {
        current.getSetAlertTitle = (string)weatherData.alerts[0].title;
        current.getSetAlertTime = (string)weatherData.alerts[0].time;
        current.getSetAlertExpire = (string)weatherData.alerts[0].expires;
        current.getSetAlertDescription = (string)weatherData.alerts[0].description;
        current.getSetAlertURL = (string)weatherData.alerts[0].uri;
      }
      catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
      {
        // This section intentionally blank, this failure is expected and is okay.
      }

      current.Units = (string)weatherData.flags.units;

      forecast[9] = current;
      return forecast;
    }
    }
}
