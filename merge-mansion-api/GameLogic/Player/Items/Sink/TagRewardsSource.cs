using Code.GameLogic.Config;
using System;
using Metaplay.Core.Config;
using System.Collections.Generic;

namespace GameLogic.Player.Items.Sink
{
    public class TagRewardsSource : IConfigItemSource<TagRewardsInfo, string>, IGameConfigSourceItem<string, TagRewardsInfo>, IHasGameConfigKey<string>
    {
        public int TotalPoints;
        public string RewardTagName;
        public List<string> Item;
        public List<int> Weight;
        public string ConfigKey { get; set; }

        public TagRewardsSource()
        {
        }
    }
}