using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaplay.Metaplay.Core.Config
{
    public abstract class GameConfigBase : IGameConfigDataRegistry, IGameConfig
    {
        private Dictionary<Type, List<Func<object, object>>> _refResolvers; // 0x28

        // 0x10
        public ContentHash ArchiveVersion { get; private set; }

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

            _refResolvers[type] = new List<Func<object, object>> { tryResolveFunc };
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

            var importer = new GameConfigImporter(archive, null, this);
            Import(importer);

            OnImported();
        }

        public virtual void Import(GameConfigImporter importer) { }

        public void OnImported()
        {
            // TODO: Implement
        }
    }
}
