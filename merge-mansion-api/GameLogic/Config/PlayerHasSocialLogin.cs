using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1024)]
    public class PlayerHasSocialLogin : PlayerPropertyMatcher<LoginDateTime>
    {
    }
}
