using System;

namespace Metaplay.Metaplay.Unity
{
    [Flags]
    public enum LocalizationManagerAutoBehaviorFlag 
    {
        DownloadActiveLanguageUpdates = 1,
        HotUpdateActiveLanguageUpdates = 2,
        DownloadSomeVersionOfAllLanguages = 4
    }
}
