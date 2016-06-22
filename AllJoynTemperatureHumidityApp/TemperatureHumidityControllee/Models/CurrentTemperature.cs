using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureHumidityControllee.Models
{
    public class CurrentTemperature:ObservableObject
    {
        private System.Double _currentValue;
        public System.Double CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                if (_currentValue!=value)
                {
                    _currentValue = value;
                    RaisePropertyChanged(()=>CurrentValue);
                    Messenger.Default.Send(nameof(CurrentValue));
                }
            }
        }

        private System.Double _precision;
        public System.Double Precision
        {
            get
            {
                return _precision;
            }
            set
            {
                if (_precision!=value)
                {
                    _precision = value;
                    RaisePropertyChanged(()=>Precision);
                    Messenger.Default.Send(nameof(Precision));
                }
            }
        }

        private System.UInt16 _updateMinTime;
        public System.UInt16 UpdateMinTime
        {
            get
            {
                return _updateMinTime;
            }
            set
            {
                if (_updateMinTime !=value)
                {
                    _updateMinTime = value;
                    RaisePropertyChanged(() => UpdateMinTime);
                    Messenger.Default.Send(nameof(UpdateMinTime));
                }
            }
        }

        private System.UInt16 _version;
        public System.UInt16 Version
        {
            get
            {
                return _version;
            }
            set
            {
                if (_version != value)
                {
                    _version = value;
                    RaisePropertyChanged(()=>Version);
                    Messenger.Default.Send(nameof(Version));
                }
            }
        }

    }
}
