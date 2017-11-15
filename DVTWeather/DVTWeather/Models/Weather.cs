using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Models
{
    public class WeatherRoot
    {

        [JsonProperty("name")]
        public string Area { get; set; }
        public WeatherTempDetails WeatherTemp { get; set; }
  
        [JsonProperty("weather")]
        public Weather[] WeatherDetail { get; set; }

        [JsonProperty("main")]
        public Main MainWeather { get; set; }

        public WeatherSysDetails Sys { get; set; }
    }


    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; } = 0;

        [JsonProperty("main")]
        public string Main { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("icon")]
        public string Icon { get; set; } 
    }

    public class WeatherSubDetails
    {
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class WeatherSysDetails
    {
        [JsonProperty("country")]
        public string Country { get; set; }
    }


    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; } = 0;
        [JsonProperty("pressure")]
        public double Pressure { get; set; } = 0;

        [JsonProperty("humidity")]
        public double Humidity { get; set; } = 0;
        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; } = 0;

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; } = 0;
    }

    public class WeatherTempDetails
    {
        [JsonProperty("temp")]
        public string Temp { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }
    }

}
