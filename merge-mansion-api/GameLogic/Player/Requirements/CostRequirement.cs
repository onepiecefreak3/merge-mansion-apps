using GameLogic.Config.Costs;
using Metaplay.Core.Model;

namespace GameLogic.Player.Requirements
{
    [MetaSerializableDerived(6)]
    [MetaSerializable]
    public class CostRequirement : PlayerRequirement
    {
        [MetaMember(1, 0)]
        public ICost RequiredCost { get; set; }

        public CostRequirement()
        {
        }

        public CostRequirement(ICost cost)
        {
        }
    }
}