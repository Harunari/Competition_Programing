using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeWalk2
{
    class Program
    {
        public static class MyEnumerable
        {
            public static IEnumerable<T> Repeat<T>( Func<int, T> activator, int count)
            {
                for (int i = 0; i < count; i++)
                {
                    yield return activator(i);
                }
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = MyEnumerable.Repeat(i => new Node(i), n).ToList();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse);
                int left = input.ElementAt(1);
                int right = input.ElementAt(2);
                nodes[i].Id = i;
                nodes[i].Left = left;
                nodes[i].Right = right;

                if (left != -1)
                {
                    nodes[left].Parent = i;
                }
                if (right != -1)
                {
                    nodes[right].Parent = i;
                }
                
            }

            var rootNode = nodes.Where(node => node.Parent == -1).First();
            Console.WriteLine("Preorder");
            Console.WriteLine(string.Join(" ", PreParse(rootNode, nodes)));
            Console.WriteLine("");
            Console.WriteLine("Inorder");
            Console.WriteLine(string.Join(" ", InorderParse(rootNode, nodes)));
            Console.WriteLine("");
            Console.WriteLine("Postorder");
            Console.WriteLine(string.Join(" ", PostorderParse(rootNode, nodes)));
            Console.WriteLine("");
            Console.ReadLine();
        }

        public static List<int> PreParse(Node node, List<Node> nodes)
        {
            var result = new List<int> { node.Id };
            
            if (node.Left != -1)
            {
                result.AddRange(PreParse(nodes[node.Left], nodes));
            }
            if (node.Right != -1)
            {
                result.AddRange(PreParse(nodes[node.Right], nodes));
            }
            return result;
        }

        public static List<int> InorderParse(Node node, List<Node> nodes)
        {
            var result = new List<int>();

            if (node.Left != -1)
            {
                result.AddRange(InorderParse(nodes[node.Left], nodes));
            }
            result.Add(node.Id);
            if (node.Right != -1)
            {
                result.AddRange(InorderParse(nodes[node.Right], nodes));
            }

            return result;
        }

        public static List<int> PostorderParse(Node node, List<Node> nodes)
        {
            var result = new List<int>();

            if (node.Left != -1)
            {
                result.AddRange(PostorderParse(nodes[node.Left], nodes));
            }
            if (node.Right != -1)
            {
                result.AddRange(PostorderParse(nodes[node.Right], nodes));
            }
            result.Add(node.Id);

            return result;
        }
    }

    class Node
    {
        public int Id { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public int Parent { get; set; }
        public Node(int index)
        {
            Id = index;
            Parent = Left = Right = -1;
        }

        
    }
}
