using DVTWeather.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVTWeather.Services
{
  
        public interface INavigationService
        {
            Task InitializeAsync();
            Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
            Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;
      
            Task RemoveLastFromBackStackAsync(); Task RemoveBackStackAsync();
        }
    
}
