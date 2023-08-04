using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Bubble
{
    [MetaSerializable]
    public class BubblesSetup : IGameConfigData<BubblesSetupId>, IGameConfigData
    {
        [MetaMember(1, 0)]
        public BubblesSetupId ConfigKey { get; set; }

        [MetaMember(2, 0)]
        public IBubbleLogic Logic { get; set; }

        public BubblesSetup()
        {
        }

        public BubblesSetup(BubblesSetupId configKey, IBubbleLogic logic)
        {
        }
    }
}