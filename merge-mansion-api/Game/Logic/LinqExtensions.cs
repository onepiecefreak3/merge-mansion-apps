using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Game.Logic
{
    public static class LinqExtensions
    {
        public static IEnumerable<(T, int)> CycleWithIndex<T>(this IList<T> source)
        {
            return source.Select((x, i) => (x, i));
        }
    }
}
