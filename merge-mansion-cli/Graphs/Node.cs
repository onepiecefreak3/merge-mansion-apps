using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merge_mansion_cli.Graphs
{
    class Node
    {
        public string Text { get; set; }
        public IList<Node> Children { get; } = new List<Node>();

        public IList<Node> Parents { get; } = new List<Node>();

        public void AddChild(Node child)
        {
            Children.Add(child);
            child.Parents.Add(this);
        }
    }
}
