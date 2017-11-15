using DVTWeather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Services
{
    public interface IWeatherService
    {

      
            Task<WeatherRoot> GetWeatherDetailsAsync(double latitude, double longitude);
   
    }
}
