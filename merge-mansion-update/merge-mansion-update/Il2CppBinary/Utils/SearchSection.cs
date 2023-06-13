namespace merge_mansion_update.Il2CppBinary.Utils
{
    public enum SearchSectionType
    {
        Exec,
        Data,
        Bss
    }

    public class SearchSection
    {
        public ulong offset;
        public ulong offsetEnd;
        public ulong address;
        public ulong addressEnd;
    }
}
