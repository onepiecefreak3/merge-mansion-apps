using Metaplay.Metaplay.Core;

namespace Metaplay.Game.Logic
{
    public class GlobalOptions : IMetaplayCoreOptionsProvider
    {
        public MetaplayCoreOptions Options => 
            new MetaplayCoreOptions("game5", "EWG5", new MetaVersionRange(0x36011, 0x36011), 1, 0x21, new[] { "Game.Logic", "GameLogic" }, new MetaplayFeatureFlags { EnableLocalizations = true });
    }
}
