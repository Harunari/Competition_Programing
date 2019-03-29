using System;
using System.Collections.Generic;
using System.Linq;

namespace Binary_Tree
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
                var input = Console.ReadLine().Split(' ').Select(int.Parse);
                int left = input.ElementAt(1);
                int right = input.ElementAt(2);
                if (left != -1)
                {
                    parents[left] = i;
                }
                if (right != -1)
                {
                    parents[right] = i;
                }
                nodes.Add(new Node
                {
                    Id = i,
                    Left = left,
                    Right = right
                });
            }
            nodes.ForEach(node =>
            {
                node.Parent = parents[node.Id];
            });
            nodes.ForEach(node =>
            {
                var degAndType = node.GetDegreeAndType();
                int degree = degAndType.Item1;
                string type = degAndType.Item2;
                Console.WriteLine($"node {node.Id}:" +
                    $" parent = {node.Parent}, " +
                    $"sibling = {nodes.GetSibling(node.Id)}, " +
                    $"degree = {degree}, " +
                    $"depth = {nodes.GetDepth(node.Id)}, " +
                    $"height = {nodes.SetHeight(node.Id)}," +
                    $" {type}");
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

        public static int GetSibling(this List<Node> nodes, int nodeId)
        {
            if (nodes[nodeId].Parent == -1)
            {
                return -1;
            }
            if (nodes[nodes[nodeId].Parent].Left != nodeId
                && nodes[nodes[nodeId].Parent].Left != -1)
            {
                return nodes[nodes[nodeId].Parent].Left;
            }
            if (nodes[nodes[nodeId].Parent].Right != nodeId
                && nodes[nodes[nodeId].Parent].Right != -1)
            {
                return nodes[nodes[nodeId].Parent].Right;
            }
            return -1;
        }

        public static int SetHeight(this List<Node> nodes, int nodeId)
        {
            int h1, h2;
            h1 = h2 = 0;
            if (nodes[nodeId].Right != -1)
            {
                h1 = SetHeight(nodes, nodes[nodeId].Right) + 1;
            }
            if (nodes[nodeId].Left != -1)
            {
                h2 = SetHeight(nodes, nodes[nodeId].Left) + 1;
            }
            return h1 > h2 ? h1 : h2;
        }
    }

    class Node
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Parent { get; set; }
        public Node()
        {
            Id = Left = Right = -1;
        }

        public (int, string) GetDegreeAndType()
        {
            if (Left == -1 && Right == -1)
            {
                return (0, "leaf");
            }
            else if (Left != -1 && Right != -1)
            {
                if (Parent != -1)
                {
                    return (2, "internal node");
                }
                return (2, "root");
            }
            else
            {
                if (Parent != -1)
                {
                    return (1, "internal node");
                }
                return (1, "root");
            }
        }
    }
}
