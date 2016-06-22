//-----------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//   Changes to this file may cause incorrect behavior and will be lost if
//   the code is regenerated.
//
//   For more information, see: http://go.microsoft.com/fwlink/?LinkID=623246
// </auto-generated>
//-----------------------------------------------------------------------------
#pragma once

using namespace concurrency;

namespace org { namespace alljoyn { namespace SmartSpaces { namespace Environment { namespace CurrentTemperature {

ref class CurrentTemperatureConsumer;

public ref class CurrentTemperatureJoinSessionResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property CurrentTemperatureConsumer^ Consumer
    {
        CurrentTemperatureConsumer^ get() { return m_consumer; }
    internal:
        void set(_In_ CurrentTemperatureConsumer^ value) { m_consumer = value; }
    };

private:
    int32 m_status;
    CurrentTemperatureConsumer^ m_consumer;
};

public ref class CurrentTemperatureGetVersionResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property uint16 Version
    {
        uint16 get() { return m_value; }
    internal:
        void set(_In_ uint16 value) { m_value = value; }
    }

    static CurrentTemperatureGetVersionResult^ CreateSuccessResult(_In_ uint16 value)
    {
        auto result = ref new CurrentTemperatureGetVersionResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Version = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static CurrentTemperatureGetVersionResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new CurrentTemperatureGetVersionResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    uint16 m_value;
};

public ref class CurrentTemperatureGetCurrentValueResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property double CurrentValue
    {
        double get() { return m_value; }
    internal:
        void set(_In_ double value) { m_value = value; }
    }

    static CurrentTemperatureGetCurrentValueResult^ CreateSuccessResult(_In_ double value)
    {
        auto result = ref new CurrentTemperatureGetCurrentValueResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->CurrentValue = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static CurrentTemperatureGetCurrentValueResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new CurrentTemperatureGetCurrentValueResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    double m_value;
};

public ref class CurrentTemperatureGetPrecisionResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property double Precision
    {
        double get() { return m_value; }
    internal:
        void set(_In_ double value) { m_value = value; }
    }

    static CurrentTemperatureGetPrecisionResult^ CreateSuccessResult(_In_ double value)
    {
        auto result = ref new CurrentTemperatureGetPrecisionResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->Precision = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static CurrentTemperatureGetPrecisionResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new CurrentTemperatureGetPrecisionResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    double m_value;
};

public ref class CurrentTemperatureGetUpdateMinTimeResult sealed
{
public:
    property int32 Status
    {
        int32 get() { return m_status; }
    internal:
        void set(_In_ int32 value) { m_status = value; }
    }

    property uint16 UpdateMinTime
    {
        uint16 get() { return m_value; }
    internal:
        void set(_In_ uint16 value) { m_value = value; }
    }

    static CurrentTemperatureGetUpdateMinTimeResult^ CreateSuccessResult(_In_ uint16 value)
    {
        auto result = ref new CurrentTemperatureGetUpdateMinTimeResult();
        result->Status = Windows::Devices::AllJoyn::AllJoynStatus::Ok;
        result->UpdateMinTime = value;
        result->m_creationContext = Concurrency::task_continuation_context::use_current();
        return result;
    }

    static CurrentTemperatureGetUpdateMinTimeResult^ CreateFailureResult(_In_ int32 status)
    {
        auto result = ref new CurrentTemperatureGetUpdateMinTimeResult();
        result->Status = status;
        return result;
    }
internal:
    Concurrency::task_continuation_context m_creationContext = Concurrency::task_continuation_context::use_default();

private:
    int32 m_status;
    uint16 m_value;
};

} } } } } 