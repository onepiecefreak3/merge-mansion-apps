using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializableDerived(102)]
    [MetaImplicitMembersRange(200, 300)]
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