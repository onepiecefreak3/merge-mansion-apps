using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializableDerived(2)]
    public class AuxEnergyItemAttachment : IItemAttachment
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        public AuxEnergyItemAttachment()
        {
        }

        public AuxEnergyItemAttachment(EnergyType energyType)
        {
        }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int EnergyAmount { get; set; }

        public AuxEnergyItemAttachment(EnergyType energyType, int energyAmount)
        {
        }
    }
}