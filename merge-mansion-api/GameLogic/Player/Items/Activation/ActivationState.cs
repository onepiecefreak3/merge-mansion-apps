using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.GameLogic.Player.Items.Activation
{
    [MetaSerializable]
    public sealed class ActivationState
    {
        [MetaMember(1, 0)]
        private int currentCycleNumber { get; set; } // 0x10
        [MetaMember(2, 0)]
        private int activationInCurrentCycle { get; set; } // 0x14
        [MetaMember(3, 0)]
        internal MetaTime? nextEstimatedActivationStorageFillTime { get; set; }  // 0x18
        [MetaMember(4, 0)]
        private MetaTime startTimeOfActivationStorageFill { get; set; }  // 0x28
        [MetaMember(5, 0)]
        private MetaDuration relativeTimeSpendOnActivationStorageFill { get; set; }  // 0x30
        [MetaMember(6, 0)]
        private int tempFillForActivationStorage { get; set; }  // 0x38
        [MetaMember(8, 0)]
        private MetaTime lastTimeAddTime { get; set; }  // 0x40

        // Properties
        [MetaMember(7, 0)]
        public bool Paused { get; set; }    // 0x3C

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
            if (activationCycleData1 == null || activationCycleData2 != null &&
                activationCycleData2.currentCycleNumber <= activationCycleData1.currentCycleNumber &&
                (activationCycleData1.currentCycleNumber != activationCycleData2.currentCycleNumber ||
                 activationCycleData2.activationInCurrentCycle <= activationCycleData1.activationInCurrentCycle))
                return activationCycleData2;

            return activationCycleData1;
        }
    }
}
