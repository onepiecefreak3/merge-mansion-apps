using System.Collections.Generic;
using System.Xml.Linq;

namespace merge_mansion_cli.Graphs
{
    class Node
    {
        public string Text { get; set; }

        public IList<Node> Children { get; } = new List<Node>();
        public IList<Node> Parents { get; } = new List<Node>();

        public void AddChild(Node child)
        {
            if (!Children.Contains(child))
                Children.Add(child);

            if (!child.Parents.Contains(this))
                child.Parents.Add(this);
        }
    }

    class Node<TData> : Node
    {
        public TData Data { get; }

        public Node(TData data)
        {
            Data = data;
        }
    }
}
