using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metaplay.Core.Config;

namespace Code.GameLogic.Config
{
    public interface IConfigItemSource<TConfigItem, TKey> : IGameConfigSourceItem<TKey, TConfigItem>, IGameConfigKey<TKey>
    {
    }
}