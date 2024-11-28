using Metaplay.Core.Forms;
using Metaplay.Core.Model;
using System;

namespace Metaplay.Core.Config
{
    [MetaSerializableDerived(102)]
    [MetaFormHidden]
    public class FileSystemBuildSource : GameConfigBuildSource
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        public FileSystemBuildSource.Format FileFormat;
        public override string DisplayName { get; }

        private FileSystemBuildSource()
        {
        }

        public FileSystemBuildSource(FileSystemBuildSource.Format fileFormat)
        {
        }

        [MetaSerializable]
        public enum Format
        {
            Binary = 0,
            Csv = 1
        }
    }
}