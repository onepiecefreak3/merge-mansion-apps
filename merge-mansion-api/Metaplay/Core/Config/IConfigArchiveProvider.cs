﻿using System.Threading.Tasks;

namespace Metaplay.Core.Config
{
	public interface IConfigArchiveProvider
    {
        Task<ConfigArchive> GetAsync(ContentHash version);

        Task<bool> PutAsync(ConfigArchive archive);
    }
}
