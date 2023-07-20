namespace merge_mansion_dumper.Models.Area
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
