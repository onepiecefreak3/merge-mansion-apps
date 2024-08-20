using Metaplay.Core.Model;
using Metaplay.Core.Activables;
using System;
using System.Runtime.Serialization;

namespace GameLogic.MiniEvents
{
    [MetaSerializableDerived(15)]
    public class MiniEventModel : MetaActivableState<MiniEventId, MiniEventInfo>
    {
        private static byte InitialBoolFields;
        [MetaMember(1, (MetaMemberFlags)0)]
        public sealed override MiniEventId ActivableId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private byte BoolFields { get; set; }

        [IgnoreDataMember]
        public MiniEventInfo Info { get; }
        public bool StartNoted { get; set; }
        public bool EndNoted { get; set; }

        private MiniEventModel()
        {
        }

        public MiniEventModel(MiniEventInfo info)
        {
        }
    }
}