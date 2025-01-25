namespace Metaplay.Core.Model
{
    public abstract class ModelAction<TModel> : ModelAction
    {
        protected ModelAction()
        {
        }
    }

    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    [MetaSerializable]
    public abstract class ModelAction
    {
        protected ModelAction()
        {
        }
    }
}