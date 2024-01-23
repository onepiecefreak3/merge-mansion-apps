using Metaplay.Core.Model;
using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.Spawning
{
    [MetaSerializable]
    public class SpawnState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int currentCycleNumber;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int spawnInCurrentCycle;
        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaTime? nextEstimatedSpawnStorageFillTime;
        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaTime startTimeOfSpawnStorageFill;
        [MetaMember(5, (MetaMemberFlags)0)]
        private MetaDuration relativeTimeSpendOnSpawnStorageFill;
        [MetaMember(6, (MetaMemberFlags)0)]
        private int tempFillForSpawnStorage;
        [MetaMember(7, (MetaMemberFlags)0)]
        private MetaTime? estimatedDecayTime;
        [MetaMember(8, (MetaMemberFlags)0)]
        private MetaTime lastTimeAddTime;
        [MetaMember(9, (MetaMemberFlags)0)]
        private MetaTime? pausedUntil;
        private SpawnState()
        {
        }

        public SpawnState(MetaTime timestamp)
        {
        }

        public SpawnState(SpawnState other, MetaTime timestamp)
        {
        }

        [MetaMember(10, (MetaMemberFlags)0)]
        public ulong SpawnCount { get; set; }

        [MetaMember(11, (MetaMemberFlags)0)]
        private int customCycleMax;
        [MetaMember(12, (MetaMemberFlags)0)]
        private bool hasCustomCycleMax;
    }
}