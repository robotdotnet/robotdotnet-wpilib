// Copyright (c) FIRST and other WPILib contributors.
// Open Source Software; you can modify and/or share it under the terms of
// the WPILib BSD license file in the root directory of this project.

// THIS FILE WAS AUTO-GENERATED BY ./ntcore/generate_topics.py. DO NOT MODIFY

namespace NetworkTables;

/** NetworkTables FloatArray publisher. */
public interface IFloatArrayPublisher : IPublisher
{
    /**
     * Get the corresponding topic.
     *
     * @return Topic
     */

    new FloatArrayTopic Topic { get; }


    /**
     * Publish a new value using current NT time.
     *
     * @param value value to publish
     */
    void Set(params float[] value);

    /**
     * Publish a new value.
     *
     * @param value value to publish
     * @param time timestamp; 0 indicates current NT time should be used
     */
    void Set(long time, params float[] value);

    /**
     * Publish a default value.
     * On reconnect, a default value will never be used in preference to a
     * published value.
     *
     * @param value value
     */
    void SetDefault(params float[] value);
}
