using Metaplay.Unity.DefaultIntegration;

internal class GameLocalizationDelegate : DefaultMetaplayLocalizationDelegate
{
    public override bool AutoActivateLanguageUpdates => false;
}