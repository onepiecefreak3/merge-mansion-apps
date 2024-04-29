using Metaplay.Core.Model;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineSaleFeatureId : StringId<MysteryMachineSaleFeatureId>
    {
        public static MysteryMachineSaleFeatureId Camera;
        public static MysteryMachineSaleFeatureId Spawnable;
        public MysteryMachineSaleFeatureId()
        {
        }
    }
}