using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Sensors.Dht;
using Windows.Devices.Gpio;

namespace DhtSensorLibrary
{
    public class EnvironmentDataManager
    {
        private DispatcherTimer _timer = new DispatcherTimer();
        GpioPin _pin4 = null;
        Dht11 _dht1;

        public event EventHandler<DataItemChangedEventArgs> DataItemChanged;
        public EnvironmentDataManager()
        {
            this._pin4 = GpioController.GetDefault().OpenPin(4, GpioSharingMode.Exclusive);
            this._dht1 = new Dht11(_pin4, GpioPinDriveMode.Input);
        }

        public void StopReading()
        {
            _timer.Stop();

            _pin4.Dispose();
            _pin4 = null;

            _dht1 = null;
        }

        public void StartReading()
        {
            _timer.Interval = TimeSpan.FromSeconds(20);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        public int TotalAttempts { get; private set; }
        decimal Temperature;
        decimal Humidity;
        DateTimeOffset LastUpdated;


        private async void _timer_Tick(object sender, object e)
        {
            DhtReading reading = new DhtReading();
            int val = this.TotalAttempts;
            this.TotalAttempts++;

            reading = await _dht1.GetReadingAsync(30).AsTask();

            //_retryCount.Add(reading.RetryCount);

            if (reading.IsValid)
            {
                //this.TotalSuccess++;
                this.Temperature = Convert.ToDecimal(reading.Temperature);
                this.Humidity = Convert.ToDecimal(reading.Humidity);
                this.LastUpdated = DateTimeOffset.Now;
                //this.OnPropertyChanged(nameof(SuccessRate));
                DataItem myItem = new DataItem(0, new Guid(), DateTime.Now, (decimal)reading.Temperature, (decimal)reading.Humidity);
                //itemList.Add(myItem);

                this.OnDataItemChanged(myItem);
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
