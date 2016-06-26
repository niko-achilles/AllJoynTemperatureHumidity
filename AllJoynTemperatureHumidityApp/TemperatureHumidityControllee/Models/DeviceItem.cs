// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using TemperatureHumidityControllee.Controllees.Helpers;
using Windows.Devices.AllJoyn;

namespace TemperatureHumidityControllee.Models
{
    public class DeviceItem
    { 
        public string DeviceName { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }

        public IAboutData AboutData;

        public DeviceItem(IAboutData aboutData)
        {
            this.AboutData = aboutData;

            DeviceName = aboutData.DefaultAppName;
            Manufacturer = aboutData.DefaultManufacturer;
            ModelNumber = aboutData.ModelNumber;

        }
    }
}
