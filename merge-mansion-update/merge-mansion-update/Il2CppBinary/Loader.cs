using System.Runtime.InteropServices;
using merge_mansion_update.Il2CppBinary.ExecutableFormats;
using merge_mansion_update.Il2CppBinary.Utils;
using Serilog;

namespace merge_mansion_update.Il2CppBinary
{
    public static class Loader
    {
        public static bool Load(string il2CppPath, string metadataPath, out Metadata metadata, out Il2Cpp il2Cpp)
        {
            metadata = LoadMetadata(metadataPath);
            il2Cpp = LoadIl2Cpp(il2CppPath);

            return InitIl2Cpp(il2CppPath, ref il2Cpp, metadata);
        }

        private static Metadata LoadMetadata(string metadataPath)
        {
            Log.Information("Initializing metadata...");

            var metadataBytes = File.ReadAllBytes(metadataPath);
            var metadata = new Metadata(new MemoryStream(metadataBytes));

            Log.Information($"Metadata Version: {metadata.Version}");

            return metadata;
        }

        private static Il2Cpp LoadIl2Cpp(string il2CppPath)
        {
            Log.Information("Initializing il2cpp file...");

            var il2CppBytes = File.ReadAllBytes(il2CppPath);
            var il2CppMagic = BitConverter.ToUInt32(il2CppBytes, 0);
            var il2CppMemory = new MemoryStream(il2CppBytes);

            switch (il2CppMagic)
            {
                default:
                    Log.Error("Unsupported Il2Cpp file with magic number 0x{0:X8}", il2CppMagic);
                    throw new NotSupportedException("Il2Cpp file not supported.");

                case 0x6D736100: // Web assembly
                    var web = new WebAssembly(il2CppMemory);
                    return web.CreateMemory();

                case 0x304F534E: // NSO (Nintendo Switch)
                    var nso = new NSO(il2CppMemory);
                    return nso.UnCompress();

                case 0x905A4D: // PE
                    return new PE(il2CppMemory);

                case 0x464c457f: // ELF
                    if (il2CppBytes[4] == 2) // ELF64
                        return new Elf64(il2CppMemory);

                    return new Elf(il2CppMemory);

                case 0xCAFEBABE: // FAT Mach-O
                case 0xBEBAFECA:
                    var machoFat = new MachoFat(new MemoryStream(il2CppBytes));
                    Console.Write("Select Platform: ");
                    for (var i = 0; i < machoFat.fats.Length; i++)
                    {
                        var fat = machoFat.fats[i];
                        Console.Write(fat.magic == 0xFEEDFACF ? $"{i + 1}.64bit " : $"{i + 1}.32bit ");
                    }
                    Console.WriteLine();
                    var key = Console.ReadKey(true);
                    var index = int.Parse(key.KeyChar.ToString()) - 1;
                    var magic = machoFat.fats[index % 2].magic;
                    il2CppBytes = machoFat.GetMacho(index % 2);
                    il2CppMemory = new MemoryStream(il2CppBytes);

                    if (magic == 0xFEEDFACF)
                        goto case 0xFEEDFACF;

                    goto case 0xFEEDFACE;

                case 0xFEEDFACF: // 64bit Mach-O
                    return new Macho64(il2CppMemory);

                case 0xFEEDFACE: // 32bit Mach-O
                    return new Macho(il2CppMemory);
            }
        }

        private static bool InitIl2Cpp(string il2CppPath, ref Il2Cpp il2Cpp, Metadata metadata)
        {
            il2Cpp.SetProperties(metadata.Version, metadata.metadataUsagesCount);
            Log.Information($"Il2Cpp Version: {il2Cpp.Version}");

            Log.Information("Searching...");
            try
            {
                var flag = il2Cpp.PlusSearch(metadata.methodDefs.Count(x => x.methodIndex >= 0), metadata.typeDefs.Length, metadata.imageDefs.Length);
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    if (!flag && il2Cpp is PE)
                    {
                        Log.Information("Use custom PE loader");
                        il2Cpp = PELoader.Load(il2CppPath);
                        il2Cpp.SetProperties(metadata.Version, metadata.metadataUsagesCount);
                        flag = il2Cpp.PlusSearch(metadata.methodDefs.Count(x => x.methodIndex >= 0), metadata.typeDefs.Length, metadata.imageDefs.Length);
                    }
                }
                if (!flag)
                {
                    flag = il2Cpp.Search();
                }
                if (!flag)
                {
                    flag = il2Cpp.SymbolSearch();
                }
                if (!flag)
                {
                    Log.Error("Can't use auto mode to process file.");

                    Console.WriteLine("Can't use auto mode to process file. Try manuel mode.");
                    Console.Write("Input CodeRegistration: ");
                    var codeRegistration = Convert.ToUInt64(Console.ReadLine(), 16);
                    Console.Write("Input MetadataRegistration: ");
                    var metadataRegistration = Convert.ToUInt64(Console.ReadLine(), 16);
                    il2Cpp.Init(codeRegistration, metadataRegistration);
                }
                if (il2Cpp.Version >= 27 && il2Cpp.IsDumped)
                {
                    var typeDef = metadata.typeDefs[0];
                    var il2CppType = il2Cpp.types[typeDef.byvalTypeIndex];
                    metadata.ImageBase = il2CppType.data.typeHandle - metadata.header.typeDefinitionsOffset;
                }
            }
            catch (Exception e)
            {
                Log.Fatal(e, "An error occurred while processing.");
                return false;
            }

            return true;
        }
    }
}
