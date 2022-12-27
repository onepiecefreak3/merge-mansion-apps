using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay
{
    public enum DialogLayoutEvent
    {
        None = 0,
        LeftCharacterAppear = 1,
        LeftCharacterAppearSpeaking = 2,
        LeftCharacterAppearListening = 3,
        LeftCharacterDisappear = 4,
        LeftCharacterSpeaking = 5,
        LeftCharacterListening = 6,
        RightCharacterAppear = 7,
        RightCharacterAppearSpeaking = 8,
        RightCharacterAppearListening = 9,
        RightCharacterDisappear = 10,
        RightCharacterSpeaking = 11,
        RightCharacterListening = 12,
        SpeechBubbleAppearLeft = 13,
        SpeechBubbleDisappearLeft = 14,
        SpeechBubbleAppearRight = 15,
        SpeechBubbleDisappearRight = 16,
        SpeechBubbleNext = 17,
        WaitForAnimationsToComplete = 18,
        LeftSMS = 19,
        RightSMS = 20
    }
}
