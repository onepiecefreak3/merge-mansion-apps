using Metaplay.Core.Model;

namespace GameLogic
{
    [MetaSerializable]
    public enum DialogCharacterState
    {
        NoChange = 0,
        Default = 1,
        Worried = 2,
        Surprised = 3,
        Frustrated = 4,
        Thinking = 5,
        Encouraging = 6,
        Doubtful = 7,
        Joyous = 8,
        Charming = 9,
        Relaxed = 10,
        Annoyed = 11,
        Discouraged = 12,
        Calling = 13,
        Talking = 14,
        Angry = 15,
        Yelling = 16,
        Proposal = 17,
        Hesitant = 18,
        Ready = 19
    }
}