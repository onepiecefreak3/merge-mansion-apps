using System;

namespace Metaplay.Core
{
    [AttributeUsage((AttributeTargets)1437)]
    public abstract class MetaplayFeatureEnabledConditionAttribute : Attribute
    {
        public abstract bool IsEnabled { get; }

        protected MetaplayFeatureEnabledConditionAttribute()
        {
        }
    }
}