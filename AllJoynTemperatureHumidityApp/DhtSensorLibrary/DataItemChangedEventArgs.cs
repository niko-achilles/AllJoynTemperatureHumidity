using System;

namespace DhtSensorLibrary
{
    public class DataItemChangedEventArgs:EventArgs
    {
        public DataItemChangedEventArgs(DataItem item)
        {
            this.Item = item;
        }

        public DataItem Item { get; private set; }
    }
}