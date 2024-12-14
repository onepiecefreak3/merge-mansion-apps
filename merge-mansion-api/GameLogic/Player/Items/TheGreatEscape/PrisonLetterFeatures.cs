using Metaplay.Core.Model;
using System;
using GameLogic.Player.Rewards;

namespace GameLogic.Player.Items.TheGreatEscape
{
    [MetaSerializable]
    public class PrisonLetterFeatures
    {
        public static PrisonLetterFeatures NoPrisonLetterFeatures;
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsPrisonerLetter { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public PlayerReward LetterReward { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public PrisonerType Prisoner { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public int BackupItem { get; set; }

        private PrisonLetterFeatures()
        {
        }

        public PrisonLetterFeatures(bool isPrisonerLetter, PlayerReward letterReward, PrisonerType prisonerType, int backupItem)
        {
        }
    }
}