namespace Metaplay.Core.Model
{
    public abstract class ModelAction<TModel> : ModelAction
    {
        protected ModelAction()
        {
        }
    }

    [MetaSerializable]
    [MetaImplicitMembersDefaultRangeForMostDerivedClass(1, 100)]
    public abstract class ModelAction
    {
        protected ModelAction()
        {
        }
    }
}