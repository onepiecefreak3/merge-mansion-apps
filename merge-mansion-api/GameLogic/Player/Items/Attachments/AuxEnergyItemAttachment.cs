using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializableDerived(2)]
    public class AuxEnergyItemAttachment : IItemAttachment
    {
        public static int GainOnConsumeAmount;
        [MetaMember(1, (MetaMemberFlags)0)]
        public EnergyType EnergyType { get; set; }

        public AuxEnergyItemAttachment()
        {
        }

        public AuxEnergyItemAttachment(EnergyType energyType)
        {
        }
    }
}