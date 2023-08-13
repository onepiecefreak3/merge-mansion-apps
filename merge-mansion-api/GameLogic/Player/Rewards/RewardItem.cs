using GameLogic.Merge;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System.Runtime.Serialization;
using Merge;
using System;

namespace GameLogic.Player.Rewards
{
    [MetaSerializableDerived(6)]
    public class RewardItem : PlayerReward
    {
        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(2, 0)]
        public int Amount { get; set; }

        [MetaMember(3, 0)]
        public bool FromSupport { get; set; }

        [MetaMember(4, 0)]
        public MergeBoardId MergeBoardId { get; set; }

        [MetaFormNotEditable]
        [MetaMember(5, (MetaMemberFlags)0)]
        public OverrideItemFeatures OverrideItemFeatures { get; set; }

        [IgnoreDataMember]
        public ItemDefinition Item { get; }

        public RewardItem()
        {
        }

        public RewardItem(MergeBoardId boardId, ItemDefinition itemDefinition, int amount, bool fromSupport, CurrencySource currencySource)
        {
        }

        public RewardItem(MergeBoardId boardId, MetaRef<ItemDefinition> itemRef, int amount, bool fromSupport, CurrencySource currencySource, OverrideItemFeatures overrideItemFeatures)
        {
        }
    }
}