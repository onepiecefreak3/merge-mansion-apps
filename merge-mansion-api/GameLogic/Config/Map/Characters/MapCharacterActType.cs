using Metaplay.Core.Model;

namespace GameLogic.Config.Map.Characters
{
    [MetaSerializable]
    public enum MapCharacterActType
    {
        None = 0,
        Default = 1,
        IdleDialogue = 2,
        Annoyed = 3,
        Charming = 4,
        Discouraged = 5,
        Doubtful = 6,
        Encouraging = 7,
        Frustrated = 8,
        Joyous = 9,
        Relaxed = 10,
        Surprised = 11,
        Thinking = 12,
        Worried = 13,
        ReactionJoy = 14,
        ReactionPonder = 15,
        ReactionFind = 16,
        FinishTask1 = 17,
        FinishTask2 = 18,
        FinishTask3 = 19,
        ReactionExplain = 20,
        ReactionBow = 21,
        Jackie_ReactionThinking = 22,
        Jackie_ReactionArgue = 23,
        Storytime = 24
    }
}