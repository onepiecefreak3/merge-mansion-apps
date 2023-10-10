using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Code.GameLogic.Config;
using Metaplay.Core.Math;

namespace GameLogic.Cutscenes
{
    [MetaSerializable]
    public class CutsceneInfo : IGameConfigData<CutsceneId>, IGameConfigData, IGameConfigKey<CutsceneId>, IValidatable
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private CutsceneId CutsceneId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private CutsceneGroupId CutsceneGroupId { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        public F32 StartDelay { get; set; }
        public CutsceneId ConfigKey => CutsceneId;
        public CutsceneGroupId GroupId { get; }

        public CutsceneInfo()
        {
        }

        public CutsceneInfo(CutsceneId cutsceneId, CutsceneGroupId cutsceneGroupId, F32 startDelay)
        {
        }
    }
}