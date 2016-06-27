// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight.Views;

namespace TemperatureHumidityControllee.Design
{
    /// <summary>
    /// This class is only here to avoid errors at design time.
    /// </summary>
    public class DesignNavigationService : INavigationService
    {
        public void GoBack()
        {
            // Do nothing
        }

        public void NavigateTo(string pageKey)
        {
            // Do nothing
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            // Do nothing
        }

        public string CurrentPageKey
        {
            get
            {
                return null;
            }
        }
    }
}
