using Metaplay.Core.Model;
using GameLogic.Player.Items.Fishing;

namespace GameLogic
{
    [MetaSerializableDerived(5)]
    public class WeightCategoryArg : SerializableArg<WeightCategory>
    {
        private WeightCategoryArg()
        {
        }

        public WeightCategoryArg(WeightCategory value)
        {
        }
    }
}