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
using DhtSensorLibrary;
using System.Windows.Input;

namespace TemperatureHumidityControllee.ViewModels
{
    public class MainViewModel:ViewModelBase
    {

        public CurrentTemperatureViewModel CurrentTemperatureViewModel { get; set; }
        public CurrentHumidityViewModel CurrentHumidityViewModel { get; set; }

        public ObservableCollection<DeviceItem> Items
        {
            private set;
            get;
        }

        public EnvironmentDataManager _environmentDataManager; 

        private INavigationService _navigationService;

        public MainViewModel(INavigationService navService)
        {

            if (navService == null)
            {
                throw new System.ArgumentNullException("MainViewModel needs a navigation Service");
            }

            this._navigationService = navService;

            this._environmentDataManager = ServiceLocator.Current.GetInstance<EnvironmentDataManager>();

            this.CurrentHumidityViewModel = ServiceLocator.Current.GetInstance<CurrentHumidityViewModel>();
            this.CurrentTemperatureViewModel = ServiceLocator.Current.GetInstance<CurrentTemperatureViewModel>();

            Items = new ObservableCollection<DeviceItem> {
            new DeviceItem(this.CurrentTemperatureViewModel.CurrentTemepratureControllee.CurrentTemperatureBusAttachment.AboutData),
            new DeviceItem(this.CurrentHumidityViewModel.CurrentHumidityControllee.CurrentHumidityBusAttachment.AboutData)
            };


            if (IsInDesignMode)
            {
                //
            }
        }

        private RelayCommand _startReadingCommand;
        public RelayCommand StartReadingCommand
        {
            get
            {
                return _startReadingCommand ?? (_startReadingCommand = new RelayCommand(() => 
                {
                    this._environmentDataManager.StartReading();
                }));
            }
        }

        private RelayCommand _stopReadingCommand;
        public RelayCommand StopReadingCommand
        {
            get
            {
                return _stopReadingCommand ?? (_stopReadingCommand = new RelayCommand(() =>
                {
                    this._environmentDataManager.StopReading();
                }));
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
