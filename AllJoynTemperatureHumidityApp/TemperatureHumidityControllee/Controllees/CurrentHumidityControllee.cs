// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using org.alljoyn.SmartSpaces.Environment.CurrentHumidity;
using System;
using TemperatureHumidityControllee.Controllees.Helpers;
using Windows.Devices.AllJoyn;

namespace TemperatureHumidityControllee.Controllees
{
    public class CurrentHumidityControllee:ObservableObject, IDisposable
    {
        private Func<ICurrentHumidityService> _currentHumidityServiceProvider;
        private Func<CurrentHumidityBusAttachment> _currentHumidityBusAttachmentProvider;

        private AllJoynBusAttachment _currentHumidityBusAttachment;
        public AllJoynBusAttachment CurrentHumidityBusAttachment
        {
            get
            {
                return this._currentHumidityBusAttachment;
            }
            private set
            {
                this._currentHumidityBusAttachment = value;
            }
        }

        private CurrentHumidityProducer _currentHumidityProducer;

        private String _currentHumidityBusAttachmentState = "Disconnected";
        public String CurrentHumidityBusAttachmentState
        {
            get
            {
                return _currentHumidityBusAttachmentState;
            }
            set
            {
                _currentHumidityBusAttachmentState = value;
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => CurrentHumidityBusAttachmentState);
                });
            }
        }

        public CurrentHumidityControllee(Func<CurrentHumidityBusAttachment> busAttachmentProvider,
                                            Func<ICurrentHumidityService> serviceProvider)
        {

            this._currentHumidityBusAttachmentProvider = busAttachmentProvider;
            this._currentHumidityServiceProvider = serviceProvider;

            Messenger.Default.Register<string>(this, m => this.MessageFromModel(m));

            this.InitializeBusAttachment();
            this.InitializeProducer();

        }

    

        private void MessageFromModel(string message)
        {
            if (message == "CurrentValue")
            {
                this._currentHumidityProducer.EmitCurrentValueChanged();
            }
          
        }


        private void OnCurrentTemperatureBusAttachmentStateChanged(AllJoynBusAttachment sender, AllJoynBusAttachmentStateChangedEventArgs args)
        {
            switch (args.State)
            {
                case AllJoynBusAttachmentState.Disconnected:
                    this.CurrentHumidityBusAttachmentState = "Disconnected";
                    break;
                case AllJoynBusAttachmentState.Connecting:
                    break;
                case AllJoynBusAttachmentState.Connected:
                    this.CurrentHumidityBusAttachmentState = "Connected";
                    break;
                case AllJoynBusAttachmentState.Disconnecting:
                    break;
                default:
                    this.CurrentHumidityBusAttachmentState = "No connection information";
                    break;
            }
        }


        public void InitializeBusAttachment()
        {
            this.CurrentHumidityBusAttachment = this._currentHumidityBusAttachmentProvider().GetAllJoynBusAttachment();
            this.CurrentHumidityBusAttachment.StateChanged += OnCurrentTemperatureBusAttachmentStateChanged;
        }

        public void InitializeProducer()
        {

            this._currentHumidityProducer = new CurrentHumidityProducer(this.CurrentHumidityBusAttachment);

            //this._currentHumidityProducer.Stopped += OnCurrentHumidityProducerStopped;
            //this._currentHumidityProducer.SessionLost += OnCurrentHumidityProducerSessionLost;
            //this._currentHumidityProducer.SessionMemberAdded += OnCurrentvProducerMemberAdded;
            //this._currentHumidityProducer.SessionMemberRemoved += OnCurrentHumidityProducerMemberRemoved;

            this._currentHumidityProducer.Service = this._currentHumidityServiceProvider();



        }

        public void StartCurrentHumidityProducer()
        {

            if (this.CurrentHumidityBusAttachmentState == "Disconnected")
            {
                if (this._currentHumidityProducer != null)
                {
                    this._currentHumidityProducer.Start();
                }
                else
                {
                    if (this.CurrentHumidityBusAttachment == null)
                    {
                        this.InitializeBusAttachment();
                    }
                    this.CurrentHumidityBusAttachment.Connect();

                    this.InitializeProducer();
                    this._currentHumidityProducer.Start();
                }

            }

            else if (this.CurrentHumidityBusAttachmentState == "Connected")
            {
                //
            }
        }

        public void StopCurrentHumidityProducer()
        {
            if (this.CurrentHumidityBusAttachmentState == "Connected")
            {
                if (this._currentHumidityProducer != null)
                {
                    this._currentHumidityProducer.Stop();

                    if (this.CurrentHumidityBusAttachment != null)
                    {
                        this.CurrentHumidityBusAttachment.Disconnect();
                    }

                }

            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._currentHumidityProducer != null)
                {                
                    this._currentHumidityProducer.Stop();

                    //this._currentTemperatureProducer.Stopped -= OnCurrentTemperatureProducerStopped;
                    //this._currentTemperatureProducer.SessionLost -= OnCurrentTemperatureProducerSessionLost;
                    //this._currentTemperatureProducer.SessionMemberAdded -= OnCurrentTemperatureProducerMemberAdded;
                    //this._currentTemperatureProducer.SessionMemberRemoved -= OnCurrentTemperatureProducerMemberRemoved;

                    this._currentHumidityProducer.Dispose();
                    this._currentHumidityProducer = null;
                }
                if (this.CurrentHumidityBusAttachment != null)
                {
                    this.CurrentHumidityBusAttachment.Disconnect();
                    this.CurrentHumidityBusAttachment = null;
                }
                Messenger.Default.Unregister(this);
            }
        }
    }
}
