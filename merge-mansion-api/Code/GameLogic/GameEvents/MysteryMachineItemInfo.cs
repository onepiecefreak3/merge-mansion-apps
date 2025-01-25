using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System.Collections.Generic;
using System;
using Metaplay.Core.Math;

namespace Code.GameLogic.GameEvents
{
    [MetaBlockedMembers(new int[] { 3 })]
    [MetaSerializable]
    public class MysteryMachineItemInfo : IGameConfigData<MysteryMachineItemId>, IGameConfigData, IHasGameConfigKey<MysteryMachineItemId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineItemId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public IMysteryMachineItem Item { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public F64 CameraMultiplier { get; set; }

        public MysteryMachineItemInfo()
        {
        }

        public MysteryMachineItemInfo(MysteryMachineItemId configKey, IMysteryMachineItem item, List<int> weights, F64 cameraMultiplier)
        {
        }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> WeightsBasedClicks { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<int> WeightsBasedHeat { get; set; }

        public MysteryMachineItemInfo(MysteryMachineItemId configKey, IMysteryMachineItem item, List<int> weightsBasedClicks, List<int> weightsBasedHeat, F64 cameraMultiplier)
        {
        }
    }
}