using Metaplay.Core.Model;
using Metaplay.Core.Math;

namespace GameLogic.Player.Items.GemMining
{
    [MetaSerializable]
    public class GemState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public GemRarity GemRarity { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public F32? Weight { get; set; }

        private GemState()
        {
        }

        public GemState(GemRarity gemRarity, F32? weight)
        {
        }
    }
}