using Metaplay.Core.Model;

namespace Game.Cloud.Player
{
    [MetaSerializable]
    public enum PlayerNameValidationResult
    {
        Valid = 0,
        NoChange = 1,
        StaticCheckFailed = 2,
        ProfanityCheckFailed = 3,
        Error = 4,
        Timeout = 5,
        PlayerNameChangeDisabled = 6
    }
}