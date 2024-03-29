namespace GameLogic
{
    public enum BoardStepResult
    {
        Nothing = 0,
        AutoSpawned = 1,
        AutoDecayed = 2,
        ManualSpawned = 3,
        ManualDecay = 4,
        Merge = 5,
        Transform = 6,
        BubbleRemoved = 7,
        BubbleDecay = 8,
        Added = 9,
        Removed = 10,
        Sold = 11,
        Collect = 12,
        BecameVisible = 13,
        BecamePartiallyVisible = 14,
        SinkIn = 15,
        Consumed = 16,
        SpeedUpItem = 17,
        LevelUpItem = 18,
        AutoSellItemsFromBoard = 19,
        AutoSellFromInventory = 20,
        AutoSellFromPocket = 21
    }
}