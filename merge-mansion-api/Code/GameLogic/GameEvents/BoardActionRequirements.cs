using Metaplay.Core.Model;
using System.Collections.Generic;
using GameLogic.Player.Requirements;

namespace Code.GameLogic.GameEvents
{
    [MetaSerializable]
    public class BoardActionRequirements
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        private List<PlayerRequirement> AutospawnRequirements { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        private List<PlayerRequirement> ShopRequirements { get; set; }

        [MetaMember(3, (MetaMemberFlags)0)]
        private List<PlayerRequirement> EnergyModeRequirements { get; set; }

        [MetaMember(4, (MetaMemberFlags)0)]
        private List<PlayerRequirement> SellRequirements { get; set; }

        private BoardActionRequirements()
        {
        }

        public BoardActionRequirements(List<PlayerRequirement> autospawnRequirements, List<PlayerRequirement> shopRequirements, List<PlayerRequirement> energyModeRequirements, List<PlayerRequirement> sellRequirements)
        {
        }
    }
}