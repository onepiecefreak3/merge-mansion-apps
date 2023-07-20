using System;
using System.Collections.Generic;

namespace merge_mansion_dumper.Graphs
{
    static class GraphViz
    {
        private const string GraphVizTemplate_ = "digraph{{rankdir=\"{1}\";node[shape={2}];{0}}}";

        public static string GetGraph(IList<Node> nodes, GraphDirection dir = GraphDirection.TopToBottom, NodeShape shape = NodeShape.Box)
        {
            return string.Format(GraphVizTemplate_, GetNodeRelations(nodes), GetGraphDirection(dir), GetNodeShape(shape));
        }

        private static string GetNodeRelations(IList<Node> nodes)
        {
            var res = string.Empty;

            // Dump numbered nodes with their label
            var nodeDictionary = new Dictionary<Node, int>();
            for (var i = 0; i < nodes.Count; i++)
            {
                res += $"{i}[label=\"{nodes[i].Text}\"];";
                nodeDictionary[nodes[i]] = i;
            }

            // Print their relations
            foreach (var nodePair in nodeDictionary)
            foreach (var child in nodePair.Key.Children)
                res += $"{nodePair.Value}->{nodeDictionary[child]};";

            return res;
        }

        private static string GetGraphDirection(GraphDirection dir)
        {
            switch (dir)
            {
                case GraphDirection.LeftToRight:
                    return "LR";

                case GraphDirection.TopToBottom:
                    return "TB";

                default:
                    throw new InvalidOperationException("Unknown graph direction.");
            }
        }

        private static string GetNodeShape(NodeShape shape)
        {
            switch (shape)
            {
                case NodeShape.Box:
                    return "box";

                case NodeShape.Circle:
                    return "circle";

                default:
                    throw new InvalidOperationException("Unknown nodes shape.");
            }
        }
    }

    public enum GraphDirection
    {
        LeftToRight,
        TopToBottom
    }

    public enum NodeShape
    {
        Box,
        Circle
    }
}
