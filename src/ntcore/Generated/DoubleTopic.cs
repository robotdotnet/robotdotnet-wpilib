// Copyright (c) FIRST and other WPILib contributors.
// Open Source Software; you can modify and/or share it under the terms of
// the WPILib BSD license file in the root directory of this project.

// THIS FILE WAS AUTO-GENERATED BY ./ntcore/generate_topics.py. DO NOT MODIFY

using System;
using NetworkTables.Handles;
using NetworkTables.Natives;

namespace NetworkTables;

/** NetworkTables Double topic. */
public class DoubleTopic : Topic
{
    /** The default type string for this topic type. */
    public static string kTypeString => "double";
    public static ReadOnlySpan<byte> kTypeStringUtf8 => "double"u8;

    /**
     * Construct from a generic topic.
     *
     * @param topic Topic
     */
    public DoubleTopic(Topic topic) : base(topic.Instance, topic.Handle)
    {
    }

    /**
     * Constructor; use NetworkTableInstance.getDoubleTopic() instead.
     *
     * @param inst Instance
     * @param handle Native handle
     */
    public DoubleTopic(NetworkTableInstance inst, NtTopic handle) : base(inst, handle)
    {
    }


    /**
     * Create a new subscriber to the topic.
     *
     * <p>The subscriber is only active as long as the returned object
     * is not closed.
     *
     * <p>Subscribers that do not match the published data type do not return
     * any values. To determine if the data type matches, use the appropriate
     * Topic functions.
     *
     * @param defaultValue default value used when a default is not provided to a
     *        getter function
     * @param options subscribe options
     * @return subscriber
     */
    public IDoubleSubscriber Subscribe(
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtSubscriber>(
            this,
            NtCore.Subscribe(
                Handle, NetworkTableType.Double,
                "double"u8, options),
            defaultValue);
    }

    /**
     * Create a new subscriber to the topic, with specified type string.
     *
     * <p>The subscriber is only active as long as the returned object
     * is not closed.
     *
     * <p>Subscribers that do not match the published data type do not return
     * any values. To determine if the data type matches, use the appropriate
     * Topic functions.
     *
     * @param typeString type string
     * @param defaultValue default value used when a default is not provided to a
     *        getter function
     * @param options subscribe options
     * @return subscriber
     */
    public IDoubleSubscriber SubscribeEx(
        string typeString,
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtSubscriber>(
            this,
            NtCore.Subscribe(
                Handle, NetworkTableType.Double,
                typeString, options),
            defaultValue);
    }

    /**
     * Create a new subscriber to the topic, with specified type string.
     *
     * <p>The subscriber is only active as long as the returned object
     * is not closed.
     *
     * <p>Subscribers that do not match the published data type do not return
     * any values. To determine if the data type matches, use the appropriate
     * Topic functions.
     *
     * @param typeString type string
     * @param defaultValue default value used when a default is not provided to a
     *        getter function
     * @param options subscribe options
     * @return subscriber
     */
    internal IDoubleSubscriber SubscribeEx(
        ReadOnlySpan<byte> typeString,
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtSubscriber>(
            this,
            NtCore.Subscribe(
                Handle, NetworkTableType.Double,
                typeString, options),
            defaultValue);
    }

    /**
     * Create a new publisher to the topic.
     *
     * <p>The publisher is only active as long as the returned object
     * is not closed.
     *
     * <p>It is not possible to publish two different data types to the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored). To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param options publish options
     * @return publisher
     */
    public IDoublePublisher Publish(
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtPublisher>(
            this,
            NtCore.Publish(
                Handle, NetworkTableType.Double,
                "double"u8, options),
            0);
    }

    /**
      * Create a new publisher to the topic.
      *
      * <p>The publisher is only active as long as the returned object
      * is not closed.
      *
      * <p>It is not possible to publish two different data types to the same
      * topic. Conflicts between publishers are typically resolved by the server on
      * a first-come, first-served basis. Any published values that do not match
      * the topic's data type are dropped (ignored). To determine if the data type
      * matches, use the appropriate Topic functions.
      *
      * @param typeString type string
      * @param options publish options
      * @return publisher
      */
    public IDoublePublisher PublishEx(
        string typeString, string properties,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtPublisher>(
            this,
            NtCore.PublishEx(
                Handle, NetworkTableType.Double,
                typeString, properties, options),
            0);
    }

    /**
     * Create a new publisher to the topic, with type string and initial properties.
     *
     * <p>The publisher is only active as long as the returned object
     * is not closed.
     *
     * <p>It is not possible to publish two different data types to the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored). To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param typeString type string
     * @param properties JSON properties
     * @param options publish options
     * @return publisher
     * @throws IllegalArgumentException if properties is not a JSON object
     */
    internal IDoublePublisher PublishEx(
        ReadOnlySpan<byte> typeString,
        string properties,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtPublisher>(
            this,
            NtCore.PublishEx(
                Handle, NetworkTableType.Double,
                typeString, properties, options),
            0);
    }

    /**
     * Create a new publisher to the topic, with type string and initial properties.
     *
     * <p>The publisher is only active as long as the returned object
     * is not closed.
     *
     * <p>It is not possible to publish two different data types to the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored). To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param typeString type string
     * @param properties JSON properties
     * @param options publish options
     * @return publisher
     * @throws IllegalArgumentException if properties is not a JSON object
     */
    internal IDoublePublisher PublishEx(
        string typeString,
        ReadOnlySpan<byte> properties,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtPublisher>(
            this,
            NtCore.PublishEx(
                Handle, NetworkTableType.Double,
                typeString, properties, options),
            0);
    }

    /**
     * Create a new publisher to the topic, with type string and initial properties.
     *
     * <p>The publisher is only active as long as the returned object
     * is not closed.
     *
     * <p>It is not possible to publish two different data types to the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored). To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param typeString type string
     * @param properties JSON properties
     * @param options publish options
     * @return publisher
     * @throws IllegalArgumentException if properties is not a JSON object
     */
    internal IDoublePublisher PublishEx(
        ReadOnlySpan<byte> typeString,
        ReadOnlySpan<byte> properties,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtPublisher>(
            this,
            NtCore.PublishEx(
                Handle, NetworkTableType.Double,
                typeString, properties, options),
            0);
    }

    /**
       * Create a new entry for the topic.
       *
       * <p>Entries act as a combination of a subscriber and a weak publisher. The
       * subscriber is active as long as the entry is not closed. The publisher is
       * created when the entry is first written to, and remains active until either
       * unpublish() is called or the entry is closed.
       *
       * <p>It is not possible to use two different data types with the same
       * topic. Conflicts between publishers are typically resolved by the server on
       * a first-come, first-served basis. Any published values that do not match
       * the topic's data type are dropped (ignored), and the entry will show no new
       * values if the data type does not match. To determine if the data type
       * matches, use the appropriate Topic functions.
       *
       * @param defaultValue default value used when a default is not provided to a
       *        getter function
       * @param options publish and/or subscribe options
       * @return entry
       */
    public IDoubleEntry GetEntry(
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtEntry>(
            this,
            NtCore.GetEntry(
                Handle, NetworkTableType.Double,
                "double"u8, options),
            defaultValue);
    }

    /**
     * Create a new entry for the topic, with specified type string.
     *
     * <p>Entries act as a combination of a subscriber and a weak publisher. The
     * subscriber is active as long as the entry is not closed. The publisher is
     * created when the entry is first written to, and remains active until either
     * unpublish() is called or the entry is closed.
     *
     * <p>It is not possible to use two different data types with the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored), and the entry will show no new
     * values if the data type does not match. To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param typeString type string
     * @param defaultValue default value used when a default is not provided to a
     *        getter function
     * @param options publish and/or subscribe options
     * @return entry
     */
    public IDoubleEntry GetEntryEx(
        string typeString,
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtEntry>(
            this,
            NtCore.GetEntry(
                Handle, NetworkTableType.Double,
                typeString, options),
            defaultValue);
    }

    /**
     * Create a new entry for the topic, with specified type string.
     *
     * <p>Entries act as a combination of a subscriber and a weak publisher. The
     * subscriber is active as long as the entry is not closed. The publisher is
     * created when the entry is first written to, and remains active until either
     * unpublish() is called or the entry is closed.
     *
     * <p>It is not possible to use two different data types with the same
     * topic. Conflicts between publishers are typically resolved by the server on
     * a first-come, first-served basis. Any published values that do not match
     * the topic's data type are dropped (ignored), and the entry will show no new
     * values if the data type does not match. To determine if the data type
     * matches, use the appropriate Topic functions.
     *
     * @param typeString type string
     * @param defaultValue default value used when a default is not provided to a
     *        getter function
     * @param options publish and/or subscribe options
     * @return entry
     */
    internal IDoubleEntry GetEntryEx(
        ReadOnlySpan<byte> typeString,
        double defaultValue,
        PubSubOptions options)
    {
        return new DoubleEntryImpl<NtEntry>(
            this,
            NtCore.GetEntry(
                Handle, NetworkTableType.Double,
                typeString, options),
            defaultValue);
    }



}
