using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Player.Modifiers
{
    [MetaSerializable]
    public interface IPlayerModifier
    {
        MetaTime ActivatedAt { get; }

        MetaDuration Duration { get; }
    }
}