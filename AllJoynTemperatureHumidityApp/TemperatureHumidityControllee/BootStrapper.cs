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
using org.alljoyn.SmartSpaces.Environment.CurrentHumidity;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight;
using TemperatureHumidityControllee.Design;
using TemperatureHumidityControllee.Views;
using System.Collections.Generic;
using DhtSensorLibrary;
using TemperatureHumidityControllee.Services.Sensor;

namespace TemperatureHumidityControllee
{
    public class BootStrapper
    {

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        static BootStrapper()
        {

            ServiceLocator.SetLocatorProvider(() =>SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<INavigationService, DesignNavigationService>();
                //regiter here other service that provide data and need to be mocked

                var envManager = new EnvironmentDataManager();
                envManager.AttachFakeSensor(() => new FakeSensor());

                SimpleIoc.Default.Register<EnvironmentDataManager>(() => envManager);

            }
            else
            {
                NavigationService nav = new NavigationService();
                nav.Configure("CurrentHumidityPage", typeof(CurrentHumidityPage));
                nav.Configure("CurrentTemperaturePage", typeof(CurrentTemperaturePage));

                SimpleIoc.Default.Register<INavigationService>(() => nav);

                //temporary register the fake sensor
                var envManager = new EnvironmentDataManager();
                envManager.AttachFakeSensor(() => new FakeSensor());

                SimpleIoc.Default.Register<EnvironmentDataManager>(() => envManager);


                //register here the real implementation of service that have been mocked above in the if statement = true
            }

            SimpleIoc.Default.Register<CurrentHumidity>();
            SimpleIoc.Default.Register<ICurrentHumidityService, CurrentHumidityService>();

            SimpleIoc.Default.Register<CurrentTemperature>();
            SimpleIoc.Default.Register<ICurrentTemperatureService, CurrentTemperatureService>();

            Func<IAboutData> ajCurrentTemperatureAboutData = () =>
            {
                return new AllJoynAboutDataBuilder(new CurrentTemperatureAboutData())
                  .WithAppId(new Guid())
                  .WithDefaultAppName("Current Temperature App")
                  .WithDefaultDescription("This app provides capability to represent current temperature.")
                  .WithDefaultManufacturer("Niko & Wido Corp. ")
                  .WithModelNumber("12345")
                  .WithSoftwareVersion(AppVersion.GetAppVersion())
                  .Build() as IAboutData;
            };

            Func<IAboutData> ajCurrentHumidityAboutData = () =>
            {
                return new AllJoynAboutDataBuilder(new CurrentHumidityAboutData())
                  .WithAppId(new Guid())
                  .WithDefaultAppName("Current Humidity App")
                  .WithDefaultDescription("This app provides capability to represent current humidity.")
                  .WithDefaultManufacturer("Niko & Wido Corp. ")
                  .WithModelNumber("12345")
                  .WithSoftwareVersion(AppVersion.GetAppVersion())
                  .Build() as IAboutData;
            };




            SimpleIoc.Default.Register<CurrentTemperatureBusAttachment>(() => AllJoynBusAttachmentFactory
                                                                                .CreateAllJoynBusAttachment<CurrentTemperatureBusAttachment>(ajCurrentTemperatureAboutData(),
                                                                                () => new AllJoynBusAttachment()));

            SimpleIoc.Default.Register<CurrentHumidityBusAttachment>(() => AllJoynBusAttachmentFactory
                                                                                .CreateAllJoynBusAttachment<CurrentHumidityBusAttachment>(ajCurrentHumidityAboutData(),
                                                                                ()=>new AllJoynBusAttachment()));

            SimpleIoc.Default.Register<CurrentTemperatureControllee>();
            SimpleIoc.Default.Register<CurrentHumidityControllee>();


            SimpleIoc.Default.Register<CurrentTemperatureViewModel>();
            SimpleIoc.Default.Register<CurrentHumidityViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();

            

        }

    }

    
}
