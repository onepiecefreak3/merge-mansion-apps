using System;
using GameLogic.Player.Items.Activation;
using GameLogic.Player.Items.Decay;
using Metaplay.Core;

namespace GameLogic.Player.Items
{
    public static class ItemsExtensions
    {
        public static DecayState Combine(this DecayFeatures decayFeatures, DecayState existingState,
            DecayState newState, MetaTime timestamp)
        {
            // TODO: Implement DecayState combination
            return null;
        }

        public static (ActivationState, StorageState) Combine(ActivationFeatures activationFeatures,
            ActivationState sourceState, StorageState sourceStorage, ActivationState targetState,
            StorageState targetStorage, MetaTime timestamp)
        {
            if (!activationFeatures.Activable)
                return default;

            var resultStorage = new StorageState(sourceStorage, targetStorage);

            var betterActivationState = ActivationState.GetBetter(sourceState, targetState);
            var resultActivation = new ActivationState(betterActivationState, timestamp);

            // TODO: Implement
            //var nextSourceStep = sourceState.GetNextEstimatedActivationStorageFillStep();
            //var nextTargetStep = targetState.GetNextEstimatedActivationStorageFillStep();
            //resultActivation.nextEstimatedActivationStorageFillTime = GameLogicExtensions.MetaTimeMinIgnoreNone(nextSourceStep, nextTargetStep);

            return (resultActivation, resultStorage);
        }

        public static bool IsArtifactItem(this ItemDefinition itemDefinition)
        {
            var mergeMechanic = itemDefinition?.MergeFeatures?.Mechanic;
            if (mergeMechanic == null)
                return false; //throw new InvalidOperationException("itemDefinition, mergefeatures or mechanic is null!");

            // STUB
            return false;
        }

        public static ItemDefinition Deref(this MetaRef<ItemDefinition> definition)
        {
            var refer = definition.Ref;
            if (refer == null)
                throw new ArgumentNullException(nameof(definition.Ref));

            if (refer.ConfigKey == (int)ItemTypeConstant.None)
                return null;

            return refer;
        }
    }
}
