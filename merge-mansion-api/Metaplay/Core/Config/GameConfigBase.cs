using System;
using System.Collections.Generic;

namespace Metaplay.Core.Config
{
    public abstract class GameConfigBase : IGameConfig, IGameConfigDataRegistry
    {
        ContentHash Metaplay.Core.Config.IGameConfig.ArchiveVersion => ArchiveVersion;
        protected GameConfigBase()
        {
            _refResolvers = new Dictionary<Type, List<Func<object, object>>>();
            if (MetaplayCore.IsInitialized)
                return;
            throw new InvalidOperationException("MetaplayCore.Initialize() must be called before GameConfigs can be used");
        }

        public void RegisterReferenceResolver(Type type, Func<object, object> tryResolveFunc)
        {
            if (_refResolvers.TryGetValue(type, out var resList))
            {
                resList.Add(tryResolveFunc);
                return;
            }

            _refResolvers[type] = new List<Func<object, object>>
            {
                tryResolveFunc
            };
        }

        public object TryResolveReference(Type type, object configKey)
        {
            if (!_refResolvers.TryGetValue(type, out var resolver))
                return null;
            foreach (var resolverFunc in resolver)
            {
                var resolvedRef = resolverFunc(configKey);
                if (resolvedRef != null)
                    return resolvedRef;
            }

            return null;
        }

        public void Import(PatchedConfigArchive archive, IGameConfigDataResolver baseResolver)
        {
            if (baseResolver == null)
                throw new ArgumentNullException(nameof(baseResolver));
            ArchiveVersion = archive.BaselineArchive.Version;
            ArchiveCreatedAt = archive.BaselineArchive.CreatedAt;
            var importer = new GameConfigImporter(archive, null, this);
            Import(importer);
            OnImported();
        }

        public virtual void Import(GameConfigImporter importer)
        {
        }

        public void OnImported()
        {
        // TODO: Implement
        }

        public ContentHash ArchiveVersion;
        private Dictionary<Type, List<IGameConfigLibrary>> _libraries;
        protected GameConfigRuntimeStorageMode StorageMode { get; set; }
        protected GameConfigTopLevelDeduplicationStorage DeduplicationStorage { get; set; }
        protected GameConfigDeduplicationOwnership DeduplicationOwnership { get; set; }
        protected bool IsConstructingDeduplicationStorage { get; }

        private Dictionary<Type, List<Func<object, object>>> _refResolvers;
        public MetaTime ArchiveCreatedAt;
    }
}