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
    public class CurrentTemperatureBusAttachment
    {
        private Func<IAboutData> _aboutDataProvider;
        private Func<AllJoynBusAttachment> _ajBusAttachmentProvider;

        public CurrentTemperatureBusAttachment(Func<IAboutData> ajAboutDataProvider, 
                                                Func<AllJoynBusAttachment> ajBusAttachmentProvider)
        {
            this._aboutDataProvider = ajAboutDataProvider;
            this._ajBusAttachmentProvider = ajBusAttachmentProvider; 
        }

        public AllJoynBusAttachment GetAllJoynBusAttachment()
        {
            var aboutData = this._aboutDataProvider();
            var busAttachment = this._ajBusAttachmentProvider();

            busAttachment.AboutData.AppId = aboutData.AppId;
            busAttachment.AboutData.DefaultAppName = aboutData.DefaultAppName;
            busAttachment.AboutData.DefaultManufacturer = aboutData.DefaultManufacturer;
            busAttachment.AboutData.ModelNumber = aboutData.ModelNumber;
            busAttachment.AboutData.DefaultDescription = aboutData.DefaultDescription;
            busAttachment.AboutData.SoftwareVersion = aboutData.SoftwareVersion;

            return busAttachment;

        }
    }
}
