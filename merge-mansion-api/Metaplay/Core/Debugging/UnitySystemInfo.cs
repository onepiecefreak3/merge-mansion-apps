using Metaplay.Core.Model;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.Debugging
{
    [MetaSerializable]
    public class UnitySystemInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public float BatteryLevel { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public string DeviceModel { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string DeviceType { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int GraphicsDeviceId { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public string GraphicsDeviceName { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public string GraphicsDeviceType { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public string GraphicsDeviceVendor { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        public int GraphicsDeviceVendorId { get; set; }

        [MetaMember(10, (MetaMemberFlags)0)]
        public string GraphicsDeviceVersion { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public int GraphicsDeviceMemoryMegabytes { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public string OperatingSystem { get; set; }

        [MetaMember(13, (MetaMemberFlags)0)]
        public string OperatingSystemFamily { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        public int ProcessorCount { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        public int ProcessorFrequencyMhz { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        public string ProcessorType { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        public int SystemMemoryMegabytes { get; set; }

        [MetaMember(50, (MetaMemberFlags)0)]
        public int ScreenWidth { get; set; }

        [MetaMember(51, (MetaMemberFlags)0)]
        public int ScreenHeight { get; set; }

        [MetaMember(52, (MetaMemberFlags)0)]
        public float ScreenDPI { get; set; }

        [MetaMember(53, (MetaMemberFlags)0)]
        public string ScreenOrientation { get; set; }

        [MetaMember(54, (MetaMemberFlags)0)]
        public bool IsFullScreen { get; set; }

        public UnitySystemInfo()
        {
        }

        [IgnoreDataMember]
        private MetaTime _nextBatteryUpdateAt;
    }
}