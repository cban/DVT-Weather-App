using DVTWeather.Models;
using DVTWeather.Services;
using DVTWeather.Services.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator.Abstractions;
using System.Globalization;

namespace DVTWeather.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IWeatherService _weatherService;
        private readonly IGeolocator _geolocatorService;

 
        public MainViewModel(IGeolocator geolocatorService,IWeatherService weatherService)
        {
            _geolocatorService = geolocatorService;
            _weatherService = weatherService;
        }



        // for weather icon image string binding

        private string _iconImageString; 
        public string IconImageString
        {
            get { return _iconImageString; }
            set
            {
                _iconImageString = value;
                OnPropertyChanged();
            }
        }

        private string _date;
        public string Date
        {

            get
            {

                return _date;
            }

            set
            {
                _date = value;

                OnPropertyChanged();
            }
        }

   


     
        private string _area;

        public string Area
        {
            get
            {
                return _area;
            }

            set
            {
                _area = value;

                OnPropertyChanged();
            }
        }

        private string _maxtemp;
        public string MaxWeatherDescription
        {
            get
            {
                return _maxtemp;
            }

            set
            {
                _maxtemp = value;

                OnPropertyChanged();
            }
        }


        private string _mintemp;
        public string MinWeatherDescription
        {
            get
            {
                return _mintemp;
            }

            set
            {
                _mintemp = value;

                OnPropertyChanged();
            }
        }
        public override async Task InitializeAsync(object navigationData)
        {
            // Set the UI property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
            IsBusy = true;

            try
            {

                if (_geolocatorService.IsGeolocationEnabled && _geolocatorService.IsGeolocationAvailable)
                {
                    var currentPosition = await _geolocatorService.GetPositionAsync();

                    var weather = await _weatherService.GetWeatherDetailsAsync(currentPosition.Latitude, currentPosition.Longitude);


                    //Retrieve the Current 
                    Date = "TODAY, " + DateTime.Today.ToString("dd MMMM yyyy").ToUpper();

                   // fetch weather icon image
                    IconImageString = "http://openweathermap.org/img/w/" + weather.WeatherDetail[0].Icon + ".png";
                    
                    MaxWeatherDescription = $"max {weather.MainWeather.MaxTemperature}°C";
                    MinWeatherDescription = $"min {weather.MainWeather.MinTemperature}°C";

                    //Fetch the name of the area and the country,convert the country to its full name
                    Area = weather.Area + "," + new RegionInfo(weather.Sys.Country).EnglishName;
                }

                else
                {
                    await DialogService.ShowAlertAsync("GPS is not enabled", "GPS DISABLED", "OK");
                }

            }
            catch (Exception ex)
            {
                await DialogService.ShowAlertAsync("Unable to get weather information.", "ERROR", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
          
    }
}

