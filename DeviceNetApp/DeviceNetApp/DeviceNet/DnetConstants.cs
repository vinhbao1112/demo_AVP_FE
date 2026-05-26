using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceNetApp.DeviceNet
{
    public enum DNSDeviceType
    {
        Undefined = 0,
        SOLENOID_BLOCK = 1,
        ION_GAUGE = 2,
        CONVECTRON_GAUGE =3 ,
        VAT_VALVE = 4,
        MKS_MFC = 5,
        FLOWCOOL = 6,
        RSTi_ADAPTER = 7,
        MKS_BARATRON = 8,
        SOLENOID_BLOCK_EX260 = 9,
    }

    public enum enExplicitState
    {
        explicitIdle,
        explicitSent,
        explicitReady,
        explicitReceived
    };

    public enum DnetPollingGroup
    {
        Undefined = 0,
        Group1 = 1,
        Group2 = 2,
        Group3 = 3,
        Group4 = 4,
        Group5 = 5,
        Group6 = 6,
        GroupSolenoid = 7,
        GroupCGRelay = 8,
    }

    public enum DnetPollingType
    {
        Undefined = 0,
        Poll = 1,
        PollCGRelay = 2,
    }

    public class DeviceNetConstant
    {
        public const string SOLENOID_BLOCK_EX260_TYPE = "EX260";
    }
}
