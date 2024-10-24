using System;

namespace Metaplay.Core.Config
{
    public interface IGameConfigLibraryDeduplicationStorage
    {
        int NumSinglePatchDirectlyDuplicatedItems { get; }

        int NumSinglePatchIndirectlyDuplicatedItems { get; }
    }
}