using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace merge_mansion_cli.Wikia.Parser
{
    class WikitextParser
    {
        private static readonly RegexOptions _options = RegexOptions.Compiled;
        private static readonly Regex[] _sectionsRegex = {
            new Regex("={6}([^=]*)={6}", _options),
            new Regex("={5}([^=]*)={5}", _options),
            new Regex("={4}([^=]*)={4}", _options),
            new Regex("={3}([^=]*)={3}", _options),
            new Regex("={2}([^=]*)={2}", _options)
        };

        public void Parse(string wikitext)
        {
            var sections = ParseSections(wikitext);
        }

        private Section[] ParseSections(string wikiText)
        {
            // Parse section information
            var sections = new List<(int, int, string)>();
            var offsets = new HashSet<int>();

            for (var i = 0; i < _sectionsRegex.Length; i++)
            {
                var matches = _sectionsRegex[i].Matches(wikiText);
                var indices = matches.Select(x => (x.Index, _sectionsRegex.Length - i, x.Groups[1].Value)).ToArray();

                var filteredIndices = new List<(int, int, string)>();
                foreach (var index in indices)
                {
                    var canSkip = false;
                    for (var j = i; j > 0; j--)
                        if (offsets.Contains(index.Index - j))
                        {
                            canSkip = true;
                            break;
                        }

                    if (canSkip)
                        continue;

                    filteredIndices.Add(index);
                    offsets.Add(index.Index);
                }

                sections.AddRange(filteredIndices);
            }

            sections = sections.OrderBy(x => x.Item2).ToList();
            return sections.Select((x, i) => new Section(x.Item2, x.Item1, (i + 1 >= sections.Count ? wikiText.Length : sections[i + 1].Item1) - x.Item1, x.Item3)).ToArray();
        }

        class Section
        {
            public int Level { get; }
            public int Start { get; }
            public int Length { get; }

            public string Text { get; }

            public Section(int level, int start, int length, string text)
            {
                Level = level;
                Start = start;
                Length = length;
                Text = text;
            }
        }
    }
}
