using System;

namespace Metaplay.Core.Activables
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = false)]
    public class MetaActivableConfigDataAttribute : Attribute
    {
        public MetaActivableKindId KindId { get; }
        public bool Fallback { get; }

        public MetaActivableConfigDataAttribute(string kindId, bool fallback)
        {
        }

        public bool WarnAboutMissingConfigLibrary { get; }

        public MetaActivableConfigDataAttribute(string kindId, bool fallback, bool warnAboutMissingConfigLibrary)
        {
        }
    }
}