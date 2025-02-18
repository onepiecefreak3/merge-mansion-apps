using Metaplay.Core.Model;
using System;
using System.Collections.Generic;
using Metaplay.Core;
using GameLogic.Player.Items;
using Code.GameLogic.GameEvents;
using System.Runtime.Serialization;

namespace GameLogic.Player
{
    [MetaBlockedMembers(new int[] { 5, 10, 13 })]
    [MetaSerializable]
    public class Wallet
    {
        public PocketChangedEvent PocketContentChanged;
        public PocketChangedEvent EventPocketContentChanged;
        public PocketChangedEvent LiveOpsEventPocketContentChanged;
        public CurrencyAddedEvent CurrencyAdded;
        public CurrencyRemovedEvent CurrencyRemoved;
        [MetaMember(1, (MetaMemberFlags)0)]
        public long Coins { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public long Experience { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public long Diamonds { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<long> BoughtDiamonds { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public long Energy { get; set; }

        [MetaMember(7, (MetaMemberFlags)0)]
        private MetaTime? NextPossibleEnergyRefillTime { get; set; }

        [MetaMember(8, (MetaMemberFlags)0)]
        private List<int> PocketItems_DEPRECATED { get; set; }

        [MetaMember(9, (MetaMemberFlags)0)]
        private List<int> EventPocketItems_DEPRECATED { get; set; }

        [MetaMember(18, (MetaMemberFlags)0)]
        private List<IBoardItem> PocketItems { get; set; }

        [MetaMember(19, (MetaMemberFlags)0)]
        private List<IBoardItem> EventPocketItems { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        public long HardDiamonds { get; set; }

        [MetaMember(12, (MetaMemberFlags)0)]
        public long HardCoins { get; set; }

        [MetaMember(14, (MetaMemberFlags)0)]
        private Dictionary<EventCurrencyId, long> EventCurrencies { get; set; }

        [MetaMember(15, (MetaMemberFlags)0)]
        private Dictionary<EventCurrencyId, long> BoughtEventCurrencies { get; set; }

        [MetaMember(16, (MetaMemberFlags)0)]
        private List<AuthenticationPlatform> CollectedRewards { get; set; }

        [MetaMember(17, (MetaMemberFlags)0)]
        private List<long> BoughtCoins { get; set; }

        [IgnoreDataMember]
        public long TotalCoins { get; }

        [IgnoreDataMember]
        public long TotalDiamonds { get; }

        [IgnoreDataMember]
        public long PurchasedDiamondsSum { get; }

        [IgnoreDataMember]
        public long PurchasedCoinsSum { get; }

        [IgnoreDataMember]
        public IEnumerable<EventCurrencyId> AllEventCurrencies { get; }

        public Wallet()
        {
        }

        public Wallet(long coins, long experience, long diamonds, long energy)
        {
        }

        [MetaMember(21, (MetaMemberFlags)0)]
        public Dictionary<EnergyType, AuxEnergyState> AuxEnergyStates;
        [Obsolete("Replaced by AuxEnergyStates. Required for migration.")]
        [MetaMember(20, (MetaMemberFlags)0)]
        public SecondaryEnergyState SecondaryEnergyState_DEPRECATED { get; set; }

        [IgnoreDataMember]
        public LogChannel Log { get; set; }

        [IgnoreDataMember]
        public List<IBoardItem> PocketItemsNonAlloc { get; }

        [IgnoreDataMember]
        public List<IBoardItem> EventPocketItemsNonAlloc { get; }

        [IgnoreDataMember]
        public long[] CurrenciesGainedThisSession { get; set; }

        [IgnoreDataMember]
        public long[] CurrenciesSpentThisSession { get; set; }

        [IgnoreDataMember]
        public long[] CurrenciesDeltaThisSession { get; set; }

        [IgnoreDataMember]
        public long[] InitialCurrenciesThisSession { get; set; }

        [MetaMember(22, (MetaMemberFlags)0)]
        public long CardCollectionStars { get; set; }
    }
}