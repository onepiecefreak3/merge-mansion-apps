using Metaplay.Core;
using Metaplay.Core.Model;

namespace GameLogic.Config
{
    [MetaSerializable]
    public struct LoginDateTime
    {
        [MetaMember(1, 0)]
        public MetaTime Time { get; set; }
    }
}