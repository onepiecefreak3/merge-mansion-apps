using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.GameLogic.Config
{
    public interface IConfigItemSource<TConfigItem, TKey>
    {
        TKey SourceConfigKey { get; }
    }
}
