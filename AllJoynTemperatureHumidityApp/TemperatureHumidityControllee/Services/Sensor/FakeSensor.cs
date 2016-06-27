// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using Sensors.Dht;
using System;
using System.Threading.Tasks;
using Windows.Foundation;

namespace TemperatureHumidityControllee.Services.Sensor
{
    public class FakeSensor : IDht, IDisposable
    {
        public void Dispose()
        {
            //Do Nothing
        }

        public IAsyncOperation<DhtReading> GetReadingAsync()
        {
            var task = new Task<DhtReading>(()=>
            {
                Random random = new Random();

                DhtReading reading = new DhtReading();
                reading.Humidity = (double)random.Next();
                reading.Temperature = (double)random.Next();

                return reading;
            });
            task.Start();
            return task.AsAsyncOperation();
        }

        public IAsyncOperation<DhtReading> GetReadingAsync(int maxRetries)
        {
            var task = new Task<DhtReading>(() =>
            {
                Random random = new Random();

                DhtReading reading = new DhtReading();
                reading.Humidity = (double)random.Next();
                reading.Temperature = (double)random.Next();
                reading.IsValid = true;
                return reading;
            });
            task.Start();
            return task.AsAsyncOperation();
        }
    }
}
