﻿using System;
using System.Runtime.InteropServices;
using HAL_Base;
using static HAL_Simulator.SimData;
using static HAL_Simulator.PortConverters;

// ReSharper disable RedundantAssignment
// ReSharper disable InconsistentNaming
// ReSharper disable CheckNamespace
#pragma warning disable 1591

namespace HAL_Simulator
{
    ///<inheritdoc cref="HAL"/>
    internal class HALSolenoid
    {

        internal static void Initialize(IntPtr library, ILibraryLoader loader)
        {
            HAL_Base.HALSolenoid.InitializeSolenoidPort = initializeSolenoidPort;
            HAL_Base.HALSolenoid.CheckSolenoidModule = checkSolenoidModule;
            HAL_Base.HALSolenoid.GetSolenoid = getSolenoid;
            HAL_Base.HALSolenoid.SetSolenoid = setSolenoid;
            HAL_Base.HALSolenoid.GetPCMSolenoidBlackList = getPCMSolenoidBlackList;
            HAL_Base.HALSolenoid.GetPCMSolenoidVoltageStickyFault = getPCMSolenoidVoltageStickyFault;
            HAL_Base.HALSolenoid.GetPCMSolenoidVoltageFault = getPCMSolenoidVoltageFault;
            HAL_Base.HALSolenoid.ClearAllPCMStickyFaults_sol = clearAllPCMStickyFaults_sol;
        }

        [CalledSimFunction]
        public static IntPtr initializeSolenoidPort(IntPtr port_pointer, ref int status)
        {
            SolenoidPort p = new SolenoidPort
            {
                port = GetHalPort(port_pointer)
            };
            status = 0;
            InitializeNewPCM(p.port.module);
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(p));
            Marshal.StructureToPtr(p, ptr, true);
            return ptr;
        }

        [CalledSimFunction]
        public static bool checkSolenoidModule(byte module)
        {
            return module < 63;
        }

        [CalledSimFunction]
        public static bool getSolenoid(IntPtr solenoid_port_pointer, ref int status)
        {
            status = 0;
            var p = GetSolenoidPort(solenoid_port_pointer);
            return halData["pcm"][p.port.module]["solenoid"][p.port.pin]["value"];
        }


        [CalledSimFunction]
        public static void setSolenoid(IntPtr solenoid_port_pointer, bool value,
            ref int status)
        {
            status = 0;
            var p = GetSolenoidPort(solenoid_port_pointer);
            halData["pcm"][p.port.module]["solenoid"][p.port.pin]["value"] = value;
        }

        [CalledSimFunction]
        public static int getPCMSolenoidBlackList(IntPtr solenoid_port_pointer, ref int status)
        {
            status = 0;
            return 0;
        }

        [CalledSimFunction]
        public static bool getPCMSolenoidVoltageStickyFault(IntPtr solenoid_port_pointer, ref int status)
        {
            status = 0;
            return false;
        }


        [CalledSimFunction]
        public static bool getPCMSolenoidVoltageFault(IntPtr solenoid_port_pointer, ref int status)
        {
            status = 0;
            return false;
        }


        [CalledSimFunction]
        public static void clearAllPCMStickyFaults_sol(IntPtr solenoid_port_pointer, ref int status)
        {
            status = 0;
        }
    }
}
