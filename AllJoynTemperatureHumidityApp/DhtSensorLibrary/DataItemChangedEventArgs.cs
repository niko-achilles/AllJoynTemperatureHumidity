// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

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