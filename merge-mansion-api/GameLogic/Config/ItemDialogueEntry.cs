using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Story;
using System.Collections.Generic;
using System;

namespace GameLogic.Config
{
    [MetaBlockedMembers(new int[] { 1, 3 })]
    [MetaSerializable]
    public class ItemDialogueEntry
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<StoryElementInfo> StoryInfo { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DirectorGroupId GroupId { get; set; }

        [MetaMember(5, (MetaMemberFlags)0)]
        public List<int> ItemTypes { get; set; }

        public ItemDialogueEntry()
        {
        }

        public ItemDialogueEntry(DirectorGroupId groupId, MetaRef<StoryElementInfo> storyInfo, List<int> itemTypes)
        {
        }
    }
}