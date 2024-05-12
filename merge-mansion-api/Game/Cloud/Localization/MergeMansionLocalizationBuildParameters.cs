using Metaplay.Core.Model;
using Metaplay.Core.Config;

namespace Game.Cloud.Localization
{
    [MetaSerializableDerived(101)]
    public class MergeMansionLocalizationBuildParameters : LocalizationsBuildParameters
    {
        public GameConfigHelper.SheetFilterDelegate SheetFilter;
        public MergeMansionLocalizationBuildParameters()
        {
        }
    }
}