using Metaplay.Core.IO;

namespace Metaplay.Core.Config
{
    public static class IConfigArchiveExtensions
    {
        public static IOReader ReadEntry(this IConfigArchive archive, string name)
        {
            var data = archive.GetEntryBytes(name);
            return new IOReader(data.ToArray());
        }
    }
}
