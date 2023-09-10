using Metaplay.Core.Model;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(1015)]
    public class PlayerPropertySurveyAborted : PlayerPropertyMatcher<int>
    {
        public override string DisplayName => $"Survey {_value} aborted";

        public PlayerPropertySurveyAborted()
        {
        }
    }
}