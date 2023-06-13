using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using merge_mansion_api.Metaplay.Core.Config;
using Metaplay.Metaplay.Core.IO;
using Metaplay.Metaplay.Core.Math;

namespace Metaplay.Metaplay.Core.Config
{
    public class ConfigArchive : IConfigArchive
    {
        // 0x0
        public const int FileSchemaVersion = 5;
        // 0x4
        public const uint FileHeaderMagic = 0x4D434121; // MAC!
        // 0x8
        public const int MaxEntryNameLength = 0x400;
        // 0x10
        public const string IndexFileHeaderMagic = "MetaplayArchive";

        // 0x10
        private List<ConfigArchiveEntry> _entries;
        // 0x18
        private Dictionary<string, ConfigArchiveEntry> _entryByName;

        // 0x20
        public ContentHash Version { get; set; }
        // 0x30
        public MetaTime CreatedAt { get; set; }

        public IReadOnlyList<ConfigArchiveEntry> Entries => _entries;

        public ConfigArchive(ContentHash version, MetaTime createdAt, IEnumerable<ConfigArchiveEntry> entries)
        {
            Version = version;
            CreatedAt = createdAt;

            _entries = entries.ToList();
            _entryByName = _entries.ToDictionary(x => x.Name, y => y);
        }

        public ConfigArchive(MetaTime createdAt, IEnumerable<ConfigArchiveEntry> entries)
        {
            _entries = entries.OrderBy(x => x.Name).ToList();
            _entryByName = _entries.ToDictionary(x => x.Name, y => y);

            CreatedAt = createdAt;
            Version = ComputeVersionHashForEntries(_entries);
        }

        private static ContentHash ComputeVersionHashForEntries(IEnumerable<ConfigArchiveEntry> entries)
        {
            var res = UInt128.Zero;
            foreach (var entry in entries)
            {
                var hash = ContentHash.ComputeFromBytes(Encoding.UTF8.GetBytes(entry.Name));

                res.High *= 0x705;
                res.Low *= 0x1eef;

                res ^= hash.Value;
                res ^= entry.Hash.Value;
            }

            return new ContentHash(res);
        }

        public ConfigArchiveEntry GetEntryByName(string name)
        {
            return _entryByName[name];
        }

        public bool ContainsEntryWithName(string name)
        {
            return _entryByName.ContainsKey(name);
        }

        public static ConfigArchive FromBytes(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            using var reader = new IOReader(bytes);

            var magic = reader.ReadInt32();
            if (magic != FileHeaderMagic)
                throw new SerializationException("Invalid ConfigArchive file: unexpected magic");

            var version = reader.ReadInt32();
            if (version > FileSchemaVersion)
                throw new SerializationException($"ConfigArchive version ({version}) is too new, latest supported is version {FileSchemaVersion}");
            if (version < 2)
                throw new SerializationException($"Unsupported ConfigArchive version {version}, oldest supported version is 2");

            /* Archive revisions:
             * 2 - No archive time, no archive hash
             * 3 -    archive time, no archive hash
             * 4 -    archive time,    archive hash
             * 5 -    archive time,    archive hash, entry compression
             */

            var archiveHash = version >= 4 ? new ContentHash(reader.ReadUInt128()) : ContentHash.None;
            var archiveTime = version == 2 ? MetaTime.Epoch : MetaTime.FromMillisecondsSinceEpoch(reader.ReadInt64());

            var entryCount = reader.ReadInt32();
            var entries = new List<ConfigArchiveEntry>(entryCount);
            for (var i = 0; i < entryCount; i++)
            {
                var name = reader.ReadString(MaxEntryNameLength);
                var hash = new ContentHash(reader.ReadUInt128());

                var compressionType = (CompressionAlgorithm)reader.ReadInt32();
                if (version < 5)
                    compressionType = CompressionAlgorithm.None;

                var isCompressionSupported = CompressUtil.IsSupportedForDecompression(compressionType);
                if (!isCompressionSupported)
                    throw new SerializationException($"Unsupported compression format {compressionType}");

                var entryLength = reader.ReadInt32();

                entries.Add(new ConfigArchiveEntry(name, hash, compressionType, new byte[entryLength]));
            }

            for (var i = 0; i < entryCount; i++)
            {
                var entry = entries[i];
                var rawBytes = entry.RawBytes;

                reader.ReadBytes(rawBytes, 0, rawBytes.Length);
            }

            return version >= 4
                ? new ConfigArchive(archiveHash, archiveTime, entries)
                : new ConfigArchive(archiveTime, entries);
        }

        public byte[] ToBytes()
        {
            using var writer = new IOWriter();

            // Write header data
            writer.WriteUInt32(0x4d434121);
            writer.WriteInt32(5);
            writer.WriteUInt128(Version.Value);
            writer.WriteInt64(CreatedAt.MillisecondsSinceEpoch);

            // Write entries
            writer.WriteInt32(_entries.Count);
            foreach (var entry in _entries)
            {
                writer.WriteString(entry.Name);
                writer.WriteUInt128(entry.Hash.Value);
                writer.WriteUInt32((uint)entry.Compression);

                writer.WriteInt32(entry.RawBytes.Length);
                writer.WriteBytes(entry.RawBytes, 0, entry.RawBytes.Length);
            }

            return writer.ConvertToStream().ToArray();
        }

        public static class FolderEncoding
        {
            public static DirectoryIndex ReadDirectoryIndex(string directoryPath)
            {
                var indexPath = Path.Combine(directoryPath, "Index.txt");
                return ReadDirectoryIndexFile(indexPath);
            }

            private static DirectoryIndex ReadDirectoryIndexFile(string indexFilePath)
            {
                var dirPath = Path.GetDirectoryName(indexFilePath);
                var dirName = Path.GetFileName(dirPath);
                var lines = FileUtil.ReadAllLines(indexFilePath);

                if (lines.Length == 0)
                    throw new ParseError($"Archive index file is empty {dirName}/Index.txt");

                var split = lines[0].Split(' ');
                if (split.Length != 3 || split[0] != "MetaplayArchive")
                    throw new ParseError($"Invalid archive {dirName}/Index.txt header prefix");

                var hash = ContentHash.ParseString(split[1]);
                var timeMs = MetaTime.FromMillisecondsSinceEpoch(long.Parse(split[2], CultureInfo.InvariantCulture));

                var res = new List<DirectoryIndex.Entry>();
                foreach (var line in lines.Skip(1))
                {
                    if (string.IsNullOrEmpty(line.Trim()))
                        continue;

                    var lineSplits = line.Split(' ');
                    if (lineSplits.Length != 2)
                        throw new ParseError($"Invalid row in archive {dirName}/Index.txt: '{line}'");

                    var lineHash = ContentHash.ParseString(lineSplits[1]);
                    res.Add(new DirectoryIndex.Entry(Path.Combine(dirPath, lineSplits[0]), lineHash));
                }

                return new DirectoryIndex(hash, timeMs, res);
            }

            public struct DirectoryIndex
            {
                public readonly ContentHash Version; // 0x0
                public readonly MetaTime Timestamp; // 0x10
                public readonly List<Entry> FileEntries; // 0x18

                public DirectoryIndex(ContentHash version, MetaTime timestamp, List<Entry> fileEntries)
                {
                    Version = version;
                    Timestamp = timestamp;
                    FileEntries = fileEntries;
                }

                public struct Entry
                {
                    public readonly string Path; // 0x0
                    public readonly ContentHash Version; // 0x8

                    public Entry(string path, ContentHash version)
                    {
                        Path = path;
                        Version = version;
                    }
                }
            }
        }
    }
}
