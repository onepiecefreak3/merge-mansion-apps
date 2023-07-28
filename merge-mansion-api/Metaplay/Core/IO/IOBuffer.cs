namespace Metaplay.Core.IO
{
    public interface IOBuffer
    {
        // RVA: -1 Offset: -1 Slot: 0
        bool IsEmpty { get; }
        // RVA: -1 Offset: -1 Slot: 1
        int Count { get; }
        // RVA: -1 Offset: -1 Slot: 2
        int NumSegments { get; }

        // RVA: -1 Offset: -1 Slot: 3
        IOBufferSegment GetSegment(int segmentIndex);

        // RVA: -1 Offset: -1 Slot: 4
        void BeginWrite();

        // RVA: -1 Offset: -1 Slot: 5
        void FlushSegment(int segmentIndex, int segmentSize);

        // RVA: -1 Offset: -1 Slot: 6
        void ExpandCapacity(int addedCapacity);

        // RVA: -1 Offset: -1 Slot: 7
        void EndWrite();

        // RVA: -1 Offset: -1 Slot: 8
        void Clear();

        // RVA: -1 Offset: -1 Slot: 9
        void BeginRead();

        // RVA: -1 Offset: -1 Slot: 10
        void EndRead();
	}
}
