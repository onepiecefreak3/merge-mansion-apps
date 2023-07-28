namespace Metaplay.Core
{
    [EntityKindRegistry(1, 10)]
    public static class EntityKindCore
    {
        public static readonly EntityKind Player = new EntityKind(1); // 0x0
        public static readonly EntityKind Session = new EntityKind(2); // 0x4
        public static readonly EntityKind Guild = new EntityKind(3); // 0x8
    }
}
