using System;

namespace Metaplay.Core.Model
{
    [AttributeUsage((AttributeTargets)4, AllowMultiple = false, Inherited = false)]
    public class ModelActionExecuteFlagsAttribute : Attribute
    {
        public ModelActionExecuteFlags Modes { get; set; }

        public ModelActionExecuteFlagsAttribute(ModelActionExecuteFlags modes)
        {
        }
    }
}