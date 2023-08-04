using Metaplay.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Core.Player
{
    public abstract class PlayerSegmentBasicInfoSourceItemBase<TPlayerSegmentInfo> : IGameConfigSourceItem<TPlayerSegmentInfo>, IMetaIntegrationConstructible<PlayerSegmentBasicInfoSourceItemBase<TPlayerSegmentInfo>>, IMetaIntegration<PlayerSegmentBasicInfoSourceItemBase<TPlayerSegmentInfo>>, IMetaIntegrationConstructible, IRequireSingleConcreteType
    {
    }
}
