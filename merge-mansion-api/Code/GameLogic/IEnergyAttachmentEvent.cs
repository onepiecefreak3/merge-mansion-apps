using GameLogic.Player;

namespace Code.GameLogic
{
    public interface IEnergyAttachmentEvent
    {
        EnergyType EnergyType { get; }
    }
}