// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System;
using System.Collections.Generic;

namespace TemperatureHumidityControllee.Controllees.Helpers
{
    public interface IAboutData
    {
        Guid AppId { get; set; }
        IDictionary<System.String, System.String> AppNames { get; }
        DateTimeOffset? DateOfManufacture { get; set; }
        System.String DefaultAppName { get; set; }
        System.String DefaultDescription { get; set; }
        System.String DefaultManufacturer { get; set; }
        IDictionary<System.String, System.String> Descriptions { get; }
        System.Boolean IsEnabled { get; set; }
        IDictionary<System.String, System.String> Manufacturers { get; }
        System.String ModelNumber { get; set; }
        System.String SoftwareVersion { get; set; }
        Uri SupportUrl { get; set; }
    }

    public class CurrentTemperatureAboutData : IAboutData
    {
        public Guid AppId { get; set; }
        public IDictionary<System.String, System.String> AppNames { get; }
        public DateTimeOffset? DateOfManufacture { get; set; }
        public System.String DefaultAppName { get; set; }
        public System.String DefaultDescription { get; set; }
        public System.String DefaultManufacturer { get; set; }
        public IDictionary<System.String, System.String> Descriptions { get; }
        public System.Boolean IsEnabled { get; set; }
        public IDictionary<System.String, System.String> Manufacturers { get; }
        public System.String ModelNumber { get; set; }
        public System.String SoftwareVersion { get; set; }
        public Uri SupportUrl { get; set; }
    }

    public class CurrentHumidityAboutData : IAboutData
    {
        public Guid AppId { get; set; }
        public IDictionary<System.String, System.String> AppNames { get; }
        public DateTimeOffset? DateOfManufacture { get; set; }
        public System.String DefaultAppName { get; set; }
        public System.String DefaultDescription { get; set; }
        public System.String DefaultManufacturer { get; set; }
        public IDictionary<System.String, System.String> Descriptions { get; }
        public System.Boolean IsEnabled { get; set; }
        public IDictionary<System.String, System.String> Manufacturers { get; }
        public System.String ModelNumber { get; set; }
        public System.String SoftwareVersion { get; set; }
        public Uri SupportUrl { get; set; }
    }
}