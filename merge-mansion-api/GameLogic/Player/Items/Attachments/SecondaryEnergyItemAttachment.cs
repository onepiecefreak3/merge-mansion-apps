using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializableDerived(1)]
    [Obsolete("Replaced by AuxEnergyItemAttachment. Required for migration.")]
    public class SecondaryEnergyItemAttachment : IItemAttachment
    {
        public static int GainOnConsumeAmount;
        public SecondaryEnergyItemAttachment()
        {
        }
    }
}