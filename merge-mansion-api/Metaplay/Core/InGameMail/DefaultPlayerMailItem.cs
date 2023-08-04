using Metaplay.Core.Model;

namespace Metaplay.Core.InGameMail
{
    [MetaSerializableDerived(100)]
    public class DefaultPlayerMailItem : PlayerMailItem
    {
        public DefaultPlayerMailItem()
        {
        }

        public DefaultPlayerMailItem(MetaInGameMail contents, MetaTime sentAt)
        {
        }
    }
}