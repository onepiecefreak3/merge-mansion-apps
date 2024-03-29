﻿namespace Metaplay.Core
{
    public interface IMetaplayCoreOptionsProvider: IMetaIntegrationSingleton<IMetaplayCoreOptionsProvider>
    {
        MetaplayCoreOptions Options { get; }
    }
}
