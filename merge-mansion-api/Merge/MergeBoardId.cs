using Code.GameLogic.GameEvents;
using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using Metaplay.Core;

namespace Merge
{
    [MetaSerializable]
    [MetaFormConfigLibraryItemReference(typeof(BoardInfo))]
    public class MergeBoardId : StringId<MergeBoardId>
    {
        public static MergeBoardId Garage;
        public static MergeBoardId None;
        public static MergeBoardId LegacyEventLindsay;
        public static MergeBoardId LegacyEventCaseySkatie;
        public static MergeBoardId LegacyEventIgnatious;
        public static MergeBoardId Test;
        public static MergeBoardId[] LegacyStoryEvents;
        public MergeBoardId()
        {
        }
    }
}