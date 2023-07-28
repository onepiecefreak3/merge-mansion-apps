using System;
using System.Collections.Generic;
using Metaplay.Core.Activables;
using Metaplay.Core.Config;
using Metaplay.Core.Model;

namespace Metaplay.Core.Offers
{
    [MetaSerializable]
    public abstract class MetaOfferGroupInfoBase : IGameConfigData<MetaOfferGroupId>, IGameConfigPostLoad
    {
        [MetaMember(100, 0)]
        public MetaOfferGroupId GroupId { get; set; }
        [MetaMember(101, 0)]
        public string DisplayName { get; set; }
        [MetaMember(102, 0)]
        public string Description { get; set; }
        [MetaMember(103, 0)]
        public OfferPlacementId Placement { get; set; }
        [MetaMember(104, 0)]
        public int Priority { get; set; }
        [MetaMember(105, 0)]
        public List<MetaRef<MetaOfferInfoBase>> Offers { get; set; }
        [MetaMember(106, 0)]
        public MetaActivableParams ActivableParams { get; set; }

        public MetaOfferGroupId ConfigKey => GroupId;
        public void PostLoad()
        {
            throw new NotImplementedException();
        }
    }
}
