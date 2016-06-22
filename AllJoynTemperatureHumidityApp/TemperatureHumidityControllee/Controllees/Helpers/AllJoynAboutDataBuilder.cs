// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using System;

namespace TemperatureHumidityControllee.Controllees.Helpers
{
    class AllJoynAboutDataBuilder
    {
        // ***Mandaratory //

        //AppId:            yes 
        //AppName:          yes 
        //Manufacturer:     yes 
        //ModelNumber:      yes
        //Description:      yes 
        //SoftwareVersion:  yes

        // ***Not exist in Windows API - but Mandaratory //

        //DeviceId:             yes -> doesn't exist in Windows API
        //AJSoftwareVersion:    yes -> doesn't exist in Windows API
        //SupportedLanguages:   yes -> doesn't exist in Windows API
        //DefaultLanguage:      yes -> doesn't exist in Windows API

        // *** Optional //
        //DeviceName        -> doesn't exist in Windows API
        //DateOfManufacture
        //HardwareVersion:  -> doesn't exist in Windows API
        //SupportUrl:no
        private IAboutData _aboutData;

        public AllJoynAboutDataBuilder(IAboutData aboutData)
        {
            this._aboutData = aboutData;
        }

        public AllJoynAboutDataBuilder WithAppId(Guid guid)
        {
            this._aboutData.AppId = guid;
            return this;
        }

        public AllJoynAboutDataBuilder WithDefaultAppName(System.String defaultAppName)
        {
            this._aboutData.DefaultAppName = defaultAppName;
            return this;
        }

        public AllJoynAboutDataBuilder WithDefaultManufacturer(System.String defaultManufacturer)
        {
            this._aboutData.DefaultManufacturer = defaultManufacturer;
            return this;
        }

        public AllJoynAboutDataBuilder WithModelNumber(System.String modelNumber)
        {
            this._aboutData.ModelNumber = modelNumber;
            return this;
        }

        public AllJoynAboutDataBuilder WithDefaultDescription(System.String defaultDescription)
        {
            this._aboutData.DefaultDescription = defaultDescription;
            return this;
        }

        public AllJoynAboutDataBuilder WithSoftwareVersion(System.String softwareVersion)
        {
            this._aboutData.SoftwareVersion = softwareVersion;
            return this;
        }

        public AllJoynAboutDataBuilder WithDateOfManufacture(DateTimeOffset dateTimeOffset)
        {
            this._aboutData.DateOfManufacture = dateTimeOffset;
            return this;
        }

        public AllJoynAboutDataBuilder WithSupportUrl(Uri suportUrl)
        {
            this._aboutData.SupportUrl = suportUrl;
            return this;
        }

        public IAboutData Build()
        {
            //AppId:            yes 
            //AppName:          yes 
            //Manufacturer:     yes 
            //ModelNumber:      yes
            //Description:      yes 
            //SoftwareVersion:  yes

            //raise Exception about Mandaratory Empty Fields

            if (this._aboutData.AppId == null)
            {
                throw new InvalidOperationException("AppId is null. AppId is manadaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }
            if (String.IsNullOrEmpty(this._aboutData.DefaultAppName) || String.IsNullOrWhiteSpace(this._aboutData.DefaultAppName))
            {
                throw new InvalidOperationException("Default AppName Value is invalid. AppName is mandaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }

            if (String.IsNullOrEmpty(this._aboutData.DefaultManufacturer) || String.IsNullOrWhiteSpace(this._aboutData.DefaultManufacturer))
            {
                throw new InvalidOperationException("Default DefaultManufacturer Value is invalid. DefaultManufacturer is mandaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }

            if (String.IsNullOrEmpty(this._aboutData.ModelNumber) || String.IsNullOrWhiteSpace(this._aboutData.ModelNumber))
            {
                throw new InvalidOperationException("ModelNumber Value is invalid. ModelNumber is mandaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }

            if (String.IsNullOrEmpty(this._aboutData.DefaultDescription) || String.IsNullOrWhiteSpace(this._aboutData.DefaultDescription))
            {
                throw new InvalidOperationException("Default Description is invalid. Default Description or Descriptions is mandaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }

            if (String.IsNullOrEmpty(this._aboutData.SoftwareVersion) || String.IsNullOrWhiteSpace(this._aboutData.SoftwareVersion))
            {
                throw new InvalidOperationException("Software Version is invalid. Software Version is mandaratory for the About Data Interface. More Info here: https://allseenalliance.org/framework/documentation/learn/core/about-announcement/interface");
            }
            return this._aboutData;
        }
    }
}
