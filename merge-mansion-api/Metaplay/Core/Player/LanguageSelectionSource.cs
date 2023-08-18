using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum LanguageSelectionSource
    {
        AccountCreationAutomatic = 0,
        ServerSideAutomatic = 1,
        UserDeviceAutomatic = 2,
        UserSelected = 3
    }
}