using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Config
{
    [MetaReservedMembers(101, 200)]
    [MetaSerializable]
    public abstract class LocalizationsBuildParameters : IMetaIntegration<LocalizationsBuildParameters>, IMetaIntegration, IGameDataBuildParameters
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        [MetaFormLayoutOrderHint(-1)]
        [MetaFormExcludeDerivedType(new string[] { "Metaplay.Core.Config.GoogleSheetBuildSource" })]
        public GameConfigBuildSource DefaultSource;
        protected LocalizationsBuildParameters()
        {
        }
    }
}