using System.Collections.Generic;
using System.Text;

namespace merge_mansion_cli.Models.Wikia
{
    internal class WikiaTable
    {
        public IList<string> Classes { get; } = new List<string>();

        public WikiaText[] Names { get; set; }
        public IList<WikiaText[]> Rows { get; set; } = new List<WikiaText[]>();

        public WikiaTable(WikiaText[] names)
        {
            Names = names;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            var tableStart = "{|";
            if (Classes.Count > 0)
                tableStart += " class=\"" + string.Join(" ", Classes) + "\"";
            sb.AppendLine(tableStart);

            foreach (var name in Names)
                sb.AppendLine($"!{name}");

            foreach (var row in Rows)
            {
                sb.AppendLine("|-");
                foreach (var value in row)
                    sb.AppendLine($"| {value}");
            }

            sb.AppendLine("|}");
            return sb.ToString();
        }
    }
}
