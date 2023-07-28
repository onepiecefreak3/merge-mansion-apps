namespace Metaplay.Unity
{
    public interface IMetaplayLocalizationDelegate
    {
        // RVA: -1 Offset: -1 Slot: 0
        bool AutoActivateLanguageUpdates { get; }

        // RVA: -1 Offset: -1 Slot: 1
        void OnInitialLanguageSet();

        // RVA: -1 Offset: -1 Slot: 2
        void OnActiveLanguageChanged();
    }
}
