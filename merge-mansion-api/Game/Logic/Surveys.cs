using Metaplay.Core.Model;
using System;
using System.Collections.Generic;

namespace Game.Logic
{
    [MetaSerializable]
    public class Surveys
    {
        [MetaMember(3, (MetaMemberFlags)0)]
        public int ReadyCount;
        [MetaMember(4, (MetaMemberFlags)0)]
        public int AnsweredCount;
        [MetaMember(5, (MetaMemberFlags)0)]
        public int AbortedCount;
        [MetaMember(1, (MetaMemberFlags)0)]
        [ExcludeFromGdprExport]
        [NoChecksum]
        public HashSet<SurveyStatus> SurveyStatus { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public Dictionary<int, PlayerSurveyAnswer> PlayerSurveyAnswers { get; set; }

        public Surveys()
        {
        }
    }
}