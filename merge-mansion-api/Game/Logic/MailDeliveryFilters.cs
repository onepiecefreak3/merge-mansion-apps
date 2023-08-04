using Metaplay.Core.Model;
using System.Collections.Generic;
using System;

namespace Game.Logic
{
    [MetaSerializable]
    public class MailDeliveryFilters
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<string> Os { get; set; }

        public MailDeliveryFilters()
        {
        }
    }
}