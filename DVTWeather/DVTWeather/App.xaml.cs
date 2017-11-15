using DVTWeather.Services;
using DVTWeather.ViewModels;
using DVTWeather.Views;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DVTWeather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApplication();

          //  InitNavigation();
          

        }

        private Task InitNavigation()
        {
          ViewModelLocator.RegisterDependencies();
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
         
        }

        private Task InitializeApplication()
        {

            ViewModelLocator.RegisterDependencies();

            var page = ViewModelLocator.CreatePage<MainViewModel>();

            MainPage = new CustomNavigationView(page);

            return  (page.BindingContext as MainViewModel).InitializeAsync(null);
        }

        

        protected override async void OnStart()
        {

            // Handle when your app starts
            //MobileCenter.Start("android=9ae6432d-185f-4f92-ace8-ad0d28ae623e;" +
            //   "uwp=b7faaafc-df69-49f5-b15f-4d2d9fefb23e;" +
            //   "ios=d896a59d-59ac-4587-acbf-01a2effb5d91;",
            //   typeof(Analytics), typeof(Crashes));

            MobileCenter.Start("android=1ee61f71-362b-44d6-a540-dadd0033c9e7;" + 
                "uwp={Your UWP App secret here};" 
                +"ios=a5da48ff-05af-4143-9034-ed57f623edd7",
                   typeof(Analytics), typeof(Crashes));
        }

    

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
