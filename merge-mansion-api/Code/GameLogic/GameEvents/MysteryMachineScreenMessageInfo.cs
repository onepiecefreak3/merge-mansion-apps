using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class MysteryMachineScreenMessageInfo : IGameConfigData<MysteryMachineScreenMessageId>, IGameConfigData, IHasGameConfigKey<MysteryMachineScreenMessageId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MysteryMachineScreenMessageId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MysteryMachineScreenMessageType MessageType { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public string MessageData { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaDuration FadeInDuration { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public MetaDuration DisplayDuration { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaDuration FadeOutDuration { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public MetaDuration DelayAfter { get; set; }

        public MysteryMachineScreenMessageInfo()
        {
        }

        public MysteryMachineScreenMessageInfo(MysteryMachineScreenMessageId configKey, MysteryMachineScreenMessageType messageType, string messageData, MetaDuration fadeInDuration, MetaDuration displayDuration, MetaDuration fadeOutDuration, MetaDuration delayAfter)
        {
        }
    }
}