using GameLogic.Config;

public static class ClientGlobal
{
    public static bool VersionMismatch; // 0x0
    public static bool CommitIdMismatch; // 0x1
    public static int LogicVersion = -1; // 0x4
    public static SharedGameConfig SharedGameConfig = null; // 0x8
}