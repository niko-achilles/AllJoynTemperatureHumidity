//-----------------------------------------------------------------------------
// <auto-generated> 
//   This code was generated by a tool. 
// 
//   Changes to this file may cause incorrect behavior and will be lost if  
//   the code is regenerated.
//
//   Tool: AllJoynCodeGenerator.exe
//
//   This tool is located in the Windows 10 SDK and the Windows 10 AllJoyn 
//   Visual Studio Extension in the Visual Studio Gallery.  
//
//   The generated code should be packaged in a Windows 10 C++/CX Runtime  
//   Component which can be consumed in any UWP-supported language using 
//   APIs that are available in Windows.Devices.AllJoyn.
//
//   Using AllJoynCodeGenerator - Invoke the following command with a valid 
//   Introspection XML file and a writable output directory:
//     AllJoynCodeGenerator -i <INPUT XML FILE> -o <OUTPUT DIRECTORY>
// </auto-generated>
//-----------------------------------------------------------------------------
#pragma once

namespace org { namespace alljoyn { namespace SmartSpaces { namespace Environment { namespace CurrentTemperature {

// This class, and the associated EventArgs classes, exist for the benefit of JavaScript developers who
// do not have the ability to implement ICurrentTemperatureService. Instead, CurrentTemperatureServiceEventAdapter
// provides the Interface implementation and exposes a set of compatible events to the developer.
public ref class CurrentTemperatureServiceEventAdapter sealed : [Windows::Foundation::Metadata::Default] ICurrentTemperatureService
{
public:
    // Method Invocation Events
    // Property Read Events
    event Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetVersionRequestedEventArgs^>^ GetVersionRequested 
    { 
        Windows::Foundation::EventRegistrationToken add(Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetVersionRequestedEventArgs^>^ handler) 
        { 
            return _GetVersionRequested += ref new Windows::Foundation::EventHandler<Platform::Object^>
            ([handler](Platform::Object^ sender, Platform::Object^ args)
            {
                handler->Invoke(safe_cast<CurrentTemperatureServiceEventAdapter^>(sender), safe_cast<CurrentTemperatureGetVersionRequestedEventArgs^>(args));
            }, Platform::CallbackContext::Same);
        } 
        void remove(Windows::Foundation::EventRegistrationToken token) 
        { 
            _GetVersionRequested -= token; 
        } 
    internal: 
        void raise(CurrentTemperatureServiceEventAdapter^ sender, CurrentTemperatureGetVersionRequestedEventArgs^ args) 
        { 
            _GetVersionRequested(sender, args);
        } 
    }

    event Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetCurrentValueRequestedEventArgs^>^ GetCurrentValueRequested 
    { 
        Windows::Foundation::EventRegistrationToken add(Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetCurrentValueRequestedEventArgs^>^ handler) 
        { 
            return _GetCurrentValueRequested += ref new Windows::Foundation::EventHandler<Platform::Object^>
            ([handler](Platform::Object^ sender, Platform::Object^ args)
            {
                handler->Invoke(safe_cast<CurrentTemperatureServiceEventAdapter^>(sender), safe_cast<CurrentTemperatureGetCurrentValueRequestedEventArgs^>(args));
            }, Platform::CallbackContext::Same);
        } 
        void remove(Windows::Foundation::EventRegistrationToken token) 
        { 
            _GetCurrentValueRequested -= token; 
        } 
    internal: 
        void raise(CurrentTemperatureServiceEventAdapter^ sender, CurrentTemperatureGetCurrentValueRequestedEventArgs^ args) 
        { 
            _GetCurrentValueRequested(sender, args);
        } 
    }

    event Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetPrecisionRequestedEventArgs^>^ GetPrecisionRequested 
    { 
        Windows::Foundation::EventRegistrationToken add(Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetPrecisionRequestedEventArgs^>^ handler) 
        { 
            return _GetPrecisionRequested += ref new Windows::Foundation::EventHandler<Platform::Object^>
            ([handler](Platform::Object^ sender, Platform::Object^ args)
            {
                handler->Invoke(safe_cast<CurrentTemperatureServiceEventAdapter^>(sender), safe_cast<CurrentTemperatureGetPrecisionRequestedEventArgs^>(args));
            }, Platform::CallbackContext::Same);
        } 
        void remove(Windows::Foundation::EventRegistrationToken token) 
        { 
            _GetPrecisionRequested -= token; 
        } 
    internal: 
        void raise(CurrentTemperatureServiceEventAdapter^ sender, CurrentTemperatureGetPrecisionRequestedEventArgs^ args) 
        { 
            _GetPrecisionRequested(sender, args);
        } 
    }

    event Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetUpdateMinTimeRequestedEventArgs^>^ GetUpdateMinTimeRequested 
    { 
        Windows::Foundation::EventRegistrationToken add(Windows::Foundation::TypedEventHandler<CurrentTemperatureServiceEventAdapter^, CurrentTemperatureGetUpdateMinTimeRequestedEventArgs^>^ handler) 
        { 
            return _GetUpdateMinTimeRequested += ref new Windows::Foundation::EventHandler<Platform::Object^>
            ([handler](Platform::Object^ sender, Platform::Object^ args)
            {
                handler->Invoke(safe_cast<CurrentTemperatureServiceEventAdapter^>(sender), safe_cast<CurrentTemperatureGetUpdateMinTimeRequestedEventArgs^>(args));
            }, Platform::CallbackContext::Same);
        } 
        void remove(Windows::Foundation::EventRegistrationToken token) 
        { 
            _GetUpdateMinTimeRequested -= token; 
        } 
    internal: 
        void raise(CurrentTemperatureServiceEventAdapter^ sender, CurrentTemperatureGetUpdateMinTimeRequestedEventArgs^ args) 
        { 
            _GetUpdateMinTimeRequested(sender, args);
        } 
    }

    // Property Write Events
    // ICurrentTemperatureService Implementation

    virtual Windows::Foundation::IAsyncOperation<CurrentTemperatureGetVersionResult^>^ GetVersionAsync(_In_ Windows::Devices::AllJoyn::AllJoynMessageInfo^ info);
    virtual Windows::Foundation::IAsyncOperation<CurrentTemperatureGetCurrentValueResult^>^ GetCurrentValueAsync(_In_ Windows::Devices::AllJoyn::AllJoynMessageInfo^ info);
    virtual Windows::Foundation::IAsyncOperation<CurrentTemperatureGetPrecisionResult^>^ GetPrecisionAsync(_In_ Windows::Devices::AllJoyn::AllJoynMessageInfo^ info);
    virtual Windows::Foundation::IAsyncOperation<CurrentTemperatureGetUpdateMinTimeResult^>^ GetUpdateMinTimeAsync(_In_ Windows::Devices::AllJoyn::AllJoynMessageInfo^ info);


private:
    event Windows::Foundation::EventHandler<Platform::Object^>^ _GetVersionRequested;
    event Windows::Foundation::EventHandler<Platform::Object^>^ _GetCurrentValueRequested;
    event Windows::Foundation::EventHandler<Platform::Object^>^ _GetPrecisionRequested;
    event Windows::Foundation::EventHandler<Platform::Object^>^ _GetUpdateMinTimeRequested;
};

} } } } } 
