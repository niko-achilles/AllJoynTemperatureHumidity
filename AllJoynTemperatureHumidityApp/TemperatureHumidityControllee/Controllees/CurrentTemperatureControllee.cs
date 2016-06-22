// ****************************************************************************
// <author>Nikolaos Kokkinos</author> 
// <email>nik.kokkinos@windowslive.com</email> 
// <date>22.06.2016</date>  
// <web>http://nikolaoskokkinos.wordpress.com/</web> 
// **************************************************************************** 

using org.alljoyn.SmartSpaces.Environment.CurrentTemperature;
using TemperatureHumidityControllee.Controllees.Helpers;
using System;
using Windows.Devices.AllJoyn;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight;

namespace TemperatureHumidityControllee.Controllees
{
    public class CurrentTemperatureControllee:ObservableObject, IDisposable
    {
        private Func<ICurrentTemperatureService> _currentTemperatureServiceProvider;
        private Func<CurrentTemperatureBusAttachment> _currentTemperatureBusAttachmentProvider;

        private AllJoynBusAttachment _currentTemperatureBusAttachment;
        public AllJoynBusAttachment CurrentTemperatureBusAttachment
        {
            get
            {
                return this._currentTemperatureBusAttachment;
            }
            private set
            {
                this._currentTemperatureBusAttachment = value;
            }
        }

        private CurrentTemperatureProducer _currentTemperatureProducer;

        private String _currentTemperatureBusAttachmentState = "Disconnected";
        public String CurrentTemperatureBusAttachmentState
        {
            get
            {
                return _currentTemperatureBusAttachmentState;
            }
            set
            {
                _currentTemperatureBusAttachmentState = value;
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    RaisePropertyChanged(() => CurrentTemperatureBusAttachmentState);
                });
            }
        }

        public CurrentTemperatureControllee(Func<CurrentTemperatureBusAttachment> busAttachmentProvider, 
                                            Func<ICurrentTemperatureService> serviceProvider)
        {

            this._currentTemperatureBusAttachmentProvider = busAttachmentProvider;
            this._currentTemperatureServiceProvider = serviceProvider;

            Messenger.Default.Register<string>(this, m => this.MessageFromModel(m));

            this.InitializeBusAttachment();
            this.InitializeProducer();
       
        }

        private void MessageFromModel(string message)
        {
            if (message == "CurrentValue")
            {
                this._currentTemperatureProducer.EmitCurrentValueChanged();
            }
            if (message == "Precision")
            {
                this._currentTemperatureProducer.EmitUpdateMinTimeChanged();
            }

            if (message == "UpdateMinTime")
            {
                this._currentTemperatureProducer.EmitUpdateMinTimeChanged();
            }
        }

       
        private void OnCurrentTemperatureBusAttachmentStateChanged(AllJoynBusAttachment sender, AllJoynBusAttachmentStateChangedEventArgs args)
        {
            switch (args.State)
            {
                case AllJoynBusAttachmentState.Disconnected:
                    this.CurrentTemperatureBusAttachmentState = "Disconnected";
                    break;
                case AllJoynBusAttachmentState.Connecting:
                    break;
                case AllJoynBusAttachmentState.Connected:
                    this.CurrentTemperatureBusAttachmentState = "Connected";
                    break;
                case AllJoynBusAttachmentState.Disconnecting:
                    break;
                default:
                    this.CurrentTemperatureBusAttachmentState = "No connection information";
                    break;
            }
        }


        public void InitializeBusAttachment()
        {
            this.CurrentTemperatureBusAttachment = this._currentTemperatureBusAttachmentProvider().GetAllJoynBusAttachment();
            this.CurrentTemperatureBusAttachment.StateChanged += OnCurrentTemperatureBusAttachmentStateChanged;
        }

        public void InitializeProducer()
        {
            
            this._currentTemperatureProducer = new CurrentTemperatureProducer(this.CurrentTemperatureBusAttachment);

            //this._currentTemperatureProducer.Stopped += OnCurrentTemperatureProducerStopped;
            //this._currentTemperatureProducer.SessionLost += OnCurrentTemperatureProducerSessionLost;
            //this._currentTemperatureProducer.SessionMemberAdded += OnCurrentTemperatureProducerMemberAdded;
            //this._currentTemperatureProducer.SessionMemberRemoved += OnCurrentTemperatureProducerMemberRemoved;

            this._currentTemperatureProducer.Service = this._currentTemperatureServiceProvider();

            
            
        }

        public void StartCurrentTemperatureProducer()
        {

            if (this.CurrentTemperatureBusAttachmentState == "Disconnected")
            {
                if (this._currentTemperatureProducer!=null)
                {
                    this._currentTemperatureProducer.Start();
                }
                else
                {
                    if (this.CurrentTemperatureBusAttachment == null)
                    {
                        this.InitializeBusAttachment();
                    }
                    this.CurrentTemperatureBusAttachment.Connect();

                    this.InitializeProducer();
                    this._currentTemperatureProducer.Start();
                }
                
            }

            else if (this.CurrentTemperatureBusAttachmentState == "Connected")
            {
                //
            }
        }

        public void StopCurrentTemperatureProducer()
        {
            if (this.CurrentTemperatureBusAttachmentState == "Connected")
            {
                if (this._currentTemperatureProducer!=null)
                {
                    this._currentTemperatureProducer.Stop();

                    if (this.CurrentTemperatureBusAttachment != null)
                    {
                        this.CurrentTemperatureBusAttachment.Disconnect();
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
                if (this._currentTemperatureProducer != null)
                {
                    this._currentTemperatureProducer.Stop();

                    //this._currentTemperatureProducer.Stopped -= OnCurrentTemperatureProducerStopped;
                    //this._currentTemperatureProducer.SessionLost -= OnCurrentTemperatureProducerSessionLost;
                    //this._currentTemperatureProducer.SessionMemberAdded -= OnCurrentTemperatureProducerMemberAdded;
                    //this._currentTemperatureProducer.SessionMemberRemoved -= OnCurrentTemperatureProducerMemberRemoved;

                    this._currentTemperatureProducer.Dispose();
                    this._currentTemperatureProducer = null;
                }
                if (this.CurrentTemperatureBusAttachment != null)
                {
                    this.CurrentTemperatureBusAttachment.Disconnect();
                    this.CurrentTemperatureBusAttachment = null;
                }
                Messenger.Default.Unregister(this);
            }
        }
    }
}
