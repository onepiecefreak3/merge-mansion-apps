using Metaplay.Core.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.GameLogic.Config;
using Metaplay.Core.Config;

namespace GameLogic.Config
{
    public class PlayerSegmentInfoSourceItem : PlayerSegmentBasicInfoSourceItemBase<PlayerSegmentInfo>, IConfigItemSource<PlayerSegmentInfo, PlayerSegmentId>, IGameConfigSourceItem<PlayerSegmentId, PlayerSegmentInfo>, IHasGameConfigKey<PlayerSegmentId>
    {
        public PlayerSegmentInfoSourceItem()
        {
        }
    }
}