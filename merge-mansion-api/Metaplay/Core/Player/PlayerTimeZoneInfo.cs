using System;
using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public class PlayerTimeZoneInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaDuration CurrentUtcOffset { get; set; } // 0x10

        public PlayerTimeZoneInfo()
        {
        }

        public PlayerTimeZoneInfo(MetaDuration currentUtcOffset)
        {
            CurrentUtcOffset = currentUtcOffset;
        }

        public PlayerTimeZoneInfo GetCorrected()
        {
            return new PlayerTimeZoneInfo(Util.Clamp(CurrentUtcOffset, MetaDuration.FromHours(-18), MetaDuration.FromHours(18)));
        }

        public static PlayerTimeZoneInfo CreateForCurrentDevice()
        {
            var offset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
            var metaOffset = MetaDuration.FromMilliseconds((long)offset.TotalMilliseconds);
            return new PlayerTimeZoneInfo(metaOffset);
        }

        public static MetaDuration MinimumUtcOffset;
        public static MetaDuration MaximumUtcOffset;
    }
}