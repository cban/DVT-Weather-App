using DVTWeather.Models;
using DVTWeather.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Services
{
    public class WeatherService:IWeatherService
    {
        private readonly IRequestProvider _requestProvider;
        private const string OpenWeatherApi ="http://api.openweathermap.org/data/2.5/weather?q=";
        private const string Key = "216af9a38f3b3936c7a2f3ccf87c330a";
        public WeatherService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }


        public async Task<WeatherRoot> GetWeatherDetailsAsync(double latitude, double longitude)
        {
            var url = OpenWeatherApi + "&lat=" + latitude + "&lon=" + longitude + "&APPID=" + Key+ "&units=metric";

            return await _requestProvider.GetAsync<WeatherRoot>(url);
           
        }
    }
}
