using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T, int)> ZipWithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((x, i) => (x, i));
        }
    }
}
