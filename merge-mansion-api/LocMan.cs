using System;
using System.Collections.Generic;
using System.Linq;
using Metaplay.GameLogic.Area;
using Metaplay.GameLogic.MergeChains;
using Metaplay.GameLogic.Player.Items;
using Metaplay.Metaplay.Core.Localization;
using Metaplay.Metaplay.Unity;
using Metaplay.UnityEngine;

namespace Metaplay
{
    public static class LocMan
    {
        // Fields
        private static readonly string iconEnergy = "<sprite=\"Icons\" name=\"Energy\">"; // 0x0
        private static readonly string iconGold = "<sprite=\"Icons\" name=\"Gold\">"; // 0x8
        private static readonly string iconDiamond = "<sprite=\"Icons\" name=\"Diamond\">"; // 0x10
        private static readonly string iconStar = "<sprite=\"Icons\" name=\"Star\">"; // 0x18

        // Properties
        public static Dictionary<LocalizationLanguageMetacore, (string filename, string localName, LanguageId languageId)>
            languageConfigs => LocCommon.languageConfigs;

        public static LocalizationLanguageMetacore ActiveLocalizationLanguageMetacore =>
            LocCommon.languageConfigs.FirstOrDefault(x => x.Value.languageId.Equals(MetaplaySDK.ActiveLanguage.LanguageId)).Key;

        public static LocalizationLanguageMetacore DetectLanguage()
        {
            switch (Application.SystemLanguage)
            {
                case SystemLanguage.French:
                    return LocalizationLanguageMetacore.French;

                case SystemLanguage.German:
                    return LocalizationLanguageMetacore.German;

                case SystemLanguage.Italian:
                    return LocalizationLanguageMetacore.Italian;

                case SystemLanguage.Japanese:
                    return LocalizationLanguageMetacore.Japanese;

                case SystemLanguage.Portuguese:
                    return LocalizationLanguageMetacore.Portuguese;

                case SystemLanguage.Russian:
                    return LocalizationLanguageMetacore.Russian;

                case SystemLanguage.Spanish:
                    return LocalizationLanguageMetacore.Spanish;

                case SystemLanguage.Korean:
                    return LocalizationLanguageMetacore.Korean;

                default:
                    return LocalizationLanguageMetacore.English;
            }
        }

        public static string Get(string id)
        {
            var transId = TranslationId.FromString(id);
            if (MetaplaySDK.ActiveLanguage.Translations.TryGetValue(transId, out var value))
                return value;

            return null;
        }

        #region Hotspot methods

        // CUSTOM: Get hotspot title
        public static string GetHotspotTitle(AreaId id)
        {
            return Get($"HotspotTitle_{id.Value}");
        }

        public static string GetHotspotDescription(HotspotId hotspotId)
        {
            // CUSTOM: Check if hotspot is defined
            if (!Enum.IsDefined(hotspotId))
                return string.Empty;

            return Get(GetHotspotDescriptionLocId(hotspotId));
        }

        private static string GetHotspotDescriptionLocId(HotspotId hotspotId)
        {
            return $"HotspotDescription_{hotspotId}";
        }

        #endregion

        #region Merge Chain methods

        public static string GetItemCategoryName(ItemDefinition itemDefinition)
        {
            return GetItemCategoryName(itemDefinition.PoolTag);
        }

        // CUSTOM: GetItemCategoryName by MergeChainId
        public static string GetItemCategoryName(MergeChainId id)
        {
            return GetItemCategoryName($"{id.Value}Item");
        }

        public static string GetItemCategoryName(string poolTag)
        {
            return Get($"ItemCategory_{poolTag}");
        }

        #endregion

        #region Item methods

        public static string GetDescription(ItemTypeConstant itemTypeConstant, int level)
        {
            // CUSTOM: Check if item type is defined
            if (!Enum.IsDefined(itemTypeConstant))
                return string.Empty;

            var parts = itemTypeConstant.ToString().Split('_');
            return Get($"Item_{parts[0]}{level}_Description");
        }

        public static string GetItemName(ItemTypeConstant itemTypeConstant)
        {
            // CUSTOM: Check if item type is defined
            if (!Enum.IsDefined(itemTypeConstant))
                return string.Empty;

            var itemTypeName = itemTypeConstant.ToString();
            var lastUnderscore = itemTypeName.LastIndexOf('_');
            if (lastUnderscore <= 0 || lastUnderscore >= itemTypeName.Length - 1)
                throw new Exception($"{itemTypeConstant} has invalid _ (underscore) placement. Last _ should separate item name and level.");

            var itemName = "Item_" + itemTypeName[..lastUnderscore];
            var level = int.Parse(itemTypeName[(lastUnderscore + 1)..]);

            return Get($"{itemName}{level}");
        }

        #endregion
    }
}
