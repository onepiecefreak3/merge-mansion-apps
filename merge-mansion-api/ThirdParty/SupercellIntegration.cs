using System;
using Metaplay.Core;
using SCID;

namespace ThirdParty
{
    public class SupercellIntegration : ISupercellIdDelegate
    {
        private static readonly Lazy<SupercellIntegration> _lazy = new Lazy<SupercellIntegration>(() =>
        {
            InitDomain();
            return new SupercellIntegration();
        });

        public static SupercellIntegration Instance => _lazy.Value;

        private static void InitDomain() { }

        public SocialAuthenticationClaimBase GetCurrentAccountCredentials()
        {
            var currentAccount = SupercellId.CurrentAccount;
            if (currentAccount == null)
                return null;

            return new SocialAuthenticationClaimSupercellId(currentAccount.scidToken);
        }
    }
}
