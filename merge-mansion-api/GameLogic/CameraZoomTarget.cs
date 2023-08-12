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
        Closest = 5,
        Zoom3_5 = 6,
        Zoom4_0 = 7,
        Zoom4_5 = 8,
        Zoom6_0 = 9,
        Zoom6_5 = 10,
        Zoom7_0 = 11,
        Zoom7_5 = 12,
        Zoom8_0 = 13,
        Zoom8_5 = 14,
        Zoom9_0 = 15,
        Zoom9_5 = 16,
        Zoom10_5 = 17
    }
}