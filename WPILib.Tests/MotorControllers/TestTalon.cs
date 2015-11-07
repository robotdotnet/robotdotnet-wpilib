﻿using HAL_Simulator;
using HAL_Simulator.Data;
using NUnit.Framework;
// ReSharper disable UnusedVariable

namespace WPILib.Tests.MotorControllers
{
    [TestFixture]
    public class TestTalon : TestBase
    {
        [Test]
        public void TestTalonInitialized()
        {
            using (Talon t = new Talon(2))
                Assert.AreEqual(SimData.PWM[2].Type, ControllerType.Talon);
        }

        [Test]
        public void TestTalonStarts0()
        {
            using (Talon t = new Talon(2))
            {
                Assert.AreEqual(t.Get(), 0);
            }
        }

        [Test]
        public void TestTalonSet()
        {
            using (Talon t = new Talon(2))
            {
                t.Set(1);
                Assert.AreEqual(t.Get(), 1);
            }
        }

        [Test]
        public void TestPWMHelpers()
        {
            using (Talon t = new Talon(2))
            {
                t.Set(1);
                Assert.AreEqual(SimData.PWM[2].Value, 1);
            }
        }

        [Test]
        public void TestPIDWrite()
        {
            using (Talon t = new Talon(2))
            {
                t.PidWrite(-1);

                Assert.AreEqual(t.Get(), -1);
            }
        }

        [Test]
        public void TestPWMHelpersPID()
        {
            using (Talon t = new Talon(2))
            {
                t.PidWrite(-1);
                Assert.AreEqual(SimData.PWM[2].Value, -1);
            }
        }
    }
}
