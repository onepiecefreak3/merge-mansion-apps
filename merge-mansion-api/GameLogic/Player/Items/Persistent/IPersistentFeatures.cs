using System;
using Metaplay.Core;

namespace GameLogic.Player.Items.Persistent
{
    public interface IPersistentFeatures
    {
        bool HasPersistentFeatures { get; }

        bool HasItemStates { get; }

        int DecayCycles { get; }

        int ItemStates { get; }

        MetaRef<ItemDefinition> ResetToItem { get; }
    }
}