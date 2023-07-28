using System;
using System.Text.RegularExpressions;
using Metaplay.Core.Localization;

namespace Metaplay.Core
{
    public class MetaplayCoreOptions
    {
        public static readonly Regex ProjectNameRegex = new Regex("^[a-zA-Z0-9_]+$"); // 0x0

        public readonly string ProjectName; // 0x10
        public readonly string GameMagic; // 0x18
        public readonly MetaVersionRange SupportedLogicVersions; // 0x20
        public readonly byte GuildInviteCodeSalt; // 0x28
        public readonly string[] SharedNamespaces; // 0x30
        public readonly LanguageId DefaultLanguage; // 0x38
        public readonly MetaplayFeatureFlags FeatureFlags; // 0x40

        public MetaplayCoreOptions(string projectName, string gameMagic, MetaVersionRange supportedLogicVersions, byte guildInviteCodeSalt, string[] sharedNamespaces, LanguageId defaultLanguage, MetaplayFeatureFlags featureFlags)
        {
            ProjectName = projectName ?? throw new ArgumentNullException(nameof(projectName));
            if (projectName == string.Empty) 
                throw new ArgumentException("ProjectName must be non-empty!", nameof(projectName));

            if(!ProjectNameRegex.IsMatch(projectName))
                throw new ArgumentException("ProjectName must only contain letters, numbers, and underscores!");

            GameMagic = gameMagic ?? throw new ArgumentNullException(nameof(gameMagic));
            if(gameMagic.Length!=4)
                throw new ArgumentException("GameMagic must be exactly 4 characters long");

            if (defaultLanguage != null)
                DefaultLanguage = defaultLanguage;

            SharedNamespaces = sharedNamespaces ?? throw new ArgumentNullException(nameof(sharedNamespaces));

            FeatureFlags = featureFlags;
            GuildInviteCodeSalt = guildInviteCodeSalt;

            SupportedLogicVersions = supportedLogicVersions ?? throw new ArgumentNullException(nameof(supportedLogicVersions));
        }
    }
}
