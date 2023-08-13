using Metaplay.Core.Model;

namespace GameLogic.Player.Items.Sink
{
    [MetaSerializable]
    public interface ISinkStateFactory
    {
        ItemDefinition SinkProduct { get; }
    }
}