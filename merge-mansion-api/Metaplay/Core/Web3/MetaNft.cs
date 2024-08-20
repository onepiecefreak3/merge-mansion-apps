using Metaplay.Core.Model;
using Metaplay.Core.Forms;
using System;
using System.Runtime.Serialization;

namespace Metaplay.Core.Web3
{
    [MetaReservedMembers(100, 200)]
    [MetaSerializable]
    public abstract class MetaNft : ISchemaMigratable
    {
        [MetaFormNotEditable]
        [MetaMember(100, (MetaMemberFlags)0)]
        public NftId TokenId;
        [MetaMember(101, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public EntityId OwnerEntity;
        [MetaMember(102, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public NftOwnerAddress OwnerAddress;
        [MetaMember(104, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public bool IsMinted;
        [MetaMember(103, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
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