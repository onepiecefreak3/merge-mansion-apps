using GameLogic;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [ForceExplicitEnumValues]
    [MetaSerializable]
    public enum MuseumShelfRewardState
    {
        NoneClaimed = 0,
        NormalClaimed = 1,
        AllClaimed = 2
    }
}