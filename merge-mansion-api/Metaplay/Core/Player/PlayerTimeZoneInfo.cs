using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    public class PlayerTimeZoneInfo
    {
        [MetaMember(1, 0)]
        public MetaDuration CurrentUtcOffset { get; set; } // 0x10

        public PlayerTimeZoneInfo() { }

        public PlayerTimeZoneInfo(MetaDuration currentUtcOffset)
        {
            CurrentUtcOffset = currentUtcOffset;
        }

        public PlayerTimeZoneInfo GetCorrected()
        {
            return new PlayerTimeZoneInfo(Util.Clamp(CurrentUtcOffset, MetaDuration.FromHours(-18), MetaDuration.FromHours(18)));
        }
    }
}
