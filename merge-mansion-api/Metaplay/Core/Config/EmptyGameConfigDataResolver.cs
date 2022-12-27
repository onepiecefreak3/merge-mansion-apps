using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Config
{
    public class EmptyGameConfigDataResolver : IGameConfigDataResolver
    {
        public static readonly EmptyGameConfigDataResolver Instance = new EmptyGameConfigDataResolver();
        public object TryResolveReference(Type type, object configKey)
        {
            throw new NotImplementedException();
        }
    }
}
