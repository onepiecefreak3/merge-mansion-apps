using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using Metaplay.Core;

namespace Code.GameLogic.GameEvents
{
    public class MysteryMachineScreenMessageSource : IConfigItemSource<MysteryMachineScreenMessageInfo, MysteryMachineScreenMessageId>, IGameConfigSourceItem<MysteryMachineScreenMessageId, MysteryMachineScreenMessageInfo>, IHasGameConfigKey<MysteryMachineScreenMessageId>
    {
        public MysteryMachineScreenMessageId ConfigKey { get; set; }
        private MysteryMachineScreenMessageType MessageType { get; set; }
        private string MessageData { get; set; }
        private MetaDuration FadeInDuration { get; set; }
        private MetaDuration DisplayDuration { get; set; }
        private MetaDuration FadeOutDuration { get; set; }
        private MetaDuration DelayAfter { get; set; }

        public MysteryMachineScreenMessageSource()
        {
        }
    }
}