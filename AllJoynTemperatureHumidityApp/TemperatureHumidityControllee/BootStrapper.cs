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
                    return container.Resolve<CurrentTemperatureViewModel>();
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
                    return container.Resolve<MainViewModel>();
                }
                else
                {
                    return new MainViewModel(null);
                }
            }
        }

        //TODO HumidityViewModel

        public BootStrapper()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<CurrentTemperature>().SingleInstance();
            builder.RegisterType<CurrentTemperatureService>().As<ICurrentTemperatureService>();

            Func<IAboutData> ajCurrentTemperatureAboutData = () =>
            {
                return new AllJoynAboutDataBuilder(new CurrentTemperatureAboutData())
                  .WithAppId(new Guid())
                  .WithDefaultAppName("Current Temperature App")
                  .WithDefaultDescription("This app provides capability to represent current temperature.")
                  .WithDefaultManufacturer("Niko & Wido Corp. ")
                  .WithModelNumber("12345")
                  .WithSoftwareVersion(AppVersion.GetAppVersion())
                  .Build();
            };

            builder.RegisterInstance(ajCurrentTemperatureAboutData);

            builder.RegisterType<AllJoynBusAttachment>().AsSelf();

            builder.RegisterType<CurrentTemperatureBusAttachment>().AsSelf();

            builder.RegisterType<CurrentTemperatureControllee>().AsSelf();
            builder.RegisterType<CurrentTemperatureViewModel>().AsSelf();

            builder.RegisterType<MainViewModel>().AsSelf();

            this.container = builder.Build();
        }

    }

    
}
