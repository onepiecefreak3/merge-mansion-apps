using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Config
{
	public interface IGameConfigEntry // TypeDefIndex: 1189
    {
        // Methods

        // RVA: -1 Offset: -1 Slot: 0
        void ResolveMetaRefs(IGameConfigDataResolver resolver);

        // RVA: -1 Offset: -1 Slot: 1
        void PostLoad();

        // RVA: -1 Offset: -1 Slot: 2
        void BuildTimeValidate();
    }
}
