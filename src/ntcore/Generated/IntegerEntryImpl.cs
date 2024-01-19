// Copyright (c) FIRST and other WPILib contributors.
// Open Source Software; you can modify and/or share it under the terms of
// the WPILib BSD license file in the root directory of this project.

// THIS FILE WAS AUTO-GENERATED BY ./ntcore/generate_topics.py. DO NOT MODIFY

using System;
using NetworkTables.Handles;
using NetworkTables.Natives;

namespace NetworkTables;

/** NetworkTables Integer implementation. */
internal sealed class IntegerEntryImpl<T> : EntryBase<T>, IIntegerEntry where T : struct, INtEntryHandle
{
    /**
     * Constructor.
     *
     * @param topic Topic
     * @param handle Native handle
     * @param defaultValue Default value for Get()
     */
    internal IntegerEntryImpl(IntegerTopic topic, T handle, long defaultValue) : base(handle)
    {
        Topic = topic;
        m_defaultValue = defaultValue;
    }

    public override IntegerTopic Topic { get; }


    public long Get()
    {
        NetworkTableValue value = NtCore.GetEntryValue(Handle);
        if (value.IsInteger)
        {
            return value.GetInteger();
        }
        return m_defaultValue;
    }


    public long Get(long defaultValue)
    {
        NetworkTableValue value = NtCore.GetEntryValue(Handle);
        if (value.IsInteger)
        {
            return value.GetInteger();
        }
        return defaultValue;
    }


    public TimestampedObject<long> GetAtomic()
    {
        NetworkTableValue value = NtCore.GetEntryValue(Handle);
        long baseValue = value.IsInteger ? value.GetInteger() : m_defaultValue;
        return new TimestampedObject<long>(value.Time, value.ServerTime, baseValue);
    }


    public TimestampedObject<long> GetAtomic(long defaultValue)
    {
        NetworkTableValue value = NtCore.GetEntryValue(Handle);
        long baseValue = value.IsInteger ? value.GetInteger() : defaultValue;
        return new TimestampedObject<long>(value.Time, value.ServerTime, baseValue);
    }


    public TimestampedObject<long>[] ReadQueue()
    {
        NetworkTableValue[] values = NtCore.ReadQueueValue(Handle);
        TimestampedObject<long>[] timestamped = new TimestampedObject<long>[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            timestamped[i] = new TimestampedObject<long>(values[i].Time, values[i].ServerTime, values[i].GetInteger());
        }
        return timestamped;
    }


    public long[] ReadQueueValues()
    {
        NetworkTableValue[] values = NtCore.ReadQueueValue(Handle);
        long[] timestamped = new long[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
            timestamped[i] = values[i].GetInteger();
        }
        return timestamped;
    }


    public void Set(long value)
    {
        RefNetworkTableValue ntValue = RefNetworkTableValue.MakeInteger(value, 0);
        NtCore.SetEntryValue(Handle, ntValue);
    }

    public void Set(long value, long time)
    {
        RefNetworkTableValue ntValue = RefNetworkTableValue.MakeInteger(value, time);
        NtCore.SetEntryValue(Handle, ntValue);
    }

    public void SetDefault(long value)
    {
        RefNetworkTableValue ntValue = RefNetworkTableValue.MakeInteger(value);
        NtCore.SetDefaultEntryValue(Handle, ntValue);
    }
    public void Unpublish()
    {
        NtCore.Unpublish(Handle);
    }

    private readonly long m_defaultValue;
}
