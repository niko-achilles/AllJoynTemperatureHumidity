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
    public static class AllJoynBusAttachmentFactory
    {
        public static T CreateAllJoynBusAttachment<T>(IAboutData aboutData, Func<AllJoynBusAttachment> attachmentProvider) where T:IConfigureAllJoynBusAttachment
        {

            T instance = Activator.CreateInstance<T>();
            instance.AllJoynBusAttachment = attachmentProvider();
            instance.ConfigureAllJoynBusAttachment(aboutData);

            return instance;
        }
    }
}
