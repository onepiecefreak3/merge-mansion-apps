using Metaplay.Core.Model;
using Metaplay.Core;

namespace GameLogic.Seasonality
{
    [MetaSerializable]
    public class SeasonId : StringId<SeasonId>
    {
        public SeasonId()
        {
        }
    }
}