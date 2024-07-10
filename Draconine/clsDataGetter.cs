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
    const string API_KEY = Credentials.ApiKey;

    clsForecast current = new clsForecast();
    float flat = 0;
    float flon = 0;
    string lat = "";
    string lon = "";

    WebClient wcLatLon = new WebClient();

    public void getLatLon()
    {
      //var data = wcLatLon.DownloadString("http://ip-api.com/json");
      var data = wcLatLon.DownloadString("http://ipwho.is/");
      JObject o = JObject.Parse(data);
      lat = o["latitude"].ToString();
      lon = o["longitude"].ToString();
      flat = float.Parse(lat, CultureInfo.InvariantCulture.NumberFormat);
      flon = float.Parse(lon, CultureInfo.InvariantCulture.NumberFormat);
    }

    public clsForecast[] getForecast(clsForecast[] forecast)
    {
      // API Key, Lat, Long, Unit

      //string url = "https://api.forecast.io/forecast/" + API_KEY + "/" + flat + "," + flon;
      //string url = "https://api.openweathermap.org/data/2.5/weather?lat=" + flat + "&lon=" + flon + "&appid=" + API_KEY + "&units=imperial";
      //var request = new ForecastIORequest(API_KEY, flat, flon, Unit.auto);
      //var response = new WebClient().DownloadData(url);
      UTF32Encoding utf32 = new UTF32Encoding();
            //byte[] utf32Array = Encoding.Convert(Encoding.UTF8, Encoding.UTF32, response);
            //string finalString = utf32.GetString(utf32Array);
            //dynamic weatherData = JObject.Parse(finalString.ToString());

            // Current Forecast
            //string current_url = "https://api.openweathermap.org/data/2.5/weather?lat=" + flat + "&lon=" + flon + "&appid=" + API_KEY + "&units=imperial";
            string current_url = "https://api.pirateweather.net/forecast/" + API_KEY + "/" + flat + "," + flon;

      var current_response = new WebClient().DownloadData(current_url);
      byte[] current_utf32Array = Encoding.Convert(Encoding.UTF8, Encoding.UTF32, current_response);
      string current_String = utf32.GetString(current_utf32Array);
      dynamic current_Data = JObject.Parse(current_String.ToString());

      current.getSetDate = (string)current_Data.currently.time;
      current.getSetLongDate = (string)current_Data.currently.time;
      current.getSetDay = (string)current_Data.currently.time;
      current.getSetSummary = (string)current_Data.currently.summary;
      current.setIcon((string)current_Data.currently.icon);
      current.getSetTemp = (float)current_Data.currently.temperature;
      current.getSetFeelsLike = (float)current_Data.currently.apparentTemperature;
      current.getSetHumidity = (float)current_Data.currently.humidity;
      current.getSetWindSpeed = (float)current_Data.currently.windSpeed;
      current.getSetWindBearing = (int)current_Data.currently.windBearing;
      current.getSetVisibility = (int)current_Data.currently.visibility;
      current.getSetCloudCover = (float)current_Data.currently.cloudCover;
      current.getSetPressure = (float)current_Data.currently.pressure;
      current.getSetDewPoint = (float)current_Data.currently.dewPoint;
      current.getSetOzone = (float)current_Data.currently.ozone;

      // TODO: OpenWeatherMap splits precipitation out between snow and rain.
      //       Need to handle them in try/catch blocks
      current.getSetPrecipIntensity = (float)current_Data.currently.precipIntensity;
      current.getSetPrecipProbability = (float)current_Data.currently.precipProbability;
      current.getSetPrecipType = (string)current_Data.currently.precipType;

      // Future Forecast
      /*string future_url = "https://api.openweathermap.org/data/2.5/forecast?lat=" + flat + "&lon=" + flon + "&appid=" + API_KEY + "&units=imperial";
      var future_response = new WebClient().DownloadData(future_url);
      byte[] future_utf32Array = Encoding.Convert(Encoding.UTF8, Encoding.UTF32, future_response);
      string future_String = utf32.GetString(future_utf32Array);
      dynamic future_Data = JObject.Parse(future_String.ToString());*/
      for (int i = 0; i < 7; i++)
            {
              clsForecast tempForecast = new clsForecast();
              tempForecast.getSetDate = (string)current_Data.daily.data[i].time.ToString();
              tempForecast.getSetLongDate = (string)current_Data.daily.data[i].time.ToString();
              tempForecast.getSetDay = (string)current_Data.daily.data[i].time;
              tempForecast.getSetSummary = (string)current_Data.daily.data[i].summary;
              tempForecast.setIcon((string)current_Data.daily.data[i].icon);
              tempForecast.getSetSunrise = (string)current_Data.daily.data[i].sunriseTime.ToString();
              tempForecast.getSetSunset = (string)current_Data.daily.data[i].sunsetTime.ToString();
              tempForecast.setMoonPhase((float)current_Data.daily.data[i].moonPhase);
              tempForecast.getSetPrecipIntensity = (float)current_Data.daily.data[i].precipIntensity;
              tempForecast.getSetPrecipIntensityMax = (float)current_Data.daily.data[i].precipIntensityMax;
              tempForecast.getSetPrecipProbability = (float)current_Data.daily.data[i].precipProbability;
              tempForecast.getSetPrecipType = (string)current_Data.daily.data[i].precipType;
              tempForecast.getSetLow = (float)current_Data.daily.data[i].temperatureMin;
              tempForecast.getSetLowTime = (string)current_Data.daily.data[i].temperatureMinTime.ToString();
              tempForecast.getSetHigh = (float)current_Data.daily.data[i].temperatureMax;
              tempForecast.getSetHighTime = (string)current_Data.daily.data[i].temperatureMaxTime.ToString();
              tempForecast.getSetFeelsLow = (float)current_Data.daily.data[i].apparentTemperatureMin;
              tempForecast.getSetFeelsLowTime = (string)current_Data.daily.data[i].apparentTemperatureMinTime.ToString();
              tempForecast.getSetFeelsHigh = (float)current_Data.daily.data[i].apparentTemperatureMax;
              tempForecast.getSetFeelsHighTime = (string)current_Data.daily.data[i].apparentTemperatureMaxTime.ToString();
              tempForecast.getSetDewPoint = (float)current_Data.daily.data[i].dewPoint;
              tempForecast.getSetHumidity = (float)current_Data.daily.data[i].humidity;
              tempForecast.getSetWindSpeed = (float)current_Data.daily.data[i].windSpeed;

              if (current_Data.daily.data[i].windBearing == null)
              {
                tempForecast.getSetWindBearing = 0;
              }
              else
              {
                tempForecast.getSetWindBearing = (int)current_Data.daily.data[i].windBearing;
              }

              if (current_Data.daily.data[i].visibility == null)
              {
                tempForecast.getSetVisibility = 11;
              }
              else
              {
                tempForecast.getSetVisibility = (float)current_Data.daily.data[i].visibility;
              }
              tempForecast.getSetCloudCover = (float)current_Data.daily.data[i].cloudCover;
              tempForecast.getSetPressure = (float)current_Data.daily.data[i].pressure;
              //tempForecast.getSetOzone = (float)current_Data.daily.data[i].ozone;

              tempForecast.Units = (string)current_Data.flags.units;

              forecast[i] = tempForecast;
            }

            try
            {
                current.getSetAlertTitle = (string)current_Data.alerts[0].title;
                current.getSetAlertTime = (string)current_Data.alerts[0].time;
                current.getSetAlertExpire = (string)current_Data.alerts[0].expires;
                current.getSetAlertDescription = (string)current_Data.alerts[0].description;
                current.getSetAlertURL = (string)current_Data.alerts[0].uri;
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException)
            {
                // This section intentionally blank, this failure is expected and is okay.
            }
            catch (ArgumentOutOfRangeException)
            {
                // This section intentionally blank, this failure is expected and is okay.
            }

            current.Units = (string)current_Data.flags.units;

      forecast[9] = current;
      return forecast;
    }
    }
}
