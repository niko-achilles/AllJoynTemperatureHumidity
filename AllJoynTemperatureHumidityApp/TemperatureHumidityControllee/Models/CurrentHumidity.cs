using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureHumidityControllee.Models
{
    class CurrentHumidity:ObservableObject
    {

        public System.UInt16 Version { get; set; }

        public System.Byte CurrentValue { get; set; }

        public System.Byte MaxValue { get; set; }
    }
}
