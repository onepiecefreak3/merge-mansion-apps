using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum SpawnStyle
    {
        NoSpawn = 0,
        NearHorizontalAndVertical = 1,
        Near3x3 = 2,
        Near3x3Bigger = 3,
        Near5x5 = 4,
        RandomSpot = 5
    }
}