using Autofac;

using DVTWeather.Services;
using DVTWeather.Services.Dialog;
using DVTWeather.Services.RequestProvider;
using DVTWeather.Views;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DVTWeather.ViewModels
{
        public static class ViewModelLocator
        {
            private static IContainer _container;

            public static readonly BindableProperty AutoWireViewModelProperty =
                BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

            public static bool GetAutoWireViewModel(BindableObject bindable)
            {
                return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
            }

            public static void SetAutoWireViewModel(BindableObject bindable, bool value)
            {
                bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
            }

           // public static bool UseMockService { get; set; }

           


            public static void RegisterDependencies()
            {

                var builder = new ContainerBuilder();
            //View
      
            // View models
            builder.RegisterType<MainViewModel>();

            // Services
            builder.RegisterType<RequestProvider>().As<IRequestProvider>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance();
            builder.RegisterInstance(CrossGeolocator.Current).As<IGeolocator>().SingleInstance();





            if (_container != null)
                {
                    _container.Dispose();
                }
                _container = builder.Build();
            }

            public static T Resolve<T>()
            {
                return _container.Resolve<T>();
            }

            private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
            {
                var view = bindable as Element;
                if (view == null)
                {
                    return;
                }

                var viewType = view.GetType();
                var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
                var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

                var viewModelType = Type.GetType(viewModelName);
                if (viewModelType == null)
                {
                    return;
                }
             
            }


        // a method to create a page ,since we will not be using the navigation service this is a specialized method create the only page for the app 

        public static Page CreatePage<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModelType = typeof(TViewModel);

            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            Type pageType = Type.GetType(viewAssemblyName);

            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;

            var viewModel = _container.Resolve<TViewModel>();

            page.BindingContext = viewModel;

            return page;
        }
    }
}
 
