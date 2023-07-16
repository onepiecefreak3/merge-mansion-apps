namespace Metaplay.Metaplay.Unity.DefaultIntegration
{
    public class DefaultMetaplayLocalizationDelegate : IMetaplayLocalizationDelegate
    {
        public virtual bool AutoActivateLanguageUpdates => true;
        
        public virtual void OnInitialLanguageSet() { }
        
        public virtual void OnActiveLanguageChanged() { }
    }
}
