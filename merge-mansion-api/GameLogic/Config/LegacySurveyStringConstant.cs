using Metaplay.Core.Model;
using Metaplay.Core.Player;
using System;

namespace GameLogic.Config
{
    [MetaSerializableDerived(9)]
    public class LegacySurveyStringConstant : PlayerPropertyConstant
    {
        public override object ConstantValue { get; }

        public LegacySurveyStringConstant()
        {
        }
    }
}