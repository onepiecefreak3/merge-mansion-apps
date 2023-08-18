using Metaplay.Core.Message;
using Metaplay.Core.Model;

namespace Game.Logic.Message
{
    [MetaSerializableDerived(1)]
    public class SessionStartInfo : ISessionStartSuccessGamePayload
    {
        [MetaMember(1, 0)]
        public string SCIDGameAccountToken; // 0x10
        public SessionStartInfo()
        {
        }
    }
}