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
        [ValidateItemDefinitionMetaRef]
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int Amount { get; set; }

        [MetaFormNotEditable]
        [MetaMember(3, (MetaMemberFlags)0)]
        public bool FromSupport { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
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

        [MetaMember(6, (MetaMemberFlags)0)]
        private bool ForceOnTopOfPocket { get; set; }

        public RewardItem(MergeBoardId boardId, ItemDefinition itemDefinition, int amount, bool fromSupport, CurrencySource currencySource, bool forceOnTopOfPocket)
        {
        }

        public RewardItem(MergeBoardId boardId, MetaRef<ItemDefinition> itemRef, int amount, bool fromSupport, CurrencySource currencySource, OverrideItemFeatures overrideItemFeatures, bool forceOnTopOfPocket)
        {
        }

        [MetaMember(7, (MetaMemberFlags)0)]
        private string OverridePoolTag { get; set; }

        [IgnoreDataMember]
        public string PoolTag { get; }

        public RewardItem(MergeBoardId boardId, ItemDefinition itemDefinition, int amount, bool fromSupport, CurrencySource currencySource, bool forceOnTopOfPocket, string overridePoolTag)
        {
        }

        public RewardItem(MergeBoardId boardId, MetaRef<ItemDefinition> itemRef, int amount, bool fromSupport, CurrencySource currencySource, OverrideItemFeatures overrideItemFeatures, bool forceOnTopOfPocket, string overridePoolTag)
        {
        }

        public RewardItem(MergeBoardId boardId, ItemDefinition itemDefinition, int amount, bool fromSupport, CurrencySource currencySource, OverrideItemFeatures overrideItemFeatures, bool forceOnTopOfPocket, string overridePoolTag)
        {
        }

        [IgnoreDataMember]
        public override bool ShouldShowInfoButton { get; }
    }
}