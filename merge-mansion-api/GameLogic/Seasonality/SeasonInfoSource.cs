using Code.GameLogic.Config;
using Metaplay.Core.Config;
using System;
using System.Collections.Generic;

namespace GameLogic.Seasonality
{
    public class SeasonInfoSource : IConfigItemSource<SeasonInfo, SeasonId>, IGameConfigSourceItem<SeasonId, SeasonInfo>, IHasGameConfigKey<SeasonId>
    {
        private SeasonId SeasonId { get; set; }
        private string SeasonType { get; set; }
        private List<string> UnlockRequirementType { get; set; }
        private List<string> UnlockRequirementId { get; set; }
        private List<string> UnlockRequirementAmount { get; set; }
        private List<string> UnlockRequirementAux0 { get; set; }
        private List<string> StartAction { get; set; }
        private string CharacterConfig { get; set; }
        public SeasonId ConfigKey { get; }

        public SeasonInfoSource()
        {
        }
    }
}