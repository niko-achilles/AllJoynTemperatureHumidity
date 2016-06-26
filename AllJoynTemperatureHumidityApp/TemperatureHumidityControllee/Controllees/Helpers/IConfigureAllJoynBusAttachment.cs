using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.AllJoyn;

namespace TemperatureHumidityControllee.Controllees.Helpers
{
    public interface IConfigureAllJoynBusAttachment
    {
        AllJoynBusAttachment AllJoynBusAttachment { get;  set; }

        void ConfigureAllJoynBusAttachment(IAboutData aboutData);
    }
}
