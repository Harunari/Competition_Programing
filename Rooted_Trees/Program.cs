using System;
using System.Collections.Generic;
using System.Linq;

namespace Rooted_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var parents = Enumerable.Repeat(-1, n).ToList();
            var nodes = new List<Node>();
            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                var nodeInfo = str.Split(' ').Select(int.Parse).ToList();
                nodes.Add(new Node
                {
                    Id = nodeInfo[0],
                    Type = "leaf",
                });
                if (nodeInfo[1] > 0)
                {
                    var children = nodeInfo.Skip(2).ToList();
                    children.ForEach(c => parents[c] = nodeInfo[0]);
                    nodes[nodes.Count - 1].Children = children;
                    nodes[nodes.Count - 1].Type = "undefined";
                }
            }
            nodes.ForEach(node => 
            {
                if (parents[node.Id] == -1)
                {
                    node.Type = "root";
                }
                else if (node.Type != "leaf")
                {
                    node.Parent = parents[node.Id];
                    node.Type = "internal node";
                }
                else
                {
                    node.Parent = parents[node.Id];
                }
            });
            nodes.ForEach(node =>
            {
                node.Depth = nodes.GetDepth(node.Id);
            });
            nodes.ForEach(node =>
            {

                Console.WriteLine($@"
node {node.Id}: parent = {node.Parent},
depth = {node.Depth},
{node.Type},
[{string.Join(", ", node.Children).Trim()}]");
            });
            Console.ReadLine();
        }
    }

    static class Extention
    {
        public static int GetDepth(this List<Node> nodes, int nodeId)
        {
            int depth = 0;
            while (nodes[nodeId].Parent != -1)
            {
                nodeId = nodes[nodeId].Parent;
                depth++;
            }
            return depth;
        }
    }

    class Node
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public int Depth { get; set; }
        public string Type { get; set; }
        public List<int> Children { get; set; }

        public Node()
        {
            Id = -1;
            Parent = -1;
            Depth = -1;
            Type = "";
            Children = new List<int>();
        }
    }
}
