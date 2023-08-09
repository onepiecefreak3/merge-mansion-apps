using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum TOSAcceptance
    {
        NotShownYet = 0,
        AcceptedVersion1 = 1,
        AcceptedVersion2 = 2,
        AcceptedVersion3 = 3
    }
}