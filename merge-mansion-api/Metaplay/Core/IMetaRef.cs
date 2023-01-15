using System;
using Metaplay.Metaplay.Core.Config;

namespace Metaplay.Metaplay.Core
{
    public interface IMetaRef
    {
        Type ItemType { get; }
        object KeyObject { get; }
        bool IsResolved { get; }

        IMetaRef CreateResolved(IGameConfigDataResolver resolver);
    }
}
