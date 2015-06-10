﻿using System.Threading;
using static WPILib.Utility;

namespace WPILib.Internal
{
    /// <summary>
    /// Timer objects measure accumulated time in milliseconds.
    /// </summary>
    /// <remarks>    
    /// <para/>The timer object functions like a stopwatch.It can be started, stopped, and cleared.When the
    /// <para/>timer is running its value counts up in milliseconds.When stopped, the timer holds the current
    /// <para/>value. The implementation simply records the time when started and subtracts the current time
    /// <para/>whenever the value is requested.</remarks>
    public class HardwareTimer : Timer.IStaticInterface
    {
        /// <summary>
        /// Returns the system clock time in seconds.
        /// </summary>
        public double FPGATimestamp => FPGATime / 1000000.0;

        /// <summary>
        /// Returns the Match Time in seconds
        /// </summary>
        public double MatchTime => DriverStation.Instance.MatchTime;

        /// <summary>
        /// Pause the thread for a specified time
        /// </summary>
        /// <param name="seconds">Length of time to pause</param>
        public void Delay(double seconds)
        {
            try
            {
                Thread.Sleep((int)(seconds * 1e3));
            }
            catch (ThreadInterruptedException)
            {

            }
        }

        /// <summary>
        /// Creates a new Timer
        /// </summary>
        /// <returns>A new timer</returns>
        public Timer.Interface NewTimer()
        {
            return new TimerImpl();
        }

        /// <summary>
        /// A hardware timer implementation
        /// </summary>
        public class TimerImpl : Timer.Interface
        {
            private long m_startTime;
            private double m_accumulatedTime;
            private bool m_running;

            private object m_lockObject = new object();

            /// <summary>
            /// Create a new timer object
            /// </summary>
            /// <remarks>The timer starts at zero, and is initially not running</remarks>
            public TimerImpl()
            {
                Reset();
            }

            private static long MsClock => FPGATime / 1000;

            /// <summary>
            /// Get the current time from the timer
            /// </summary>
            /// <remarks>If clock is running, it returns the run time. If clock is 
            /// not running, it returns the time from when it was last stopped.</remarks>
            /// <returns>Current time in seconds</returns>
            public double Get()
            {
                lock (m_lockObject)
                {
                    if (m_running)
                    {
                        return ((MsClock - m_startTime) + m_accumulatedTime) / 1000.0;
                    }
                    else
                    {
                        return m_accumulatedTime;
                    }
                }
            }

            /// <summary>
            /// Reset the timer, and start the timer.
            /// </summary>
            public void Reset()
            {
                lock (m_lockObject)
                {
                    m_accumulatedTime = 0;
                    m_startTime = MsClock;
                }
            }

            /// <summary>
            /// Start the timer running
            /// </summary>
            public void Start()
            {
                lock (m_lockObject)
                {
                    m_startTime = MsClock;
                    m_running = true;
                }
            }

            /// <summary>
            /// Stop the timer
            /// </summary>
            public void Stop()
            {
                lock (m_lockObject)
                {
                    double temp = Get();
                    m_accumulatedTime = temp;
                    m_running = false;
                }
            }

            /// <summary>
            /// Check if the specified period has passed.
            /// If so, advance the start time by that period.
            /// </summary>
            /// <remarks>Advancing the period makes the start times not drift.</remarks>
            /// <param name="period">The period to check for (seconds)</param>
            /// <returns>If the period has passed.</returns>
            public bool HasPeriodPassed(double period)
            {
                lock (m_lockObject)
                {
                    if (Get() > period)
                    {
                        m_startTime += (long)(period * 1000);
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
