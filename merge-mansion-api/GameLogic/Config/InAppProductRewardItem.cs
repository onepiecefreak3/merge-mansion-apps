using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializable]
    public class InAppProductRewardItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int ItemId;
        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount;
        public InAppProductRewardItem()
        {
        }
    }
}