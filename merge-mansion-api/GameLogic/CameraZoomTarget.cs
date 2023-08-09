using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum CameraZoomTarget
    {
        None = 0,
        Default = 1,
        Wide = 2,
        Garage = 3,
        Area = 4,
        Closest = 5
    }
}