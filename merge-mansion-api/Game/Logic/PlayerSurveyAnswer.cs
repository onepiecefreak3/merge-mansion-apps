using Metaplay.Core.Model;
using System.Collections.Generic;

namespace Game.Logic
{
    [MetaSerializable]
    public class PlayerSurveyAnswer
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public List<SurveyAnswerItem> Answers { get; set; }

        public PlayerSurveyAnswer()
        {
        }

        public PlayerSurveyAnswer(List<SurveyAnswerItem> surveyAnswerAnswers)
        {
        }
    }
}