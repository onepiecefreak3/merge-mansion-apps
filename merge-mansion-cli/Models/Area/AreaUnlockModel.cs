namespace merge_mansion_cli.Models.Area
{
    class AreaUnlockModel
    {
        public RequirementType Type { get; set; }
        public string Value { get; set; }
    }

    public enum RequirementType
    {
        PlayerLevel,
        AreaUnlocked,
        HotspotUnlocked,
        ItemSeen,
        ItemAcquired,
        Coins,
        Time,

        SessionCount,
        ClientVersion
    }
}
