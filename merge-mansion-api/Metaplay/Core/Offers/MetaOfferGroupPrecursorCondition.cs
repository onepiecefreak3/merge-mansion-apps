using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Activables;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Offers
{
    [MetaSerializableDerived(1101)]
    public class MetaOfferGroupPrecursorCondition : MetaActivablePrecursorCondition<MetaOfferGroupId>
    {
    }
}
