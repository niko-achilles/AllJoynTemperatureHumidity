// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TemperatureHumidityControllee.Controllees.Helpers;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class MainViewModel:ViewModelBase
    {

        public ObservableCollection<DeviceItem> Items
        {
            private set;
            get;
        }

        public INavigationService _navigationService;

        public MainViewModel(INavigationService navService)
        {

            if (navService == null)
            {
                throw new System.ArgumentNullException("MainViewModel needs a navigation Service");
            }

            this._navigationService = navService;

           
            Items = new ObservableCollection<DeviceItem>();

            foreach (var item in ServiceLocator.Current.GetAllInstances<IAboutData>())
            {
                Items.Add(new DeviceItem(item));
            }

            if (IsInDesignMode)
            {
                //
            }
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
                            this._navigationService.NavigateTo("CurrentTemperaturePage");
                        }
                        else if(deviceItem.AboutData.DefaultAppName.Contains("Humidity"))
                        {
                            this._navigationService.NavigateTo("CurrentHumidityPage");
                        }
                    },deviceItem => deviceItem!=null));
            }
        }
    }
}
