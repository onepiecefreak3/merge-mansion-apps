using System;
using System.Collections.Generic;
using System.ComponentModel;
using Metaplay.Core.IO;
using Metaplay.Core.Model;
using Metaplay.Core.Serialization;

namespace Metaplay.Core.Localization
{
    public class LocalizationLanguage
    {
        private const byte PayloadHeaderMagicPrefixByte = 255;

        public LanguageId LanguageId { get; } // 0x10
        public ContentHash Version { get; } // 0x18
        public Dictionary<TranslationId, string> Translations { get; } // 0x28

        public LocalizationLanguage(LanguageId languageId, ContentHash version, Dictionary<TranslationId, string> translations)
        {
            LanguageId = languageId;
            Version = version;
            Translations = translations;
        }

        public static LocalizationLanguage FromBytes(LanguageId languageId, ContentHash version, byte[] bytes, LocalizationStorageFormat storageFormat)
        {
            if (storageFormat == LocalizationStorageFormat.Binary)
            {
                var lang = ImportBinary(version, bytes);
                if (lang.LanguageId != languageId)
                    throw new ArgumentException($"Language '{languageId}' was specified, but blob contains '{lang.LanguageId}'", nameof(languageId));

                return lang;
            }

            if (storageFormat != LocalizationStorageFormat.LegacyCsv)
                throw new InvalidEnumArgumentException(nameof(storageFormat), (int)storageFormat, typeof(LocalizationStorageFormat));

            // CUSTOM: Throw exception instead of implementing legacy code
            throw new InvalidOperationException("LegacyCsv storage format is not supported.");
        }

        public static LocalizationLanguage ImportBinary(ContentHash version, byte[] bytes)
        {
            BinaryV1 binary;

            if (bytes[0] != 0xFF)
            {
                if (bytes[0] != 0xF)
                    throw new InvalidOperationException($"Expected {nameof(bytes)} to start with either byte 0xF (WireDataType.NullableStruct) or 0xFF, but it starts with {bytes[0]:X2}");

                binary = MetaSerialization.DeserializeTagged<BinaryV1>(bytes, MetaSerializationFlags.IncludeAll, null, null, null);
                return new LocalizationLanguage(binary.LanguageId, version, binary.Translations);
            }

            using var reader = new IOReader(bytes, 1, bytes.Length - 1);

            var schemaVersion = reader.ReadVarInt();
            if (schemaVersion != 1)
                throw new InvalidOperationException($"Invalid schema version: {schemaVersion}");

            var compressionAlgorithm = reader.ReadVarInt();
            if (compressionAlgorithm != 1)
                throw new InvalidOperationException($"Invalid compression algorithm {compressionAlgorithm}");

            var decompBytes = CompressUtil.DeflateDecompress(bytes, reader.Offset + 1);

            binary = MetaSerialization.DeserializeTagged<BinaryV1>(decompBytes, MetaSerializationFlags.IncludeAll, null, null, null);
            return new LocalizationLanguage(binary.LanguageId, version, binary.Translations);
        }

        [MetaSerializable]

        public class BinaryV1
        {
            [MetaMember(1, 0)]
            public LanguageId LanguageId; // 0x10
            [MetaMember(2, 0)]
            public Dictionary<TranslationId, string> Translations; // 0x18
        }
    }
}
