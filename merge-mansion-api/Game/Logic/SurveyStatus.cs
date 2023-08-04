using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [MetaSerializable]
    public class SurveyStatus
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public int SurveyId { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public SurveyCompletionStatus Status { get; set; }

        public SurveyStatus()
        {
        }
    }
}