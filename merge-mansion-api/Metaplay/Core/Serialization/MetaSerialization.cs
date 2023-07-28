using System;
using System.Collections.Generic;
using System.Text;
using Metaplay.Core.Config;
using Metaplay.Core.IO;
using Metaplay.Generated;

namespace Metaplay.Core.Serialization
{
    public static class MetaSerialization
    {
        //private static TaggedSerializerRoslyn s_taggedSerializerRoslyn; // 0x0

        public static void CheckInitialized()
        {
            //if (s_taggedSerializerRoslyn == null)
            //    throw new InvalidOperationException("Serialization must be initialized by calling MetaSerialization.Initialize()");

            if (!MetaplayCore.IsInitialized)
                throw new InvalidOperationException("MetaplayCore.Initialize() must be called before (de)serializing any data");
        }

        private static MetaSerializationContext CreateContext(MetaSerializationFlags flags, IGameConfigDataResolver resolver, int? logicVersion, StringBuilder debugStream)
        {
            return new MetaSerializationContext(flags, resolver, logicVersion, debugStream);
        }

        public static List<T> DeserializeTableTagged<T>(byte[] serialized, MetaSerializationFlags flags, IGameConfigDataResolver resolver, int? logicVersion, StringBuilder debugStream)
        {
            CheckInitialized();

            var context = CreateContext(flags, resolver, logicVersion, debugStream);
            using var reader = new IOReader(serialized);

            return (List<T>)TypeSerializer.DeserializeTable(ref context, reader, typeof(T));
        }

        public static T DeserializeTagged<T>(byte[] serialized, MetaSerializationFlags flags, IGameConfigDataResolver resolver, int? logicVersion, StringBuilder debugStream)
        {
            return DeserializeTagged<T>(new IOReader(serialized), flags, resolver, logicVersion, debugStream);
        }

        public static T DeserializeTagged<T>(IOReader reader, MetaSerializationFlags flags, IGameConfigDataResolver resolver, int? logicVersion, StringBuilder debugStream)
        {
            CheckInitialized();

            var context = CreateContext(flags, resolver, logicVersion, debugStream);

            return (T)TypeSerializer.Deserialize(ref context, reader, typeof(T));
        }

        public static byte[] SerializeTagged<T>(T value, MetaSerializationFlags flags, int? logicVersion, StringBuilder debugStream)
        {
            CheckInitialized();

            var context = CreateContext(flags, null, logicVersion, debugStream);
            using var writer = new IOWriter();

            TypeSerializer.Serialize(ref context, writer, value);

            return writer.ConvertToStream().ToArray();
        }
    }
}
