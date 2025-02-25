using Metaplay.Core.Model;
using System;
using GameLogic.CardCollection;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class DuplicateRewardPair
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int regular;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int special;
        public DuplicateRewardPair()
        {
        }

        public DuplicateRewardPair(CardCollectionDuplicateRewardInfo duplicateRewardInfo)
        {
        }
    }
}