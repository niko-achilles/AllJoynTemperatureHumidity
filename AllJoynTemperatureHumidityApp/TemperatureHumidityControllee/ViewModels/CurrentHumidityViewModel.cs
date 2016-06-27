// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using DhtSensorLibrary;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Input;
using TemperatureHumidityControllee.Controllees;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class CurrentHumidityViewModel : ViewModelBase
    {
        public CurrentHumidityControllee CurrentHumidityControllee
        {
            private set;
            get;
        }

        public CurrentHumidity CurrentHumidityModel
        {
            get;
            private set;
        }

        private INavigationService _navigationService;

        public CurrentHumidityViewModel(CurrentHumidityControllee currentHumidityControllee,
                                            CurrentHumidity currentHumidityModel)
        {
            if (currentHumidityControllee == null && currentHumidityModel == null)
            {
                throw new ArgumentNullException("CurrentHumidityViewModel is depended from CurrentHumidityControllee, CurrentHumidity-Model. Values are null");
            }
            this.CurrentHumidityControllee = currentHumidityControllee;
            this.CurrentHumidityModel = currentHumidityModel;

            this._navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            if (IsInDesignMode)
            {
                //
            }

            this._environmentDataManager = ServiceLocator.Current.GetInstance<EnvironmentDataManager>();
            this._environmentDataManager.DataItemChanged += OnSensorDataItemChanged;

        }

        private void OnSensorDataItemChanged(object sender, DataItemChangedEventArgs e)
        {
            this.CurrentHumidityModel.CurrentValue = (byte)e.Item.humidity;
        }

        private ICommand _startProducerCommand;
        public ICommand StartProducer
        {
            get
            {
                return _startProducerCommand ?? new RelayCommand(() =>
                {
                    this.CurrentHumidityControllee.StartCurrentHumidityProducer();
                });
            }
        }

        private ICommand _stopProducer;
        public ICommand StopProducer
        {
            get
            {
                return _stopProducer ?? new RelayCommand(() =>
                {
                    this.CurrentHumidityControllee.StopCurrentHumidityProducer();
                });
            }
        }

        private ICommand _goBackCommand;
        private EnvironmentDataManager _environmentDataManager;

        public ICommand GoBackCommand
        {
            get
            {
                return _goBackCommand ?? (_goBackCommand = new RelayCommand(
                    () =>
                    {
                        this._navigationService.GoBack();
                    }));
            }
        }
    }
}
