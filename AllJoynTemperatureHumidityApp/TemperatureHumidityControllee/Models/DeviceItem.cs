using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureHumidityControllee.Controllees.Helpers;
using Windows.Devices.AllJoyn;

namespace TemperatureHumidityControllee.Models
{
    public class DeviceItem
    { 
        public string DeviceName { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }

        public AllJoynAboutData AboutData;

        public DeviceItem(AllJoynAboutData aboutData)
        {
            this.AboutData = aboutData;

            DeviceName = aboutData.DefaultAppName;
            Manufacturer = aboutData.DefaultManufacturer;
            ModelNumber = aboutData.ModelNumber;

        }
    }
}
