using Metaplay.Core.Model;
using System;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public struct EventCategoryInfo
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Category;
        [MetaMember(2, (MetaMemberFlags)0)]
        public string SubCategory;
    }
}