using System.Collections.Generic;

namespace Metaplay.Core.Localization
{
    public interface ILocalized<T> : ILocalized
    {
        Dictionary<LanguageId, T> Localizations { get; }
    }

    public interface ILocalized
    {
    }
}