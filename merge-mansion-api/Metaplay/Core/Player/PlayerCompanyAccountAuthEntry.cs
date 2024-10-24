using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaImplicitMembersRange(200, 300)]
    [MetaSerializableDerived(102)]
    public class PlayerCompanyAccountAuthEntry : PlayerAuthEntryBase
    {
        private PlayerCompanyAccountAuthEntry()
        {
        }

        public PlayerCompanyAccountAuthEntry(MetaTime attachedAt)
        {
        }
    }
}