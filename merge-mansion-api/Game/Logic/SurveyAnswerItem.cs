using Metaplay.Core.Model;
using System;

namespace Game.Logic
{
    [MetaSerializable]
    public class SurveyAnswerItem
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public string Answer { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        public int QuestionNo { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        [Transient]
        public string Explanation { get; set; }

        public SurveyAnswerItem()
        {
        }
    }
}