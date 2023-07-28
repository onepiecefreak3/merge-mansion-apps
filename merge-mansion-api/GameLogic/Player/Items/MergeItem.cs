using System;
using GameLogic.Player.Items.Activation;
using GameLogic.Player.Items.Decay;
using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items
{
    [MetaSerializable]
    public sealed class MergeItem
    {
        private static readonly MetaTime guaranteedFuture; // 0x0
        private static readonly int[] mergeMathPrice = { 1, 2, 4, 6, 12, 25, 51, 102, 205, 410, 820, 1640, 3280, 6550, 13100, 26200, 52400, 104000, 209000, 419000 }; // 0x8

        [MetaMember(4, 0)]
        private MergeItemExtra extra { get; set; } // 0x20

        private MergeItemExtra Extra => extra ??= new MergeItemExtra();

        [MetaMember(1, 0)]
        public MetaRef<ItemDefinition> DefinitionRef { get; set; }

        public DecayState DecayState => Extra.DecayState;
        public ActivationState ActivationState => Extra.ActivationState;
        public StorageState ActivationStorageState => Extra.ActivationStorageState;

        public ItemDefinition Definition => DefinitionRef.Ref;

        public void ResetStates(MetaTime timestamp) { }

        public void FlushStorages() { }

        public bool IsActivationStorageFull()
        {
            return Extra.ActivationStorageState.IsFull(Definition.ActivationFeatures.StorageMax);
        }

        public int GetCurrentAmountInActivationStorage()
        {
            return Extra.ActivationStorageState.currentAmount;
        }

        public bool TryToFillActivationStorage(MetaTime timestamp)
        {
            // SDUB
            return false;
        }

        public int SellValue()
        {
            // CUSTOM: Use static SellValue, to statically allow getting sell price of item
            return SellValue(Definition);
        }

        internal static int SellValue(ItemDefinition itemDefinition)
        {
            var sellIndex = Math.Clamp(itemDefinition.LevelNumber - 1, 0, mergeMathPrice.Length - 1);
            return mergeMathPrice[sellIndex];
        }

        [MetaSerializable]

        class MergeItemExtra
        {
            [MetaMember(1, 0)]
            public DecayState DecayState; // 0x10
            [MetaMember(2, 0)]
            public ActivationState ActivationState; // 0x18

            [MetaMember(4, 0)]
            public StorageState ActivationStorageState; // 0x28
        }
    }
}
