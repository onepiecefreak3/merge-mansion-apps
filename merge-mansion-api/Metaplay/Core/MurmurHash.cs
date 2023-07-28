namespace Metaplay.Core
{
    public static class MurmurHash
    {
        const uint m = 0x5bd1e995;
        const int r = 24;

        //public static uint MurmurHash2(IOBuffer buffer, uint seed = 3314489979) { }

        public static uint MurmurHash2(byte[] data, uint seed = 0xC58F1A7B)
        {
			var length = data.Length;
            if (length == 0)
                return 0;

            var h = seed ^ (uint)length;
            var currentIndex = 0;
            while (length >= 4)
            {
                var k = (uint)(data[currentIndex++] | data[currentIndex++] << 8 | data[currentIndex++] << 16 | data[currentIndex++] << 24);
                k *= m;
                k ^= k >> r;
                k *= m;

                h *= m;
                h ^= k;
                length -= 4;
            }

            switch (length)
            {
                case 3:
                    h ^= (ushort)(data[currentIndex++] | data[currentIndex++] << 8);
                    h ^= (uint)(data[currentIndex] << 16);
                    h *= m;
                    break;

                case 2:
                    h ^= (ushort)(data[currentIndex++] | data[currentIndex] << 8);
                    h *= m;
                    break;

                case 1:
                    h ^= data[currentIndex];
                    h *= m;
                    break;
            }

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;

            return h;
		}
    }
}
