using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Player;

namespace merge_mansion_cli.Models.Item
{
    class ItemDropModel
    {
        public int MaxStorage { get; set; }
        public int CycleAmount { get; set; }
        public DurationModel Delay { get; set; }
        public IDictionary<ItemType, double> Odds { get; set; }
    }

    class DurationModel
    {
        private const int MilliInHour_ = 1000 * 60 * 60;
        private const int MilliInMinute_ = 1000 * 60;
        private const int MilliInSecond_ = 1000;

        public long Hours { get; set; }
        public long Minutes { get; set; }
        public long Seconds { get; set; }

        public DurationModel(MetaDuration duration)
        {
            Hours = duration.Milliseconds / MilliInHour_;
            Minutes = (duration.Milliseconds - Hours * MilliInHour_) / MilliInMinute_;
            Seconds = (duration.Milliseconds - (Hours * MilliInHour_ + Minutes * MilliInMinute_)) / MilliInSecond_;
        }
    }
}
