using Metaplay.Core.Model;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    public interface ISinkStateFactory
    {
        [IgnoreDataMember]
        IEnumerable<ValueTuple<ItemDefinition, int>> SinkProducts { get; }
    }
}