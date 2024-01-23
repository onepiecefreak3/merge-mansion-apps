using GameLogic.ConfigPrefabs;
using GameLogic.Merge;
using Merge;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class EventCurrencyInfo : IGameConfigData<EventCurrencyId>, IGameConfigData, IGameConfigKey<EventCurrencyId>
    {
        [MetaMember(1, 0)]
        public EventCurrencyId EventCurrencyId { get; set; }

        [MetaMember(2, 0)]
        public string DisplayName { get; set; }

        [MetaMember(3, 0)]
        public string Description { get; set; }

        [MetaMember(4, 0)]
        public MergeBoardId EventBoardId { get; set; }

        [MetaMember(5, 0)]
        public string NameLocId { get; set; }

        [MetaMember(6, 0)]
        public string DescLocId { get; set; }

        [MetaMember(7, 0)]
        public ConfigAssetPackId AssetPackId { get; set; }
        public EventCurrencyId ConfigKey => EventCurrencyId;

        public EventCurrencyInfo()
        {
        }

        [MetaMember(8, (MetaMemberFlags)0)]
        public EventCurrencyDisplayKind DisplayKind { get; set; }
    }
}