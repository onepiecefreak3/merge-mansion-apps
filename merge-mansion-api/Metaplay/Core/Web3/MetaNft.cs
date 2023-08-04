using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.Web3
{
    [MetaSerializable]
    [MetaReservedMembers(100, 200)]
    public abstract class MetaNft : ISchemaMigratable
    {
        [MetaMember(100, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public NftId TokenId;
        [MetaFormNotEditable]
        [MetaMember(101, (MetaMemberFlags)0)]
        public EntityId OwnerEntity;
        [MetaFormNotEditable]
        [MetaMember(102, (MetaMemberFlags)0)]
        public NftOwnerAddress OwnerAddress;
        [MetaFormNotEditable]
        [MetaMember(104, (MetaMemberFlags)0)]
        public bool IsMinted;
        [MetaFormNotEditable]
        [MetaMember(103, (MetaMemberFlags)0)]
        public ulong UpdateCounter;
        [IgnoreDataMember]
        public NftMetadataImportContext MetadataImportContext { get; set; }

        [IgnoreDataMember]
        public NftSchemaMigrationContext SchemaMigrationContext { get; set; }

        protected MetaNft()
        {
        }
    }
}