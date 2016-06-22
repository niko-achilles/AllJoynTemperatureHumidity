// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using org.alljoyn.SmartSpaces.Environment.CurrentHumidity;
using System;
using System.Threading.Tasks;
using TemperatureHumidityControllee.Models;
using Windows.Devices.AllJoyn;
using Windows.Foundation;

namespace TemperatureHumidityControllee.Services
{
    class CurrentHumidityService : ICurrentHumidityService
    {
        private CurrentHumidity _currentHumidity;

        public CurrentHumidityService(CurrentHumidity currentHumidity)
        {
            this._currentHumidity = currentHumidity;
        }

        public IAsyncOperation<CurrentHumidityGetCurrentValueResult> GetCurrentValueAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentHumidityGetCurrentValueResult>(() =>
            {
                return CurrentHumidityGetCurrentValueResult.CreateSuccessResult(this._currentHumidity.CurrentValue);
            });

            task.Start();

            return task.AsAsyncOperation();
        }

        public IAsyncOperation<CurrentHumidityGetMaxValueResult> GetMaxValueAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentHumidityGetMaxValueResult>(() =>
            {
                return CurrentHumidityGetMaxValueResult.CreateSuccessResult(this._currentHumidity.MaxValue);
            });
            task.Start();
            return task.AsAsyncOperation();
        }

        public IAsyncOperation<CurrentHumidityGetVersionResult> GetVersionAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentHumidityGetVersionResult>(() =>
            {
                return CurrentHumidityGetVersionResult.CreateSuccessResult(this._currentHumidity.Version);
            });
            task.Start();
            return task.AsAsyncOperation();
        }
    }
}
