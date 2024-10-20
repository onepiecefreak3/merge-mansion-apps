using System.Collections.Generic;
using Game.Logic;
using GameLogic.Player.Board;
using GameLogic.Random;
using Metaplay.Core.Session;
using System;
using GameLogic.Player.DailyTasks;
using GameLogic.GameFeatures;
using Metaplay.Core;
using Metaplay.Core.Player;
using GameLogic.Offers;
using GameLogic.Player.Modifiers;
using Game.Logic.Mail;
using Code.GameLogic.GameEvents;
using GameLogic.Banks;
using GameLogic.Player.Director.Actions;
using GameLogic.Player.Director.Conditions;
using GameLogic.Player.Modes;
using Code.GameLogic.DynamicEvents;
using GameLogic.Player.DailyTasksV2;
using System.Runtime.CompilerServices;
using GameLogic.Config.EnergyModeEvent;
using GameLogic.Player.Events;
using GameLogic.MiniEvents;
using Code.GameLogic.Player.Events.DailyScoopEvent;
using GameLogic.Player.Items;

namespace GameLogic.Player
{
    public interface IPlayer : IGenerationContext
    {
        SpawnFactoryState SpawnFactoryState { get; }

        // TODO: Import player board
        IEnumerable<IBoard> Boards { get; }

        PlayerIdentity PlayerIdentity { get; }

        SessionToken SessionToken { get; }

        int LogicVersion { get; }

        int PlayerLevel { get; }

        Wallet Wallet { get; }

        ProgressState ProgressState { get; }

        DailyTaskStatus DailyTaskStatus { get; }

        StoreStatus StoreStatus { get; }

        GameSettings GameSettings { get; }

        GameFeaturesStates UnlockedFeatures { get; }

        MetaTime CurrentTime { get; }

        PlayerLocalTime CurrentLocalTime { get; }

        IEnumerable<IActiveOfferGroup> ActiveOfferGroups { get; }

        IEnumerable<IPlayerModifier> ActiveModifiers { get; }

        LogChannel Log { get; }

        IPlayerModelClientListener ClientListener { get; }

        IPlayerModelServerListener ServerListener { get; }

        IEnumerable<ValueTuple<IBoard, MetaTime?>> BoardsWithExpirationTimes { get; }

        IEnumerable<IMailMessage> MailMessages { get; }

        IEnumerable<GarageCleanupEventModel> ActiveGarageCleanups { get; }

        IEnumerable<BoardEventModel> ActiveBoardEvents { get; }

        IEnumerable<CollectibleBoardEventModel> ActiveCollectibleBoardEvents { get; }

        IEnumerable<LeaderboardEventModel> ActiveLeaderboardEvents { get; }

        IEnumerable<ShopEventModel> ActiveShopEvents { get; }

        IEnumerable<ProgressionEventModel> ActiveProgressionEvents { get; }

        PlayerProgressionEventsModel ProgressionEvents { get; }

        PlayerCollectibleBoardEventsModel CollectibleBoardEvents { get; }

        CurrencyBanksModel CurrencyBanksModel { get; }

        CurrencyBankModel CurrencyBankModel { get; }

        string PlayerName { get; }

        ValueTuple<BoardInventory, MetaTime?> RentableInventory { get; }

        int ProgressionEventIAPStreakLength { get; }

        BoardInventory GarageBoardInventory { get; }

        BoardInventory GarageBoardProducerInventory { get; }

        HashSet<PlayerModeId> ActiveModes { get; }

        DynamicEventTaskStatus DynamicEventTaskStatus { get; }

        PlayerModifiersChangedEvent ModifiersChanged { get; set; }

        PlayerModesChangedEvent ModesChanged { get; set; }

        OverrideSpawnItemsStatus OverrideSpawnItemsStatus { get; }

        IEnumerable<SideBoardEventModel> ActiveSideBoardEvents { get; }

        Dictionary<int, RandomPCG> RandomsByFishingRodType { get; set; }

        List<IPlayerModifier> ActiveModifiersNonAlloc { get; }

        IEnumerable<GarageCleanupEventModel> AllGarageCleanups { get; }

        IEnumerable<SideBoardEventModel> AllSideBoardEvents { get; }

        IEnumerable<MysteryMachineEventModel> ActiveMysteryMachineEvents { get; }

        RandomPCG MysteryMachineRandom { get; }

        List<BoardInventory.ProducerInventorySlotState> ProducerInventoryEntries { get; }

        DailyTasksV2Status DailyTasksV2Status { get; }

        PlayerEnergyModeEventsModel EnergyModeEvents { get; }

        IEnumerable<SoloMilestoneEventModel> ActiveSoloMilestoneEvents { get; }

        IEnumerable<MiniEventModel> ActiveMiniEvents { get; }

        PlayerBoardEventsModel BoardEvents { get; }

        PlayerLeaderboardEventsModel LeaderboardEvents { get; }

        PlayerMysteryMachineEventsModel MysteryMachineEvents { get; }

        RandomPCG SoloMilestoneRandom { get; }

        PlayerMiniEventOverrides MiniEventOverrides { get; }

        IEnumerable<DailyScoopEventModel> ActiveDailyScoopEvents { get; }

        Dictionary<Coordinate, MergeItem> BubblesWithAds { get; }
    // Slot: 50
    //void AddScriptedEvent(IScriptedEventCondition condition, ISerializedAction action);
    }
}