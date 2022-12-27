using System;
using System.Buffers.Binary;
using Metaplay.Metaplay.Core.Network;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Debugging
{
    public static class PlayerIncidentUtil
    {
        public static ulong GetSuffixFromIncidentId(string incidentId)
        {
            var data = Convert.FromHexString(incidentId.Substring(16, 16));
            return BinaryPrimitives.ReadUInt64BigEndian(data);
        }

        public static byte[] TryCompressIncidentForNetworkDelivery(/*LogChannel log,*/ PlayerIncidentReport report)
        {
            var data = MetaSerialization.SerializeTagged(report, MetaSerializationFlags.IncludeAll, null, null);
            return TryCompressIncidentForNetworkDelivery(data);
        }

        public static byte[] TryCompressIncidentForNetworkDelivery(/*LogChannel log,*/ byte[] reportPayload)
        {
            if (reportPayload == null)
                return null;

            if (reportPayload.Length <= PlayerUploadIncidentReport.MaxUncompressedPayloadSize)
            {
                var compressedData = CompressUtil.DeflateCompress(reportPayload);
                if (compressedData.Length <= PlayerUploadIncidentReport.MaxCompressedPayloadSize)
                    return compressedData;

                // Log warning "Metaplay compressed incident report too large: compressedSize={compressedData.Length} (max is {PlayerUploadIncidentReport.MaxCompressedPayloadSize})."
            }
            else
            {
                // Log warning "Metaplay uncompressed incident report too large: reportSize={reportPayload.Length} (max is {PlayerUploadIncidentReport.MaxUncompressedPayloadSize})"
            }

            return null;
        }
    }
}
