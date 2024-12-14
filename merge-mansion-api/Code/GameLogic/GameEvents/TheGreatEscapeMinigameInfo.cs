using Metaplay.Core.Model;
using Metaplay.Core.Config;
using System;
using GameLogic.Player.Rewards;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class TheGreatEscapeMinigameInfo : IGameConfigData<TheGreatEscapeMinigameId>, IGameConfigData, IHasGameConfigKey<TheGreatEscapeMinigameId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public TheGreatEscapeMinigameId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int ActionsPerActivation { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public int TotalActionsRequired { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int TimerPerActivation { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public PlayerReward MinigameReward { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public int MinigamePortal { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        public int MinigamePortalReplacement { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        public int NumberOfActivations { get; set; }

        public TheGreatEscapeMinigameInfo()
        {
        }

        public TheGreatEscapeMinigameInfo(TheGreatEscapeMinigameId configKey, int actionsPerActivation, int totalActionsRequired, int timerPerActivation, PlayerReward minigameReward, int minigamePortal, int minigamePortalReplacement, int numberOfActivations)
        {
        }
    }
}