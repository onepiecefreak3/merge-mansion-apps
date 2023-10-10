using Metaplay.Core.Model;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(1)]
    public class MMLogData : AdditionalMessageData
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public BuildLogCode LogCode { get; set; }

        public MMLogData(BuildLogCode logCode)
        {
        }

        public MMLogData()
        {
        }
    }
}