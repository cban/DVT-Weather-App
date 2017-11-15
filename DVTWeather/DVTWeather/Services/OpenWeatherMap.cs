using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Services
{
  
        public class OpenWeatherMap<T>
        {

            private const string OpenWeatherApi = "http://api.openweathermap.org/data/2.5/weather?q=";
            private const string Key = "216af9a38f3b3936c7a2f3ccf87c330a";
            HttpClient httpClient = new HttpClient();

            public async Task<T> GetAllWeathers(string city)
            {
                var json = await httpClient.GetStringAsync(OpenWeatherApi + city + "&APPID=" + Key);
                var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
                return getWeatherModels;
            }
        }
   
}
