using System;

namespace Metaplay.Core
{
    [AttributeUsage((AttributeTargets)4)]
    public abstract class MessageRoutingRule : Attribute
    {
        protected MessageRoutingRule()
        {
        }
    }
}