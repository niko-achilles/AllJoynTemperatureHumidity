// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System.Collections.ObjectModel;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class MainViewModel
    {
        public CurrentTemperatureViewModel CurrentTemperatureViewModel { get; private set; }
        public CurrentHumidityViewModel CurrentHumidityViewModel { get; private set; }

        public ObservableCollection<DeviceItem> Items
        {
            private set;
            get;
        }

        public MainViewModel(CurrentTemperatureViewModel currentTemperatureViewModel, CurrentHumidityViewModel currentHumidityViewModel)
        {
            if (currentTemperatureViewModel == null && currentHumidityViewModel==null)
            {
                throw new System.ArgumentNullException("MainViewModel depens on CurrentTemperatureViewModel and CurrentHumidityViewModel");
            }
            this.CurrentTemperatureViewModel = currentTemperatureViewModel;
            this.CurrentHumidityViewModel = currentHumidityViewModel;

            Items = new ObservableCollection<DeviceItem>()
            {
                new DeviceItem(
                    this.CurrentTemperatureViewModel.CurrentTemepratureControllee.CurrentTemperatureBusAttachment.AboutData),
                new DeviceItem(
                    this.CurrentHumidityViewModel.CurrentHumidityControllee.CurrentHumidityBusAttachment.AboutData)
            };
           
            
        }
    }
}
