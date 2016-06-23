// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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

        public INavigationService NavigationService { get; set; }

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

        private RelayCommand<DeviceItem> _showDetailsCommand;
        public RelayCommand<DeviceItem> ShowDetailsCommand
        {
            get
            {
                return _showDetailsCommand ?? (_showDetailsCommand = new RelayCommand<DeviceItem>(
                    (deviceItem)=>
                    {
                        if (!ShowDetailsCommand.CanExecute(deviceItem))
                        {
                            return;
                        }

                        else if (deviceItem.AboutData.DefaultAppName.Contains("Temperature"))
                        {
                            NavigationService.NavigateTo("CurrentTemperaturePage");
                        }
                        else if(deviceItem.AboutData.DefaultAppName.Contains("Humidity"))
                        {
                            NavigationService.NavigateTo("CurrentHumidityPage");
                        }
                    },deviceItem => deviceItem!=null));
            }
        }
    }
}
