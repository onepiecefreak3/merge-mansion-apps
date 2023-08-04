using Metaplay.Core.Model;
using Metaplay.Core;
using GameLogic.Story;
using GameLogic.Decorations;

namespace GameLogic.Config
{
    [MetaSerializable]
    [MetaBlockedMembers(new int[] { 1 })]
    public class DecorationDialogueEntry
    {
        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaRef<StoryElementInfo> StoryInfo { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public MetaRef<DecorationInfo> DecorationInfo { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        public DirectorGroupId GroupId { get; set; }

        public DecorationDialogueEntry()
        {
        }

        public DecorationDialogueEntry(DirectorGroupId groupId, MetaRef<StoryElementInfo> storyInfo, MetaRef<DecorationInfo> decorationInfo)
        {
        }
    }
}