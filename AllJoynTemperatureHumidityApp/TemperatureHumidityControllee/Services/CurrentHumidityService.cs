using org.alljoyn.SmartSpaces.Environment.CurrentHumidity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.AllJoyn;
using Windows.Foundation;

namespace TemperatureHumidityControllee.Services
{
    class CurrentHumidityService : ICurrentHumidityService
    {
        public IAsyncOperation<CurrentHumidityGetCurrentValueResult> GetCurrentValueAsync(AllJoynMessageInfo info)
        {
            throw new NotImplementedException();
        }

        public IAsyncOperation<CurrentHumidityGetMaxValueResult> GetMaxValueAsync(AllJoynMessageInfo info)
        {
            throw new NotImplementedException();
        }

        public IAsyncOperation<CurrentHumidityGetVersionResult> GetVersionAsync(AllJoynMessageInfo info)
        {
            throw new NotImplementedException();
        }
    }
}
