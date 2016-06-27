
using System;

namespace DhtSensorLibrary
{
    public class DataItem
    {
        public Guid sensorID { get; set; }
        public DateTimeOffset captureTime { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public int ID { get; set; }
        public DataItem(int ID, Guid sensorID, DateTimeOffset captureTime, double temperature, double humidity)
        {
            this.ID = ID;
            this.sensorID = sensorID;
            this.captureTime = captureTime;
            this.temperature = temperature;
            this.humidity = humidity;
        }
    }
}