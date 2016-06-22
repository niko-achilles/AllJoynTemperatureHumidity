// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System;
using System.Threading.Tasks;
using org.alljoyn.SmartSpaces.Environment.CurrentTemperature;
using Windows.Devices.AllJoyn;
using Windows.Foundation;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.Services
{
    class CurrentTemperatureService : ICurrentTemperatureService
    {
        private CurrentTemperature _currentTemperature;

        public CurrentTemperatureService(CurrentTemperature currentTemperature)
        {
            //I think i should have a relationship with a service here to retrieve the value from a local cache
            this._currentTemperature = currentTemperature;
        }

        public IAsyncOperation<CurrentTemperatureGetCurrentValueResult> GetCurrentValueAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentTemperatureGetCurrentValueResult>(() =>
            {
                return CurrentTemperatureGetCurrentValueResult.CreateSuccessResult(this._currentTemperature.CurrentValue); 
            });

            task.Start();

            return task.AsAsyncOperation();
        }

        public IAsyncOperation<CurrentTemperatureGetPrecisionResult> GetPrecisionAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentTemperatureGetPrecisionResult>(() =>
            {
                return CurrentTemperatureGetPrecisionResult.CreateSuccessResult(this._currentTemperature.Precision); 
            });
            task.Start();
            return task.AsAsyncOperation();
        }

        public IAsyncOperation<CurrentTemperatureGetUpdateMinTimeResult> GetUpdateMinTimeAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentTemperatureGetUpdateMinTimeResult>(() =>
            {
                return CurrentTemperatureGetUpdateMinTimeResult.CreateSuccessResult(this._currentTemperature.UpdateMinTime); 
            });
            task.Start();
            return task.AsAsyncOperation();
        }

        public IAsyncOperation<CurrentTemperatureGetVersionResult> GetVersionAsync(AllJoynMessageInfo info)
        {
            var task = new Task<CurrentTemperatureGetVersionResult>(() =>
            {
                return CurrentTemperatureGetVersionResult.CreateSuccessResult(this._currentTemperature.Version); 
            });
            task.Start();
            return task.AsAsyncOperation();
        }
    }
}
