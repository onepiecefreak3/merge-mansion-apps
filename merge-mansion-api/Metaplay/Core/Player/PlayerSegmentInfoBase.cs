using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Player
{
    [MetaSerializable]
    public abstract class PlayerSegmentInfoBase: IGameConfigData<PlayerSegmentId>
    {
        [MetaMember(100)]
        public PlayerSegmentId SegmentId { get; set; }
        [MetaMember(103)]
        public PlayerCondition PlayerCondition { get; set; }
        [MetaMember(102)]
        public string DisplayName { get; set; }
        [MetaMember(101)]
        public string Description { get; set; }

        public PlayerSegmentId ConfigKey => SegmentId;
    }
}
