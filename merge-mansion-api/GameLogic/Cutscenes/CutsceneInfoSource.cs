using Code.GameLogic.Config;
using Metaplay.Core.Config;
using Metaplay.Core.Math;

namespace GameLogic.Cutscenes
{
    public class CutsceneInfoSource : IConfigItemSource<CutsceneInfo, CutsceneId>, IGameConfigSourceItem<CutsceneId, CutsceneInfo>, IHasGameConfigKey<CutsceneId>
    {
        private CutsceneId CutsceneId { get; set; }
        private CutsceneGroupId CutsceneGroupId { get; set; }
        private F32 StartDelay { get; set; }
        public CutsceneId ConfigKey { get; }

        public CutsceneInfoSource()
        {
        }

        private LocationId LocationId { get; set; }
    }
}