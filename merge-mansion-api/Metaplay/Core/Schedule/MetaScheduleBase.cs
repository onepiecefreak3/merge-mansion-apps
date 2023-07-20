using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Metaplay.Core.Schedule
{
    [MetaSerializable]
    public abstract class MetaScheduleBase
    {
        [MetaMember(100)]
        public MetaScheduleTimeMode TimeMode { get; set; }
    }
}
