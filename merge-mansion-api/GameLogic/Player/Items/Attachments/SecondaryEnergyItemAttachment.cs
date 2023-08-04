using Metaplay.Core.Model;
using System;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializableDerived(1)]
    public class SecondaryEnergyItemAttachment : IItemAttachment
    {
        public static int GainOnConsumeAmount;
        public SecondaryEnergyItemAttachment()
        {
        }
    }
}