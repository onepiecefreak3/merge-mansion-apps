using Metaplay.Core;
using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Activation
{
    [MetaSerializable]
    public sealed class ActivationState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private int currentCycleNumber;
        [MetaMember(2, (MetaMemberFlags)0)]
        private int activationInCurrentCycle;
        [MetaMember(3, (MetaMemberFlags)0)]
        private MetaTime? nextEstimatedActivationStorageFillTime;
        [MetaMember(4, (MetaMemberFlags)0)]
        private MetaTime startTimeOfActivationStorageFill;
        [MetaMember(5, (MetaMemberFlags)0)]
        private MetaDuration relativeTimeSpendOnActivationStorageFill;
        [MetaMember(6, (MetaMemberFlags)0)]
        private int tempFillForActivationStorage;
        [MetaMember(8, (MetaMemberFlags)0)]
        private MetaTime lastTimeAddTime;
        // Properties
        [MetaMember(7, 0)]
        public bool Paused { get; set; } // 0x3C

        public ActivationState(ActivationState other, MetaTime timestamp)
        {
            currentCycleNumber = other?.currentCycleNumber ?? 0;
            currentCycleNumber = other?.activationInCurrentCycle ?? 0;
            nextEstimatedActivationStorageFillTime = other?.nextEstimatedActivationStorageFillTime ?? default;
            startTimeOfActivationStorageFill = other?.startTimeOfActivationStorageFill ?? MetaTime.Epoch;
            relativeTimeSpendOnActivationStorageFill = other?.relativeTimeSpendOnActivationStorageFill ?? MetaDuration.Zero;
            tempFillForActivationStorage = other?.tempFillForActivationStorage ?? 0;
            lastTimeAddTime = other?.lastTimeAddTime ?? timestamp;
            Paused = other?.Paused ?? false;
        }

        public static ActivationState GetBetter(ActivationState activationCycleData1, ActivationState activationCycleData2)
        {
            if (activationCycleData1 == null || activationCycleData2 != null && activationCycleData2.currentCycleNumber <= activationCycleData1.currentCycleNumber && (activationCycleData1.currentCycleNumber != activationCycleData2.currentCycleNumber || activationCycleData2.activationInCurrentCycle <= activationCycleData1.activationInCurrentCycle))
                return activationCycleData2;
            return activationCycleData1;
        }

        private ActivationState()
        {
        }

        public ActivationState(MetaTime timestamp)
        {
        }
    }
}