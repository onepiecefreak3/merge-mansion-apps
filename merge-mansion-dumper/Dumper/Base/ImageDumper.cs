using System.Collections.Generic;
using System.Drawing;
using System.IO;
using GameLogic.Config;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace merge_mansion_dumper.Dumper.Base
{
    abstract class ImageDumper : BaseDumper<IEnumerable<(string, Image<Rgba32>)>>
    {
        public void ExportImages(string dir, SharedGameConfig config)
        {
            Directory.CreateDirectory(dir);

            foreach (var image in Dump(config))
            {
                var finalPath = Path.Combine(dir, image.Item1 + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(finalPath));

                image.Item2.SaveAsPng(finalPath);
            }
        }
    }
}
