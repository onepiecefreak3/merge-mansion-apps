using System;
using System.Collections.Generic;
using System.ComponentModel;
using Metaplay.Metaplay.Core.IO;
using Metaplay.Metaplay.Core.Model;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Localization
{
    public class LocalizationLanguage
    {
        [MetaMember(1, 0)]
        public LanguageId LanguageId { get; set; } // 0x10
        [MetaMember(2, 0)]
        public Dictionary<TranslationId, string> Translations { get; set; } // 0x18

        public LocalizationLanguage() { }

        public LocalizationLanguage(LanguageId languageId, Dictionary<TranslationId, string> translations)
        {
            LanguageId = languageId;
            Translations = translations;
        }

        public static LocalizationLanguage FromBytes(LanguageId languageId, byte[] bytes, LocalizationStorageFormat storageFormat)
        {
            switch (storageFormat)
            {
                case LocalizationStorageFormat.LegacyCsv:
                    // CUSTOM
                    throw new InvalidOperationException("LegacyCsv storage format is not supported.");

                case LocalizationStorageFormat.Binary:
                    var lang = ImportBinary(bytes);
                    if (lang.LanguageId.Equals(languageId))
                        return lang;

                    throw new ArgumentException(nameof(languageId));

                default:
                    throw new InvalidEnumArgumentException(nameof(storageFormat));
            }
        }

        public static LocalizationLanguage ImportBinary(byte[] bytes)
        {
            if (bytes[0] != 0xFF && bytes[0] != 0xF)
                throw new InvalidOperationException($"Expected {nameof(bytes)} to start with either byte 0xF (WireDataType.NullableStruct) or 0xFF, but it starts with {bytes[0]:X2}");

            if (bytes[0] == 0xF)
                return MetaSerialization.DeserializeTagged<LocalizationLanguage>(bytes, MetaSerializationFlags.IncludeAll, null, null, null);

            var reader = new IOReader(bytes, 1, bytes.Length - 1);

            var v = reader.ReadVarUInt();
            var vu = (uint)(-(v & 1) ^ v >> 1);
            if (vu != 1)
                throw new InvalidOperationException($"Invalid schema version: {vu}");

            var v1 = reader.ReadVarUInt();
            var vu1 = (uint)(-(v1 & 1) ^ v1 >> 1);
            if (vu1 != 1)
                throw new InvalidOperationException($"Invalid compression algorithm {vu1}");

            var decompBytes = CompressUtil.DeflateDecompress(bytes, reader.Offset);
            return MetaSerialization.DeserializeTagged<LocalizationLanguage>(decompBytes, MetaSerializationFlags.IncludeAll, null, null, null);
        }
    }
}
