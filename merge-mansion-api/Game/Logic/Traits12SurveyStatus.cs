using Metaplay.Core.Model;
using Metaplay.Core;

namespace Game.Logic
{
    [MetaSerializable]
    public class Traits12SurveyStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public MetaTime Started { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public MetaTime? Completed { get; set; }

        public Traits12SurveyStatus()
        {
        }

        public Traits12SurveyStatus(MetaTime started)
        {
        }
    }
}