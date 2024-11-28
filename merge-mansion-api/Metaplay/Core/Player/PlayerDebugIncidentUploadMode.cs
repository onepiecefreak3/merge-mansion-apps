using Metaplay.Core.Model;

namespace Metaplay.Core.Player
{
    [MetaSerializable]
    public enum PlayerDebugIncidentUploadMode
    {
        Normal = 0,
        SilentlyOmitUploads = 1,
        RejectIncidents = 2
    }
}