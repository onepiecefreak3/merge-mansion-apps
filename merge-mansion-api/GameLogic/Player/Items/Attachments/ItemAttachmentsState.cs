using Metaplay.Core.Model;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Attachments
{
    [MetaSerializable]
    public class ItemAttachmentsState
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<IItemAttachment> Attachments { get; set; }

        public ItemAttachmentsState()
        {
        }
    }
}