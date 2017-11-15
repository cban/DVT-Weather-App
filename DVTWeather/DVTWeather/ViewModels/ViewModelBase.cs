using DVTWeather.Services;
using DVTWeather.Services.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DVTWeather.ViewModels
{
   public class ViewModelBase : BindableObject
    {
        protected readonly IDialogService DialogService;

        protected readonly INavigationService NavigationService;

        private const string MODELBASE_ERRORS_KEY = "ModelBaseErrors";


        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase()
        {
        
                DialogService = ViewModelLocator.Resolve<IDialogService>();
        
        //    NavigationService = ViewModelLocator.Resolve<INavigationService>();

        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
