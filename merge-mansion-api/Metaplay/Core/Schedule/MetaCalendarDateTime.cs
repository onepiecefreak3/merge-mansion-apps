using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Schedule
{
    public struct MetaCalendarDateTime
    {
        [MetaMember(1, 0)]
        public int Year { get; set; }
        [MetaMember(2, 0)]
        public int Month { get; set; }
        [MetaMember(3, 0)]
        public int Day { get; set; }
        [MetaMember(4, 0)]
        public int Hour { get; set; }
        [MetaMember(5, 0)]
        public int Minute { get; set; }
        [MetaMember(6, 0)]
        public int Second { get; set; }
	}
}
