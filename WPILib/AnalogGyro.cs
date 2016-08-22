﻿using System;
using HAL.Base;
using WPILib.Interfaces;
using WPILib.LiveWindow;

namespace WPILib
{
    /// <summary>
    /// Class for interfacing with an analog gyro to get robot heading.
    /// </summary>
    /// <remarks>
    /// Use a rate gyro to return the robots heading relative to a starting position.
    /// The Gyro class tracks the robots heading based on the starting position.As
    /// the robot rotates the new heading is computed by integrating the rate of
    /// rotation returned by the sensor.When the class is instantiated, it does a
    /// short calibration routine where it samples the gyro while at rest to
    /// determine the default offset.This is subtracted from each sample to
    /// determine the heading.
    /// </remarks>
    public class AnalogGyro : GyroBase, IPIDSource, ILiveWindowSendable
    {
        private const double DefaultVoltsPerDegreePerSecond = 0.007;

        /// <summary>
        /// The <see cref="WPILib.AnalogInput"/> that this gyro uses.
        /// </summary>
        protected AnalogInput AnalogInput;

        private int m_gyroHandle = 0;
        private readonly bool m_channelAllocated = false;

        /// <inheritdoc/>
        public override void Calibrate()
        {
            if (RobotBase.IsSimulation)
            {
                //In simulation, we do not have to do anything here.
                return;
            }

            int status = 0;
            HALAnalogGyro.HAL_CalibrateAnalogGyro(m_gyroHandle, ref status);

        }

        /// <summary>
        /// Creates a new Analog Gyro on the specified channel.
        /// </summary>
        /// <param name="channel">The channel the gyro is on (Must be an accumulator channel). [0..1] on RIO.</param>
        public AnalogGyro(int channel)
        {
            AnalogInput aIn = new AnalogInput(channel);
            try
            {
                CreateGyro(aIn);
            }
            catch 
            {
                aIn.Dispose();
                throw;
            }
            m_channelAllocated = true;
        }

        /// <summary>
        /// Creates a new Analog Gyro with an existing <see cref="WPILib.AnalogInput"/>.
        /// </summary>
        /// <param name="channel">The analog input this gyro is attached to.</param>
        public AnalogGyro(AnalogInput channel)
        {
            CreateGyro(channel);
        }

        private void CreateGyro(AnalogInput channel)
        {
            AnalogInput = channel;
            if (AnalogInput == null)
            {
                throw new ArgumentNullException(nameof(channel), "AnalogInput supplied to Gyro constructor is null");
            }
            if (!AnalogInput.IsAccumulatorChannel)
            {
                throw new ArgumentOutOfRangeException(nameof(channel), "Channel must be an accumulator channel");
            }

            if (m_gyroHandle == 0)
            {
                int status = 0;
                m_gyroHandle = HALAnalogGyro.HAL_InitializeAnalogGyro(channel.)
            }

            HAL.Base.HAL.Report(ResourceType.kResourceType_Gyro, (byte)AnalogInput.Channel);
            LiveWindow.LiveWindow.AddSensor("AnalogGyro", AnalogInput.Channel, this);

            Calibrate();
        }

        ///<inheritdoc/>
        public override void Reset() => AnalogInput?.ResetAccumulator();

        ///<inheritdoc/>
        public override void Dispose()
        {
            if (AnalogInput != null && m_channelAllocated)
            {
                AnalogInput.Dispose();
            }
            AnalogInput = null;
            base.Dispose();
        }

        ///<inheritdoc/>
        public override double GetAngle()
        {
            if (AnalogInput == null)
            {
                return 0.0;
            }
            else
            {
                if (RobotBase.IsSimulation)
                {
                    //Use our simulator hack.
                    return BitConverter.Int64BitsToDouble(AnalogInput.GetAccumulatorValue());
                }
                long rawValue = 0;
                uint count = 0;
                AnalogInput.GetAccumulatorOutput(ref rawValue, ref count);

                long value = rawValue - (long)(count * m_offset);

                double scaledValue = value
                                     * 1e-9
                                     * AnalogInput.LSBWeight
                                     * (1 << AnalogInput.AverageBits)
                                     / (AnalogInput.GlobalSampleRate * Sensitivity);

                return scaledValue;
            }
        }

        ///<inheritdoc/>
        public override double GetRate()
        {
            if (AnalogInput == null)
            {
                return 0.0;
            }
            else
            {
                if (RobotBase.IsSimulation)
                {
                    //Use our simulator hack
                    return BitConverter.ToSingle(BitConverter.GetBytes(AnalogInput.GetAccumulatorCount()), 0);
                }
                return (AnalogInput.GetAverageValue() - (m_center + m_offset))
                       * 1e-9
                       * AnalogInput.LSBWeight
                       / ((1 << AnalogInput.OversampleBits) * Sensitivity);
            }
        }

        /// <summary>
        /// Gets or sets the sensitivity of the gyroscope.
        /// </summary>
        public double Sensitivity { get; set; }

        private double Deadband
        {
            set
            {
                int deadband = (int)(value * 1e9 / AnalogInput.LSBWeight * (1 << AnalogInput.OversampleBits));
                AnalogInput.AccumulatorDeadband = deadband;
            }
        }
    }
}
