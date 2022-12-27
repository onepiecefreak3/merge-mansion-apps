﻿using System.Collections.Generic;
using Metaplay.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Core.Message;

namespace Metaplay.Metaplay.Core.Client
{
    public class ClientSessionNegotiationResources
    {
        public Dictionary<ClientSlot, ConfigArchive> ConfigArchives; // 0x10
        public Dictionary<ClientSlot, GameConfigSpecializationPatches> PatchArchives; // 0x18

        public SessionProtocol.SessionResourceProposal ToResourceProposal(LanguageId clientActiveLanguage, ContentHash clientLocalizationVersion)
        {
            var dict = new Dictionary<ClientSlot, ContentHash>();
            var dict2 = new Dictionary<ClientSlot, ContentHash>();

            foreach (var value in ConfigArchives)
                dict[value.Key] = value.Value.Version;
            foreach (var value in PatchArchives)
                dict2[value.Key] = value.Value.Version;

            return new SessionProtocol.SessionResourceProposal(dict, dict2, clientActiveLanguage, clientLocalizationVersion);
        }

        public ClientSessionNegotiationResources()
        {
            ConfigArchives = new Dictionary<ClientSlot, ConfigArchive>();
            PatchArchives = new Dictionary<ClientSlot, GameConfigSpecializationPatches>();
        }
    }
}
