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
using System;
using System.Windows.Input;
using TemperatureHumidityControllee.Controllees;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class CurrentHumidityViewModel : ViewModelBase
    {
        private CurrentHumidityControllee _currentHumidityControllee;

        public CurrentHumidity CurrentHumidityModel
        {
            get;
            private set;
        }

        public INavigationService _navigationService;

        public CurrentHumidityViewModel(CurrentHumidityControllee currentHumidityControllee,
                                            CurrentHumidity currentHumidityModel)
        {
            if (currentHumidityControllee == null && currentHumidityModel == null)
            {
                throw new ArgumentNullException("CurrentHumidityViewModel is depended from CurrentHumidityControllee, CurrentHumidity-Model. Values are null");
            }
            this._currentHumidityControllee = currentHumidityControllee;
            this.CurrentHumidityModel = currentHumidityModel;

            this._navigationService = ServiceLocator.Current.GetInstance<INavigationService>();

            if (IsInDesignMode)
            {
                //
            }
        }

        private ICommand _startProducerCommand;
        public ICommand StartProducer
        {
            get
            {
                return _startProducerCommand ?? new RelayCommand(() =>
                {
                    this._currentHumidityControllee.StartCurrentHumidityProducer();
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
                    this._currentHumidityControllee.StopCurrentHumidityProducer();
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
