using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Network;

namespace Metaplay.Metaplay.Unity
{
    public interface IOfflineServer : IMessageTransport
    {
        // Slot: 0
        ConfigArchive GameConfigArchive { get; }

        // Slot: 1
        Task InitializeAsync();

        // Slot: 2
        void Update();
    }
}
