using Metaplay.Core.Model;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializable]
    public class ThirdPartySurveyStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime Started { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime? Completed { get; set; }

        public ThirdPartySurveyStatus()
        {
        }

        public ThirdPartySurveyStatus(MetaTime started)
        {
        }
    }
}