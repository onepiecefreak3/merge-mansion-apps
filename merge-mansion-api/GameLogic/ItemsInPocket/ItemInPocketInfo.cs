using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core;
using GameLogic.Player.Items;
using System;
using System.Collections.Generic;
using GameLogic.Player.Director.Config;

namespace GameLogic.ItemsInPocket
{
    [MetaSerializable]
    public class ItemInPocketInfo : IGameConfigData<ItemInPocketId>, IGameConfigData, IHasGameConfigKey<ItemInPocketId>
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public ItemInPocketId ConfigKey { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<ItemDefinition> ItemRef { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public bool IsNecessaryValidCoordinateToRunFromPocket { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public bool CanMoveToBoard { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public int PriorityInPocket { get; set; }

        [MetaMember(6, (MetaMemberFlags)0)]
        public List<IDirectorAction> ActionsToRunFromPocket { get; set; }

        public ItemInPocketInfo()
        {
        }

        public ItemInPocketInfo(ItemInPocketId itemInPocketId, MetaRef<ItemDefinition> itemRef, bool isNecessaryValidCoordinateToRunFromPocket, bool canMoveToBoard, int priorityInPocket, List<IDirectorAction> actionsToRunFromPocket)
        {
        }
    }
}