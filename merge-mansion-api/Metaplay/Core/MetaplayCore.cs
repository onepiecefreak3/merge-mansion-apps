using System;
using System.Linq;
using Metaplay.Core.Config;

namespace Metaplay.Core
{
    public static class MetaplayCore
    {
        public const int DefaultLoginProtocolVersion = 1;

        private static MetaplayCoreOptions _options; // 0x0

        public static bool IsInitialized => _options != null;
        public static MetaplayCoreOptions Options => _options;

        public static void Initialize()
        {
            if (_options != null)
                return;

            IntegrationRegistry.Init(type => type.FullName?.StartsWith("Metaplay.", StringComparison.Ordinal) ?? false);
            var optionsProvider = IntegrationRegistry.Get<IMetaplayCoreOptionsProvider>();

            _options = optionsProvider.Options;

            var missingTypes = IntegrationRegistry.MissingIntegrationTypes().ToArray();
            if (missingTypes.Length > 0)
                throw new InvalidOperationException("Game must provide concrete implementations of integration types: " + string.Join(',', missingTypes.Select(x => x.Name)));

            // MetaTask.Initialize();
            // PrettyPrinter.RegisterFormatter<IntVector2>();
            // PrettyPrinter.RegisterFormatter<IntVector3>();
            EntityKindRegistry.Initialize();
            GameConfigRepository.InitializeSingleton();

            // ConfigParser$$RegisterBasicTypeParsers();
            // ConfigParser$$RegisterCustomParsers();
            // ConfigParser$$RegisterGameConfigs();

            // MetaSerializerTypeRegistry.ScanTypes(_options.SharedNamespaces, null);
            // ModelActionRepository.Initialize();
            // MetaMessageRepository.Initialize();
            // MetaActivableRepository.InitializeSingleton();
            // AnalyticsEventRegistry.Initialize();
            // FirebaseAnalyticsFormatter.Initialize();
        }

        // CUSTOM: Reset static instances for runtime re-initialization
        public static void Reset()
        {
            _options = null;

            EntityKindRegistry.Reset();
        }
    }
}
