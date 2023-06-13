using System.Text;

namespace merge_mansion_update.Il2CppBinary.Extensions
{
    static class HexExtensions
    {
        public static string HexToBin(this byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        public static string HexToBin(this byte[] bytes)
        {
            var result = new StringBuilder(bytes.Length * 8);
            foreach (var b in bytes)
            {
                result.Insert(0, b.HexToBin());
            }
            return result.ToString();
        }
    }
}
