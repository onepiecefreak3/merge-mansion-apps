using System;
using Metaplay.Core.Config;

namespace Metaplay.Core
{
    public interface IMetaRef
    {
        Type ItemType { get; }
        object KeyObject { get; }
        bool IsResolved { get; }

        IMetaRef CreateResolved(IGameConfigDataResolver resolver);
    }
}
