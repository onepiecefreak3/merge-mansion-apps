using System.Collections.Generic;

namespace Metaplay.Core.Config
{
	public interface IGameConfigLibrary : IGameConfigEntry // TypeDefIndex: 1190
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 0
        IEnumerable<KeyValuePair<object, object>> EnumerateAll();

        // RVA: -1 Offset: -1 Slot: 1
        object GetInfoByKey(object key);
    }
}
