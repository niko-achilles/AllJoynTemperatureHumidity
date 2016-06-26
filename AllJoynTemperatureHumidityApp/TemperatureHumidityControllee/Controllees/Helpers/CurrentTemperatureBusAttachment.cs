// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System;
using Windows.Devices.AllJoyn;

namespace TemperatureHumidityControllee.Controllees.Helpers
{
    public class CurrentTemperatureBusAttachment:IConfigureAllJoynBusAttachment
    {


        public CurrentTemperatureBusAttachment()
        {}

        public AllJoynBusAttachment AllJoynBusAttachment
        {
            get;
            set;
        }

        public void ConfigureAllJoynBusAttachment(IAboutData aboutData)
        {
            if (this.AllJoynBusAttachment == null)
            {
                throw new InvalidOperationException("AllJoynBusAttachment is null");
            }

            AllJoynBusAttachment.AboutData.AppId = aboutData.AppId;
            AllJoynBusAttachment.AboutData.DefaultAppName = aboutData.DefaultAppName;
            AllJoynBusAttachment.AboutData.DefaultManufacturer = aboutData.DefaultManufacturer;
            AllJoynBusAttachment.AboutData.ModelNumber = aboutData.ModelNumber;
            AllJoynBusAttachment.AboutData.DefaultDescription = aboutData.DefaultDescription;
            AllJoynBusAttachment.AboutData.SoftwareVersion = aboutData.SoftwareVersion;
        }
    }
}
