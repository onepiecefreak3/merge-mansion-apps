using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Config
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
