using System;

namespace Metaplay.Core.LiveOpsEvent
{
    public interface ILiveOpsEventTemplate
    {
        LiveOpsEventTemplateId TemplateId { get; }

        LiveOpsEventContent ContentBase { get; }

        string DefaultDisplayName { get; }

        string DefaultDescription { get; }
    }

    public interface ILiveOpsEventTemplate<TContentClass> : ILiveOpsEventTemplate
    {
    }
}