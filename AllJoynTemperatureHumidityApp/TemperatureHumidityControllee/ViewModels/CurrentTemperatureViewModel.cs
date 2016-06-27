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
    public class CurrentTemperatureViewModel:ViewModelBase
    {
        private EnvironmentDataManager _environmentDataManager;

        public CurrentTemperatureControllee CurrentTemepratureControllee
        {
            get;
            private set;
        }

        public CurrentTemperature CurrentTemepratureModel
        {
            get;
            private set;
        }

        private INavigationService _navigationService;

        public CurrentTemperatureViewModel(CurrentTemperatureControllee currentTemperatureControllee, 
                                            CurrentTemperature currentTemperatureModel)
        {
            if (currentTemperatureControllee==null && currentTemperatureModel==null)
            {
                throw new ArgumentNullException("CurrentTemperatureViewModel is depended from CurrentTemperatureControllee, CurrentTemperature-Model. Values are null");
            }
            this.CurrentTemepratureControllee = currentTemperatureControllee;
            this.CurrentTemepratureModel = currentTemperatureModel;

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
            this.CurrentTemepratureModel.CurrentValue = e.Item.temperature;
        }

        private ICommand _startProducerCommand;
        public ICommand StartProducer
        {
            get
            {
                return _startProducerCommand ?? new RelayCommand(()=>
                {
                    this.CurrentTemepratureControllee.StartCurrentTemperatureProducer();
                }); 
            }
        }

        private ICommand _stopProducer;
        public ICommand StopProducer
        {
            get
            {
                return _stopProducer ?? new RelayCommand(()=> 
                {
                    this.CurrentTemepratureControllee.StopCurrentTemperatureProducer();
                });
            }
        }

        private ICommand _goBackCommand;
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
