using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public class GameConfigTopLevelDeduplicationStorage
    {
        public Dictionary<ConfigItemId, HashSet<ConfigItemId>> BaselineReferences;
        public Dictionary<ConfigItemId, HashSet<ConfigItemId>> BaselineReverseReferences;
        public GameConfigTopLevelDeduplicationStorage()
        {
        }
    }
}