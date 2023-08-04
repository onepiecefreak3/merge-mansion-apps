using System;

namespace Metaplay.Core.Activables
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = false)]
    public class MetaActivableSetAttribute : Attribute
    {
        public MetaActivableKindId KindId { get; }
        public bool Fallback { get; }

        public MetaActivableSetAttribute(string kindId, bool fallback)
        {
        }
    }
}