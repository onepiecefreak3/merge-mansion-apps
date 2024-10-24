namespace Metaplay.Core.Serialization
{
    public enum WireDataType
    {
        Invalid = 0,
        Null = 1,
        VarInt = 2,
        VarInt128 = 3,
        F32 = 4,
        F32Vec2 = 5,
        F32Vec3 = 6,
        F64 = 7,
        F64Vec2 = 8,
        F64Vec3 = 9,
        Float32 = 10,
        Float64 = 11,
        String = 12,
        Bytes = 13,
        AbstractStruct = 14,
        NullableStruct = 15,
        Struct = 16,
        EndStruct = 17,
        ValueCollection = 18,
        KeyValueCollection = 19,
        ObjectTable = 20,
        NullableVarInt = 21,
        NullableVarInt128 = 22,
        NullableF32 = 23,
        NullableF32Vec2 = 24,
        NullableF32Vec3 = 25,
        NullableF64 = 26,
        NullableF64Vec2 = 27,
        NullableF64Vec3 = 28,
        NullableFloat32 = 29,
        NullableFloat64 = 30,
        MetaGuid = 31,
        NullableMetaGuid = 32
    }
}