// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System;
using Windows.UI.Xaml;
using Sensors.Dht;
using Windows.Devices.Gpio;

namespace DhtSensorLibrary
{
    public class EnvironmentDataManager
    {

        private DispatcherTimer _timer;

        private IDht _dhtSensor;

        public event EventHandler<DataItemChangedEventArgs> DataItemChanged;

        public EnvironmentDataManager()
        {
                
        }

        public void AttachFakeSensor(Func<IDht> sensorProvider)
        {
            if (this._dhtSensor != null)
            {
                throw new InvalidOperationException("Envirmoent Data Manageer has already a sensor attached");
            }
            _dhtSensor = sensorProvider();
        }

        public void AttachSensorDht11()
        {
            if (this._dhtSensor !=null)
            {
                throw new InvalidOperationException("Envirmoent Data Manageer has already a sensor attached");
            }
            _dhtSensor = new Dht11(GpioController.GetDefault().OpenPin(4, GpioSharingMode.Exclusive), GpioPinDriveMode.Input);
        }

        public void AttachSensorDht22()
        {
            if (this._dhtSensor != null)
            {
                throw new InvalidOperationException("Enviroment Data Manager has already a sensor attached");
            }
            _dhtSensor = new Dht22(GpioController.GetDefault().OpenPin(4, GpioSharingMode.Exclusive), GpioPinDriveMode.Input);
        }

        public void StopReading()
        {
            _timer.Stop();

            var disposableSensor = (IDisposable)_dhtSensor;
            disposableSensor.Dispose();
            disposableSensor = null;

        }

        public void StartReading()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(20);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private async void _timer_Tick(object sender, object e)
        {
            DhtReading reading = new DhtReading();

            if (_dhtSensor !=null)
            {
                reading = await _dhtSensor.GetReadingAsync(30).AsTask();

                if (reading.IsValid)
                {

                    DataItem myItem = new DataItem(0, new Guid(), DateTimeOffset.Now, reading.Temperature, reading.Humidity);

                    this.OnDataItemChanged(myItem);
                }
            }
            
        }

        private void OnDataItemChanged(DataItem item)
        {
            var handler = this.DataItemChanged as EventHandler<DataItemChangedEventArgs>;
            if (handler!=null)
            {
                handler(this, new DataItemChangedEventArgs(item));
            }
        }
    }
}
