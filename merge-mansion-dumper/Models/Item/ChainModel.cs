using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merge_mansion_dumper.Models.Item
{
    class ChainModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<ItemModel> Items { get; set; }
    }
}
