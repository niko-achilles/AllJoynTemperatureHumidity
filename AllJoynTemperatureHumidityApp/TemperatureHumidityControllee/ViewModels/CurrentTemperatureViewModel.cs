﻿// ****************************************************************************
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
    public class CurrentTemperatureViewModel:ViewModelBase
    {

        private CurrentTemperatureControllee _currentTemepratureControllee;

        public CurrentTemperature CurrentTemepratureModel
        {
            get;
            private set;
        }

        public INavigationService _navigationService;

        public CurrentTemperatureViewModel(CurrentTemperatureControllee currentTemperatureControllee, 
                                            CurrentTemperature currentTemperatureModel)
        {
            if (currentTemperatureControllee==null && currentTemperatureModel==null)
            {
                throw new ArgumentNullException("CurrentTemperatureViewModel is depended from CurrentTemperatureControllee, CurrentTemperature-Model. Values are null");
            }
            this._currentTemepratureControllee = currentTemperatureControllee;
            this.CurrentTemepratureModel = currentTemperatureModel;

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
                return _startProducerCommand ?? new RelayCommand(()=>
                {
                    this._currentTemepratureControllee.StartCurrentTemperatureProducer();
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
                    this._currentTemepratureControllee.StopCurrentTemperatureProducer();
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
