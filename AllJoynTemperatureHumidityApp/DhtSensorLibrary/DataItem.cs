using System;

namespace DhtSensorLibrary
{
    public class DataItem
    {
        public Guid sensorID { get; set; }
        public DateTimeOffset captureTime { get; set; }
        public decimal temperature { get; set; }
        public decimal humidity { get; set; }
        public int ID { get; set; }
        public DataItem(int ID, Guid sensorID, DateTimeOffset captureTime, decimal temperature, decimal humidity)
        {
            this.ID = ID;
            this.sensorID = sensorID;
            this.captureTime = captureTime;
            this.temperature = temperature;
            this.humidity = humidity;
        }
    }
}