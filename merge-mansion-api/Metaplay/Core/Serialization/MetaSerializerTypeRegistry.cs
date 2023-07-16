using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Serialization
{
    public class MetaSerializerTypeRegistry
    {
        private static MetaSerializerTypeInfo _typeInfo; // 0x0

        public static uint FullProtocolHash => _typeInfo.FullTypeHash; // 0x10
    }
}
