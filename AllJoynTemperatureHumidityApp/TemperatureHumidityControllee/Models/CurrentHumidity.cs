// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace TemperatureHumidityControllee.Models
{
    public class CurrentHumidity:ObservableObject
    {
        private System.UInt16 _version;
        public System.UInt16 Version
        {
            get
            {
                return _version;
            }
            set
            {
                if (_version!=value)
                {
                    _version = value;
                    RaisePropertyChanged(()=>Version);
                    Messenger.Default.Send(nameof(Version));
                }
            }
        }


        private System.Byte _currentValue;
        public System.Byte CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                if (_currentValue != value)
                {
                    _currentValue = value;
                    RaisePropertyChanged(() => CurrentValue);
                    Messenger.Default.Send(nameof(CurrentValue));
                }
            }
        }

        private System.Byte _maxValue;
        public System.Byte MaxValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                if (_maxValue != value)
                {
                    _maxValue = value;
                    RaisePropertyChanged(() => MaxValue);
                    Messenger.Default.Send(nameof(MaxValue));
                }
            }
        }
    }
}
