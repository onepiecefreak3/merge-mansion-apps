using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1014)]
    public class PlayerPropertySurveyAnswered : PlayerPropertyMatcher<int>
    {
        public override string DisplayName => $"Survey {_value} answered";

        public PlayerPropertySurveyAnswered()
        {
        }
    }
}