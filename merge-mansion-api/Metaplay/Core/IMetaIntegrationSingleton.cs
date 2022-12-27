using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core
{
    public interface IMetaIntegrationSingleton<T> : IMetaIntegration<T>, IMetaIntegrationSingleton
    {
    }

    public interface IMetaIntegrationSingleton
    {
    }
}
