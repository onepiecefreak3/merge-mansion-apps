using Metaplay.Core.Message;
using Metaplay.Core.Model;

namespace Game.Logic.Message
{
	[MetaSerializableDerived(1)]
	[MetaSerializable]
    public class SessionStartInfo : ISessionStartSuccessGamePayload
    {
        // Fields
        [MetaMember(1, 0)]
        public string SCIDGameAccountToken; // 0x10
    }
}
