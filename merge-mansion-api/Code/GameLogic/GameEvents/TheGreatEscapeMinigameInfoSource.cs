using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;

namespace Code.GameLogic.GameEvents
{
    public class TheGreatEscapeMinigameInfoSource : IConfigItemSource<TheGreatEscapeMinigameInfo, TheGreatEscapeMinigameId>, IGameConfigSourceItem<TheGreatEscapeMinigameId, TheGreatEscapeMinigameInfo>, IHasGameConfigKey<TheGreatEscapeMinigameId>
    {
        public TheGreatEscapeMinigameId ConfigKey { get; set; }
        public int ActionsPerActivation { get; set; }
        public int TotalActionsRequired { get; set; }
        public int TimePerActivation { get; set; }
        public string MinigamePortal { get; set; }
        public string MinigamePortalReplacement { get; set; }
        public string RewardType { get; set; }
        public string RewardId { get; set; }
        public string RewardAux0 { get; set; }
        public string RewardAux1 { get; set; }
        public int RewardAmount { get; set; }
        public int NumberOfActivations { get; set; }

        public TheGreatEscapeMinigameInfoSource()
        {
        }
    }
}