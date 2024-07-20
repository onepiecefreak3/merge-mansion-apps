using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Math;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1044)]
    public class AverageDailyTimeNDays : TypedPlayerPropertyId<F64>
    {
        public override string DisplayName { get; }

        [MetaMember(1, (MetaMemberFlags)0)]
        private int Days { get; set; }

        public AverageDailyTimeNDays()
        {
        }

        public AverageDailyTimeNDays(int days)
        {
        }
    }
}