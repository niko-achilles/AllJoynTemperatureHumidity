// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System.Collections.ObjectModel;
using TemperatureHumidityControllee.Models;

namespace TemperatureHumidityControllee.ViewModels
{
    public class MainViewModel
    {
        public CurrentTemperatureViewModel CurrentTemperatureViewModel { get; private set; }

        public ObservableCollection<DeviceItem> Items
        {
            private set;
            get;
        }

        public MainViewModel(CurrentTemperatureViewModel currentTemperatureViewModel)
        {
            this.CurrentTemperatureViewModel = currentTemperatureViewModel;
            Items = new ObservableCollection<DeviceItem>();
            if (this.CurrentTemperatureViewModel != null)
            {
                Items.Add(new DeviceItem(
                    this.CurrentTemperatureViewModel.CurrentTemepratureControllee.CurrentTemperatureBusAttachment.AboutData)
                    );
            }
            
        }
    }
}
