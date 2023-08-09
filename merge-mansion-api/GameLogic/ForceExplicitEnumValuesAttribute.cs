using System;

namespace GameLogic
{
    [AttributeUsage((AttributeTargets)16)]
    public class ForceExplicitEnumValuesAttribute : Attribute
    {
        public ForceExplicitEnumValuesAttribute()
        {
        }
    }
}