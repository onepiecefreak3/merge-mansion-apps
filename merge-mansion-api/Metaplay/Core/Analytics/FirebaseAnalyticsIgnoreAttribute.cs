using System;

namespace Metaplay.Core.Analytics
{
    [AttributeUsage((AttributeTargets)396)]
    public class FirebaseAnalyticsIgnoreAttribute : Attribute
    {
        public FirebaseAnalyticsIgnoreAttribute()
        {
        }
    }
}