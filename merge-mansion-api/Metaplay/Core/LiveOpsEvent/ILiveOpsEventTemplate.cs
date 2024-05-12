namespace Metaplay.Core.LiveOpsEvent
{
    public interface ILiveOpsEventTemplate
    {
        LiveOpsEventTemplateId TemplateId { get; }

        LiveOpsEventContent ContentBase { get; }
    }
}