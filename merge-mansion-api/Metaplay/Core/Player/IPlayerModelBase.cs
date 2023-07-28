using Metaplay.Core.Config;
using Metaplay.Core.Localization;

namespace Metaplay.Core.Player
{
    public interface IPlayerModelBase
    {
        // STUB

        // RVA: -1 Offset: -1 Slot: 9
        // RVA: -1 Offset: -1 Slot: 10
        ISharedGameConfig GameConfig { get; set; }

        // RVA: -1 Offset: -1 Slot: 34
        // RVA: -1 Offset: -1 Slot: 35
        LanguageId Language { get; set; }

        // RVA: -1 Offset: -1 Slot: 36
        // RVA: -1 Offset: -1 Slot: 37
        LanguageSelectionSource LanguageSelectionSource { get; set; }
    }
}
