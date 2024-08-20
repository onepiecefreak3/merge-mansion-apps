using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Production
{
    [MetaSerializable]
    public interface IOrderProducer
    {
        int OrderCount { get; }
    }
}