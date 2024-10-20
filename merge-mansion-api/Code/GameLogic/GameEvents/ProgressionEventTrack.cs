using Metaplay.Core.Model;
using GameLogic;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    [ForceExplicitEnumValues]
    public enum ProgressionEventTrack
    {
        Free = 0,
        Track1 = 1,
        Track2 = 2
    }
}