using Metaplay.Core.Model;

namespace Metaplay.Core
{
    [MetaSerializable]
    public enum AuthenticationPlatform
    {
        DeviceId = 0,
        Development = 1,
        GooglePlay = 2,
        GameCenter = 3,
        GoogleSignIn = 4,
        SignInWithApple = 5,
        FacebookLogin = 6,
        SignInWithAppleTransfer = 7,
        GameCenter2020 = 8,
        GameCenter2020UAGT = 9,
        SupercellId = 10,
        Ethereum = 11,
        ImmutableX = 12,
        CompanyAccount = 13
    }
}