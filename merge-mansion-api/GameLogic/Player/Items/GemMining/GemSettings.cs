using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using System;

namespace GameLogic.Player.Items.GemMining
{
    [MetaSerializable]
    public class GemSettings : GameConfigKeyValue<GemSettings>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int[] GemWeightCategorySizePercentages { get; set; }

        public GemSettings()
        {
        }
    }
}