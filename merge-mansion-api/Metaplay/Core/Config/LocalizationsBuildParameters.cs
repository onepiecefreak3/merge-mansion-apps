using Metaplay.Core.Model;
using Metaplay.Core.Forms;

namespace Metaplay.Core.Config
{
    [MetaSerializable]
    [MetaReservedMembers(101, 200)]
    public abstract class LocalizationsBuildParameters : IMetaIntegration<LocalizationsBuildParameters>, IMetaIntegration, IGameDataBuildParameters
    {
        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaValidateRequired]
        [MetaFormLayoutOrderHint(-1)]
        public GameConfigBuildSource DefaultSource;
        protected LocalizationsBuildParameters()
        {
        }
    }
}