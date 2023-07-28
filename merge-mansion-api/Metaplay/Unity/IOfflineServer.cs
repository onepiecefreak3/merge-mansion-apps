using System.Threading.Tasks;
using Metaplay.Core.Config;
using Metaplay.Core.Network;

namespace Metaplay.Unity
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
