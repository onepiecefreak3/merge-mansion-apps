using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Model;

namespace Metaplay.Game.Logic.Message
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
