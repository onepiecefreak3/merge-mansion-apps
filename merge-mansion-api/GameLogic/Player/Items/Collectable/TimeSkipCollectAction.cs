using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializableDerived(2)]
    [MetaSerializable]
    public class TimeSkipCollectAction : ICollectAction
    {
        [MetaMember(1, 0)]
        public MetaDuration DurationToSkip { get; set; }

        private TimeSkipCollectAction()
        {
        }

        public TimeSkipCollectAction(MetaDuration durationToSkip)
        {
        }
    }
}