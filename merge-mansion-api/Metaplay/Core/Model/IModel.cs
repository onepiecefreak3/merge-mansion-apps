using System;

namespace Metaplay.Core.Model
{
    public interface IModel<TModel> : IModel, ISchemaMigratable
    {
    }

    [MetaSerializable]
    public interface IModel : ISchemaMigratable
    {
        int LogicVersion { get; set; }
    }
}