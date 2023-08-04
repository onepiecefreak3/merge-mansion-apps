using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.GameFeatures
{
    [MetaSerializable]
    public class GameFeatureState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime UnlockTime { get; set; }

        private GameFeatureState()
        {
        }

        public GameFeatureState(MetaTime unlockTime)
        {
        }
    }
}