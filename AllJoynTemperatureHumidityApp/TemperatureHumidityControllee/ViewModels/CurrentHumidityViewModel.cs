// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using TemperatureHumidityControllee.Controllees;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class CurrentHumidityViewModel : ViewModelBase
    {
        private CurrentHumidityControllee _currentHumidityControllee;
        public CurrentHumidityControllee CurrentHumidityControllee
        {
            get
            {
                return _currentHumidityControllee;
            }
        }

        public CurrentHumidity CurrentHumidityModel
        {
            get;
            private set;
        }

        public CurrentHumidityViewModel(CurrentHumidityControllee currentHumidityControllee,
                                            CurrentHumidity currentHumidityModel)
        {
            if (currentHumidityControllee == null && currentHumidityModel == null)
            {
                throw new ArgumentNullException("CurrentHumidityViewModel is depended from CurrentHumidityControllee, CurrentHumidity-Model. Values are null");
            }
            this._currentHumidityControllee = currentHumidityControllee;
            this.CurrentHumidityModel = currentHumidityModel;
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
    }
}
