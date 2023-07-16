﻿using System;
using Metaplay.Metaplay.Core;
using Metaplay.Metaplay.Core.Localization;

namespace Metaplay.Game.Logic
{
    public class GlobalOptions : IMetaplayCoreOptionsProvider
    {
        // CUSTOM: Constants for default value from external loading
        private const int MinVersion_ = 230601;
        private const int MaxVersion_ = 230601;

        public static int MinVersion = -1;
        public static int MaxVersion = -1;

        // CUSTOM: Logic to allow loading of options from external sources
        public MetaplayCoreOptions Options =>
            new MetaplayCoreOptions("game5", "EWG5", GetMetaVersionRange(), 0x21, new[] { "Game.Logic", "GameLogic" }, LanguageId.FromString("en"), new MetaplayFeatureFlags { EnableLocalizations = true, EnablePlayerLeagues = true });

        // CUSTOM: Load version range externally
        private static MetaVersionRange GetMetaVersionRange()
        {
            var minVersion = Math.Max(MinVersion, MinVersion_);
            var maxVersion = Math.Max(MaxVersion, MaxVersion_);

            return new MetaVersionRange(minVersion, maxVersion);
        }
    }
}
