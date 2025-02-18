using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [Obsolete("Replaced by AuxEnergyItemAttachment. Required for migration.")]
    [MetaSerializableDerived(1)]
    public class SecondaryEnergyItemAttachment : IItemAttachment
    {
        public static int GainOnConsumeAmount;
        public SecondaryEnergyItemAttachment()
        {
        }
    }
}