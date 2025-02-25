using Metaplay.Core.Model;
using System;
using GameLogic.Player.Items.Activation;
using GameLogic.Player.Items.Merging;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public class StorageState
    {
        public StorageState(StorageState container1, StorageState container2)
        {
            currentAmount = (container1?.currentAmount ?? 0) + (container2?.currentAmount ?? 0);
        }

        public bool IsFull(int maxLimit)
        {
            return maxLimit <= currentAmount;
        }

        [MetaMember(1, (MetaMemberFlags)0)]
        private int currentAmount;
        public StorageState()
        {
        }

        public StorageState(int amountInContainer)
        {
        }

        public StorageState(ActivationFeatures mergedFeatures, ActivationFeatures featuresA, StorageState stateA, ActivationFeatures featuresB, StorageState stateB, StorageActionType storageAction)
        {
        }

        public int GetCurrentAmount()
        {
            return currentAmount;
        }

        public StorageState(IActivationFeatures mergedFeatures, IActivationFeatures featuresA, StorageState stateA, IActivationFeatures featuresB, StorageState stateB, StorageActionType storageAction)
        {
        }
    }
}