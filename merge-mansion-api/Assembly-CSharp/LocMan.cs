using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Code.GameLogic.GameEvents;
using GameLogic;
using GameLogic.Area;
using GameLogic.Config;
using GameLogic.MergeChains;
using GameLogic.Player.Items;
using Metaplay.Core;
using Metaplay.Core.Config;
using Metaplay.Core.Localization;
using Metaplay.Unity;
using UnityEngine;

public static class LocMan
{
    private static readonly string iconEnergy = "<sprite=\"Icons\" name=\"Energy\">"; // 0x0
    private static readonly string iconGold = "<sprite=\"Icons\" name=\"Gold\">"; // 0x8
    private static readonly string iconDiamond = "<sprite=\"Icons\" name=\"Diamond\">"; // 0x10
    private static readonly string iconStar = "<sprite=\"Icons\" name=\"Star\">"; // 0x18

    public static Dictionary<LocalizationLanguageMetacore, (string filename, string localName, LanguageId languageId)> languageConfigs => LocCommon.languageConfigs;
    public static LocalizationLanguageMetacore ActiveLocalizationLanguageMetacore => LocCommon.languageConfigs.FirstOrDefault(x => x.Value.languageId.Equals(MetaplaySDK.ActiveLanguage.LanguageId)).Key;

    #region Language mapping

    public static bool DoLocalizationLanguageAndLanguageIdMatch(LocalizationLanguageMetacore localizationLanguage, LanguageId languageId)
    {
        return LocCommon.languageConfigs[localizationLanguage].languageId == languageId;
    }

    public static string PreviewStatic(LocalizationLanguageMetacore chosenLanguage, string id)
    {
        // CUSTOM: Instead of path "Assets/StreamingAssets/Localizations", use Application.ApkPath + "Localizations"
        var archive = ConfigArchive.FolderEncoding.FromDirectory(Path.Combine(Application.ApkPath, "Localizations"));

        var chosenLangString = LocToString.Stringify(chosenLanguage);
        var chosenLangId = LanguageId.FromString(chosenLangString);

        LocalizationLanguage foundLang = null;
        foreach (var entry in archive.Entries)
        {
            var bytes = entry.Uncompress();
            var locLanguage = LocalizationLanguage.ImportBinary(ContentHash.None, bytes);

            if (locLanguage.LanguageId == chosenLangId)
                foundLang = locLanguage;
        }

        var translationId = TranslationId.FromString(id);
        if (foundLang != null)
        {
            if (foundLang.Translations.TryGetValue(translationId, out var translation))
                return FillInParameters(translation);
        }

        return "NOT_FOUND!";
    }

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

    public static List<string> GetLocalLanguageNames()
    {
        return LocCommon.languageConfigs.Values.Select(x => x.localName).ToList();
    }

    #endregion

    #region Hotspots

    // CUSTOM: Get hotspot title
    public static string GetHotspotTitle(string areaId)
    {
        return Get($"HotspotTitle_{areaId}");
    }

    public static string GetHotspotDescriptionLocId(HotspotId hotspotId)
    {
        return $"HotspotDescription_{hotspotId}";
    }

    public static string GetHotspotDescription(HotspotId hotspotId)
    {
        // CUSTOM: Check if hotspot is defined
        if (!Enum.IsDefined(hotspotId))
            return string.Empty;

        var hotspotLocId = GetHotspotDescriptionLocId(hotspotId);
        return Get(hotspotLocId);
    }

    #endregion

    #region Items

    // CUSTOM: Get item description by integer item type
    public static string GetDescription(int itemType, int level)
    {
        // CUSTOM: Check if item type is defined
        if (!Enum.IsDefined(typeof(ItemTypeConstant), itemType))
            return string.Empty;

        return GetDescription(((ItemTypeConstant)itemType).ToString(), level);
    }

    public static string GetDescription(string itemType, int level)
    {
        var itemName = GetSubstringBeforeLastChar(itemType, '_');
        return Get($"Item_{itemName}{level}_Description");
    }

    public static bool TryGetInformation(string itemType, out string value)
    {
        var informationId = GetInformationId(itemType);
        return TryGetTranslation(informationId, out value);
    }

    public static string GetInformationId(string itemType)
    {
        return $"Item_{itemType}_Information";
    }

    public static string GetDescriptionForCollectable(string itemType, int level, int amount)
    {
        var itemName = GetSubstringBeforeLastChar(itemType, '_');
        var description = Get($"Item_{itemName}{level}_Description");

        return string.Format(description, amount);
    }

    public static string GetShortDescriptionForCollectable(string itemType, int amount)
    {
        var lastIndex = itemType.LastIndexOf('_');
        var firstPart = itemType[..lastIndex];
        var secondPart = int.Parse(itemType[(lastIndex + 1)..]);

        var translation = Get($"Item_{firstPart}{secondPart}_ShortDescription");
        return string.Format(translation, amount);
    }

    public static string GetDescriptionForActivable(string itemType, int level, bool canBeActivated)
    {
        var itemName = GetSubstringBeforeLastChar(itemType, '_');

        if (!canBeActivated)
        {
            var cooldownId = $"Item_{itemName}{level}_Description_Cooldown";

            if (HasString(cooldownId))
                return Get(cooldownId);
        }

        return Get($"Item_{itemName}{level}_Description");
    }

    // CUSTOM: Get item name by integer item type
    public static string GetItemName(int itemType)
    {
        // CUSTOM: Check if item type is defined
        if (!Enum.IsDefined(typeof(ItemTypeConstant), itemType))
            return string.Empty;

        return GetItemName(((ItemTypeConstant)itemType).ToString());
    }

    public static string GetItemName(string itemType)
    {
        var lastIndex = itemType.LastIndexOf('_');
        if (lastIndex <= 0 || lastIndex >= itemType.Length - 1)
            throw new Exception($"{itemType} has invalid _ (underscore) placement. Last _ should separate item name and level.");

        var firstPart = itemType[..lastIndex];
        var secondPart = int.Parse(itemType[(lastIndex + 1)..]);

        return Get($"Item_{firstPart}{secondPart}");
    }

    public static string GetItemCategoryName(ItemDefinition itemDefinition)
    {
        return GetItemCategoryName(itemDefinition.PoolTag);
    }

    // CUSTOM: Get localization id for item categories
    public static string GetItemCategoryNameLocId(MergeChainId id)
    {
        return GetItemCategoryNameLocId($"{id.Value}Item");
    }

    // CUSTOM: Get localization id for item categories
    public static string GetItemCategoryNameLocId(string poolTag)
    {
        return $"ItemCategory_{poolTag}";
    }

    // CUSTOM: GetItemCategoryName by MergeChainId
    public static string GetItemCategoryName(MergeChainId id)
    {
        return Get(GetItemCategoryNameLocId(id));
    }

    public static string GetItemCategoryName(string poolTag)
    {
        return Get(GetItemCategoryNameLocId(poolTag));
    }

    public static string Get(string itemType, int level)
    {
        var itemName = GetSubstringBeforeLastChar(itemType, '_');
        return Get($"Item_{itemName}{level}");
    }

    public static string GetItemWithLevelText(ItemDefinition itemDefinition)
    {
        // CUSTOM: The logic was inlined, but can be done by Get(itemType, level)
        var translation = Get(itemDefinition.ItemType, itemDefinition.LevelNumber);

        var level = string.Empty;
        if (itemDefinition.MergeChain.Length > 1)
            level = string.Format(Get("ItemLevel"), itemDefinition.LevelNumber);

        return $"{translation} {level}";
    }

    public static string GetItemWithLevelTextInBubble(ItemDefinition itemDefinition)
    {
        var itemLevelText = GetItemWithLevelText(itemDefinition);
        var bubbleText = Get("InBubble");

        return $"{itemLevelText} {bubbleText}";
    }

    public static string GetItemWithLevelTextLocked(ItemDefinition itemDefinition)
    {
        var itemLevelText = GetItemWithLevelText(itemDefinition);
        var lockedText = Get("Locked");

        return $"{itemLevelText} {lockedText}";
    }

    public static string GetChestItemNotification(string chestItem)
    {
        var notificationText = Get("Notification_Chest_Text");
        var itemName = GetItemName(chestItem);

        return string.Format(notificationText, itemName);
    }

    public static string GetActivationItemNotification(string activationItem)
    {
        var notificationText = Get("Notification_Activation_Text");
        var itemName = GetItemName(activationItem);

        return string.Format(notificationText, itemName);
    }

    public static string GetSpawnerItemNotification(string spawnerItem)
    {
        var notificationText = Get("Notification_Spawner_Text");
        var itemName = GetItemName(spawnerItem);

        return string.Format(notificationText, itemName);
    }

    public static string DailyTaskMissingItem(string it)
    {
        var taskText = Get("DailyTask_Missing_Item");
        var itemName = GetItemName(it);

        return string.Format(taskText, itemName);
    }

    #endregion

    #region Events
    
    public static string GetEventDescription(string id)
    {
        return Get($"Generic_Event_Task_Goal_Description_{id}");
    }

    #endregion

    #region Get

    public static string Get(string characterName, bool isDiscovered)
    {
        var idName = isDiscovered ? $"Dialog_Title_{characterName}" : "Dialog_Title_NotDiscoveredCharacter";
        var translationId = TranslationId.FromString(idName);

        return Get(translationId, string.Empty);
    }

    public static string Get(TranslationId translationId, string defaultValue)
    {
        if (MetaplaySDK.ActiveLanguage != null)
        {
            if (MetaplaySDK.ActiveLanguage.Translations.TryGetValue(translationId, out var translation))
                return FillInParameters(translation);
        }

        return defaultValue ?? translationId.Value;
    }

    public static string Get(string id)
    {
        if (MetaplaySDK.ActiveLanguage != null)
        {
            if (MetaplaySDK.ActiveLanguage.Translations.TryGetValue(TranslationId.FromString(id), out var translation))
                return FillInParameters(translation);
        }

        return id;
    }

    public static bool TryGet(string id, out string translation)
    {
        if (MetaplaySDK.ActiveLanguage != null)
        {
            if (MetaplaySDK.ActiveLanguage.Translations.TryGetValue(TranslationId.FromString(id), out translation))
            {
                translation = FillInParameters(translation);
                return true;
            }
        }

        translation = null;
        return false;
    }

    public static bool TryGetTranslation(string id, out string translation)
    {
        if (MetaplaySDK.ActiveLanguage != null)
        {
            if (MetaplaySDK.ActiveLanguage.Translations.TryGetValue(TranslationId.FromString(id), out translation))
            {
                translation = FillInParameters(translation);
                return true;
            }
        }

        translation = string.Empty;
        return false;
    }

    #region Formatting

    public static string GetFormatted(string id, string param0)
    {
        return string.Format(Get(id), param0);
    }

    public static string GetFormatted(string id, int param0)
    {
        var sParam0 = param0.ToString(CultureInfo.InvariantCulture);

        return GetFormatted(id, sParam0);
    }

    public static string GetFormatted(string id, long param0)
    {
        var sParam0 = param0.ToString(CultureInfo.InvariantCulture);

        return GetFormatted(id, sParam0);
    }

    public static string GetFormatted(string id, string param0, string param1)
    {
        return string.Format(Get(id), param0, param1);
    }

    public static string GetFormatted(string id, int param0, int param1)
    {
        var sParam0 = param0.ToString(CultureInfo.InvariantCulture);
        var sParam1 = param1.ToString(CultureInfo.InvariantCulture);

        return GetFormatted(id, sParam0, sParam1);
    }

    public static string GetFormatted(string id, long param0, long param1)
    {
        var sParam0 = param0.ToString(CultureInfo.InvariantCulture);
        var sParam1 = param1.ToString(CultureInfo.InvariantCulture);

        return GetFormatted(id, sParam0, sParam1);
    }

    #endregion

    #endregion

    #region Time

    public static string GetFormattedDeltaTime(MetaDuration duration)
    {
        return GetFormattedDeltaTime(duration.Milliseconds);
    }

    public static string GetFormattedDeltaTime(long time)
    {
        var hoursInDay = time / 3600000 % 24;
        if (time < 86400000)
        {
            var minutesInHour = time / 60000 % 60;
            if (hoursInDay < 1)
            {
                var secondsInMinute = time / 1000 % 60;
                if (minutesInHour < 1)
                    return GetFormatted("FormattedTimeSeconds", secondsInMinute);

                if (minutesInHour < 10 && secondsInMinute != 0)
                    return GetFormatted("FormattedTimeMinutesSeconds_Param01", minutesInHour, secondsInMinute);

                return GetFormatted("FormattedTimeMinutes", minutesInHour);
            }

            if (minutesInHour != 0)
                return GetFormatted("FormattedTimeHoursMinutes", hoursInDay, minutesInHour);

            return GetFormatted("FormattedTimeHours_Param0", hoursInDay);
        }

        var days = time / 86400000;

        if (hoursInDay != 0)
            return GetFormatted("FormattedTimeDaysHours", days, hoursInDay);

        return GetFormatted("FormattedTimeDays_Param0", days);
    }

    public static string GetFormattedDeltaTimeFull(MetaDuration duration)
    {
        var days = Math.Abs(duration.Milliseconds / 86400000);
        var hours = Math.Abs(duration.Milliseconds / 3600000) % 24;
        var minutes = Math.Abs(duration.Milliseconds / 60000) % 60;
        var seconds = Math.Abs(duration.Milliseconds / 1000) % 60;

        var parts = new List<string>();

        if (days >= 1)
            parts.Add(GetFormatted("FormattedTimeDays_Param0", days));

        if (days >= 1 || hours != 0)
            parts.Add(GetFormatted("FormattedTimeHours_Param0", hours));

        if (minutes != 0 || days > 0 || hours != 0)
            parts.Add(GetFormatted("FormattedTimeMinutes", minutes));

        parts.Add(GetFormatted("FormattedTimeSeconds", seconds));

        return string.Join(' ', parts);
    }

    public static string GetDays(int days)
    {
        return string.Format(Get("X_DaysShort"), days);
    }

    public static string GetHours(int hours)
    {
        return string.Format(Get("X_HoursShort"), hours);
    }

    public static string GetMinutes(int minutes)
    {
        return string.Format(Get("X_MinutesShort"), minutes);
    }

    public static string GetSeconds(int second)
    {
        return string.Format(Get("X_SecondsShort"), second);
    }

    #endregion

    #region Purchase and Currency

    public static string GetYouAreMissingWantToBuy((Currencies, int) missing)
    {
        var textPattern = Get("NotEnoughSomething");
        var currencyString = CurrencyToIconString(missing.Item1);

        return string.Format(textPattern, currencyString, missing.Item2);
    }

    public static string GetMissingEventCurrencyDescription((EventCurrencyId, int) missing, string fontSpriteName)
    {
        var textPattern = Get("NotEnoughEventCurrency_Desc_Param01");
        var iconString = $"<sprite=\"Icons\" name=\"{fontSpriteName}\">";

        return string.Format(textPattern, iconString, missing.Item2);
    }

    public static string GetRatingStars(string starPreText)
    {
        return $"{starPreText}{iconStar}";
    }

    public static string GetOfferTitle(MergeMansionOfferInfo offerInfo)
    {
        return Get(offerInfo.TitleLocalizationId);
    }

    public static string GetCurrencyAmount(ValueTuple<Currencies, long> cost)
    {
        var currencyString = CurrencyToIconString(cost.Item1);
        return $"{cost.Item2} {currencyString}";
    }

    private static string CurrencyToIconString(Currencies currency)
    {
        switch (currency)
        {
            case Currencies.Coins:
                return iconGold;

            case Currencies.Diamonds:
                return iconDiamond;

            case Currencies.Energy:
            case Currencies.SecondaryEnergy:
                return iconEnergy;
        }

        return "MISSING SYMBOL";
    }

    // RVA: 0x28674C8 Offset: 0x28674C8 VA: 0x28674C8
    //public static string GetIAPShopPurchaseStartErrorDescription(StartPurchaseResult startPurchaseResult) { }

    // RVA: 0x2867F70 Offset: 0x2867F70 VA: 0x2867F70
    //public static string GetCostLocalized(this ICost cost, PlayerModel playerModel) { }

    #endregion

    #region Socials and Notifications

    //// RVA: 0x2867710 Offset: 0x2867710 VA: 0x2867710
    //public static string GetNotificationCategoryDescription(NotificationCategories category) { }

    //// RVA: 0x28677CC Offset: 0x28677CC VA: 0x28677CC
    //public static string GetUpdateRequiredDescription(RuntimePlatform platform) { }

    //// RVA: 0x28678B4 Offset: 0x28678B4 VA: 0x28678B4
    //public static string GetSocialPlatformName(AuthenticationPlatform authenticationPlatform) { }

    //// RVA: 0x2867970 Offset: 0x2867970 VA: 0x2867970
    //public static string GetSocialLoginSuccess(AuthenticationPlatform authenticationPlatform) { }

    //// RVA: 0x28679F4 Offset: 0x28679F4 VA: 0x28679F4
    //public static string GetSocialLoginAlreadyLogged(AuthenticationPlatform authenticationPlatform) { }

    //// RVA: 0x2867A78 Offset: 0x2867A78 VA: 0x2867A78
    //public static string GetSocialLoginFailure(string error) { }

    //// RVA: 0x2867B18 Offset: 0x2867B18 VA: 0x2867B18
    //public static string GetPlayerLevel(int levelNumber) { }

    //// RVA: 0x2867BC4 Offset: 0x2867BC4 VA: 0x2867BC4
    //public static string GetSocialLoginConfirmDescription(bool local, int playerLevel) { }

    //// RVA: 0x2867C78 Offset: 0x2867C78 VA: 0x2867C78
    //public static string FormatPlayerSaveText(bool local, int playerLevel) { }

    //// RVA: 0x2867E18 Offset: 0x2867E18 VA: 0x2867E18
    //public static string GetUrlOpenError(string url) { }

    //// RVA: 0x2867E8C Offset: 0x2867E8C VA: 0x2867E8C
    //public static string GetMailDeleteDescription(string mailTopic) { }

    //// RVA: 0x2868444 Offset: 0x2868444 VA: 0x2868444
    //public static string GetErrorMessage(IConsumptionCheckResult consumptionCheckResult) { }

    //// RVA: 0x2868280 Offset: 0x2868280 VA: 0x2868280
    //public static string ToLocalizedDisplayText(this LocalizedString input) { }

    //// RVA: 0x2868340 Offset: 0x2868340 VA: 0x2868340
    //public static string ToLocalizedDisplayText(this LocalizedString input, LocalizedString fallback) { }

    #endregion

    #region Player

    private static string GetPlayerName()
    {
        var playerName = MetaplayClient.PlayerModel?.PlayerName;

        if (string.IsNullOrEmpty(playerName))
            playerName = Get("PlayerNameIfNotSet");

        return playerName;
    }

    #endregion

    #region Support

    public static string GetQuantity(string locId, int quantity)
    {
        if (HasString(locId))
            return GetFormatted(locId, $"{quantity}");

        return $"{quantity}";
    }

    public static bool HasString(string id)
    {
        return TryGetTranslation(id, out _);
    }

    public static string GetSubstringBeforeChar(string original, char splitChar)
    {
        return original[..original.IndexOf(splitChar, 4)];
    }

    public static string GetSubstringBeforeLastChar(string original, char splitChar)
    {
        return original[..original.LastIndexOf(splitChar)];
    }

    private static string FillInParameters(string text)
    {
        var playerName = GetPlayerName();
        return text.Replace("{PlayerName}", playerName);
    }

    #endregion
}
