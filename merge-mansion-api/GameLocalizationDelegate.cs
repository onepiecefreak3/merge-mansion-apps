using Metaplay.Metaplay.Unity.DefaultIntegration;

namespace Metaplay
{
    internal class GameLocalizationDelegate : DefaultMetaplayLocalizationDelegate
    {
        public override bool AutoActivateLanguageUpdates => false;
    }
}
