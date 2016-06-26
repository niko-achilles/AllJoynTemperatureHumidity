using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
