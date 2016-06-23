// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using org.alljoyn.SmartSpaces.Environment.CurrentTemperature;
using System;
using TemperatureHumidityControllee.Controllees;
using TemperatureHumidityControllee.Controllees.Helpers;
using TemperatureHumidityControllee.Models;
using TemperatureHumidityControllee.Services;
using TemperatureHumidityControllee.ViewModels;
using Windows.Devices.AllJoyn;
using Autofac;
using org.alljoyn.SmartSpaces.Environment.CurrentHumidity;
using GalaSoft.MvvmLight.Views;

namespace TemperatureHumidityControllee
{
    public class BootStrapper
    {
        private IContainer container;

        public CurrentTemperatureViewModel CurrentTemperatureViewModel
        {
            get
            {
                if (this.container != null)
                {
                    var viewmodel = container.Resolve<CurrentTemperatureViewModel>();
                    viewmodel.NavigationService = container.Resolve<INavigationService>();

                    return viewmodel;
                }
                else
                {
                    return new CurrentTemperatureViewModel(null, null);
                }
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                if (this.container != null)
                {
                    var viewmodel = container.Resolve<MainViewModel>();
                    viewmodel.NavigationService = container.Resolve<INavigationService>();
                    return viewmodel;
                }
                else
                {
                    return new MainViewModel(null, null);
                }
            }
        }

        public CurrentHumidityViewModel CurrentHumidityViewModel
        {
            get
            {
                if (this.container != null)
                {
                    var viewmodel = container.Resolve<CurrentHumidityViewModel>();
                    viewmodel.NavigationService = container.Resolve<INavigationService>();
                    return viewmodel;
                }
                else
                {
                    return new CurrentHumidityViewModel(null, null);
                }
            }
        }

        public BootStrapper()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<CurrentTemperature>().SingleInstance();
            builder.RegisterType<CurrentTemperatureService>().As<ICurrentTemperatureService>();

            builder.RegisterType<CurrentHumidity>().SingleInstance();
            builder.RegisterType<CurrentHumidityService>().As<ICurrentHumidityService>();

            Func<CurrentTemperatureAboutData> ajCurrentTemperatureAboutData = () =>
            {
                return new AllJoynAboutDataBuilder(new CurrentTemperatureAboutData())
                  .WithAppId(new Guid())
                  .WithDefaultAppName("Current Temperature App")
                  .WithDefaultDescription("This app provides capability to represent current temperature.")
                  .WithDefaultManufacturer("Niko & Wido Corp. ")
                  .WithModelNumber("12345")
                  .WithSoftwareVersion(AppVersion.GetAppVersion())
                  .Build() as CurrentTemperatureAboutData;
            };

            Func<CurrentHumidityAboutData> ajCurrentHumidityAboutData = () =>
            {
                return new AllJoynAboutDataBuilder(new CurrentHumidityAboutData())
                  .WithAppId(new Guid())
                  .WithDefaultAppName("Current Humidity App")
                  .WithDefaultDescription("This app provides capability to represent current humidity.")
                  .WithDefaultManufacturer("Niko & Wido Corp. ")
                  .WithModelNumber("12345")
                  .WithSoftwareVersion(AppVersion.GetAppVersion())
                  .Build() as CurrentHumidityAboutData;
            };


            builder.RegisterInstance(ajCurrentTemperatureAboutData);
            builder.RegisterInstance(ajCurrentHumidityAboutData);

            builder.RegisterType<AllJoynBusAttachment>().AsSelf();

            builder.RegisterType<CurrentTemperatureBusAttachment>().AsSelf();
            builder.RegisterType<CurrentHumidityBusAttachment>().AsSelf();

            NavigationService nav = new NavigationService();
            nav.Configure("CurrentTemperaturePage", typeof(CurrentTemperaturePage));
            nav.Configure("CurrentHumidityPage", typeof(CurrentHumidityPage));

            builder.RegisterInstance<INavigationService>(nav);

            builder.RegisterType<CurrentTemperatureControllee>().AsSelf();
            builder.RegisterType<CurrentTemperatureViewModel>().AsSelf();

            builder.RegisterType<CurrentHumidityControllee>().AsSelf();
            builder.RegisterType<CurrentHumidityViewModel>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();

            this.container = builder.Build();
        }

    }

    
}
