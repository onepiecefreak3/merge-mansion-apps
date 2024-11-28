using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Collectable
{
    [MetaSerializable]
    public interface IProgressCollectAction : ICollectAction
    {
        int Progress { get; }
    }
}