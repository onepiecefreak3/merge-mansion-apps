using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.GameLogic.Merge;
using Metaplay.GameLogic.Random;
using Metaplay.Metaplay.Core;

namespace Metaplay.GameLogic.Player.Items.Merging
{
    public static class MergeExtensions
    {
        public static MergeItem Combine(this ItemDefinition mergeProduct, MergeItem sourceItem, MergeItem targetItem,
            MetaTime timestamp, IGenerationContext generationContext, ItemVisibility itemVisibility)
        {
            // Combine decay
            var decayFeatures = mergeProduct.DecayFeatures;
            var sourceDecay = sourceItem.DecayState;
            var targetDecay = targetItem.DecayState;

            var resultDecay = decayFeatures.Combine(sourceDecay, targetDecay, timestamp);

            // Combine activation
            var activationFeatures = mergeProduct.ActivationFeatures;
            var sourceActivation = sourceItem.ActivationState;
            var sourceActivationStorage = sourceItem.ActivationStorageState;
            var targetActivation = targetItem.ActivationState;
            var targetActivationStorage = targetItem.ActivationStorageState;

            var resultActivation = ItemsExtensions.Combine(mergeProduct.ActivationFeatures, sourceActivation, sourceActivationStorage, targetActivation, targetActivationStorage, timestamp);

            // TODO: Implement more
            return null;
        }
    }
}
