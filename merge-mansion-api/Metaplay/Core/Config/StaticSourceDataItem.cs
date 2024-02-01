using System;

namespace Metaplay.Core.Config
{
    public class StaticSourceDataItem : IGameConfigSourceData
    {
        private object _data;
        public StaticSourceDataItem(object data)
        {
        }
    }
}