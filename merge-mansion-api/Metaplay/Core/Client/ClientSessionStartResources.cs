using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.Core.Config;
using Metaplay.Core.Message;
using Metaplay.Core.Player;

namespace Metaplay.Core.Client
{
    public class ClientSessionStartResources
    {
        public readonly int LogicVersion; // 0x10
        public readonly Dictionary<ClientSlot, ISharedGameConfig> GameConfigs; // 0x18
        public readonly Dictionary<ClientSlot, ContentHash> GameConfigBaselineVersions; // 0x20
        public readonly Dictionary<ClientSlot, ContentHash> GameConfigPatchVersions; // 0x28

        public ClientSessionStartResources(int logicVersion,
            Dictionary<ClientSlot, ISharedGameConfig> gameConfigs,
            Dictionary<ClientSlot, ContentHash> gameConfigBaselineVersions,
            Dictionary<ClientSlot, ContentHash> gameConfigPatchVersions)
        {
            LogicVersion = logicVersion;
            GameConfigs = gameConfigs;
            GameConfigBaselineVersions = gameConfigBaselineVersions;
            GameConfigPatchVersions = gameConfigPatchVersions;
        }

        public static ClientSessionStartResources SpecializeResources(SessionProtocol.SessionStartSuccess sessionStartSuccess, ClientSessionNegotiationResources negotiationResources,
            Func<ConfigArchive, (GameConfigSpecializationPatches, GameConfigSpecializationKey)?, ISharedGameConfig> gameConfigImporter)
        {
            var gameConfigs = new Dictionary<ClientSlot, ISharedGameConfig>();
            var baselineVersions = new Dictionary<ClientSlot, ContentHash>();
            var patchVersions = new Dictionary<ClientSlot, ContentHash>();

            foreach (var configArchive in negotiationResources.ConfigArchives)
            {
                baselineVersions[configArchive.Key] = configArchive.Value.Version;

                Dictionary<PlayerExperimentId, ExperimentVariantId> expAssignment = null;
                if (configArchive.Key != ClientSlotCore.Player)
                {
                    foreach (var entityState in sessionStartSuccess.EntityStates)
                    {
                        if (configArchive.Key != entityState.ClientData.ClientSlot)
                            continue;

                        expAssignment = entityState.State.TryGetNonEmptyExperimentAssignment();
                        break;
                    }
                }
                else
                {
                    //if (sessionStartSuccess.ActiveExperiments != null)
                    //{
                    //    var assignments = sessionStartSuccess.ActiveExperiments.ToDictionary(x => x.ExperimentId, y => y.VariantId);
                    //    if (assignments.Count != 0)
                    //        expAssignment = assignments;
                    //}
                }

                // Z346
                var patches = negotiationResources.PatchArchives.GetValueOrDefault(configArchive.Key);
                if (expAssignment != null && patches == null)
                    throw new InvalidOperationException($"In slot {configArchive.Key} got experiment assignment but no patches");

                if (expAssignment == null)
                {
                    gameConfigs[configArchive.Key] = gameConfigImporter(configArchive.Value, null);
                }
                else
                {
                    var key = patches.CreateKeyFromAssignment(expAssignment);
                    var config = gameConfigImporter(configArchive.Value, (patches, key));

                    gameConfigs[configArchive.Key] = config;
                    patchVersions[configArchive.Key] = config.ArchiveVersion;
                }
            }

            return new ClientSessionStartResources(sessionStartSuccess.LogicVersion, gameConfigs, baselineVersions, patchVersions);
        }
    }
}
