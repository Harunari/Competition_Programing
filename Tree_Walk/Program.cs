using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tree_Walk
{
    class Node
    {
        internal int Left;
        internal int Right;
        internal int Parent;

        public Node()
        {
            Left = -1;
            Right = -1;
            Parent = -1;
        }

    }
    class Program
    {
        const int NIL = -1;

        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            int root = NIL;
            List<int> Answer = new List<int>();
            int n = int.Parse(Console.ReadLine());
            Node[] nodes = new Node[n];
            for (int i = 0; i < n; i++)
            {
                nodes[i] = new Node();
            }

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                nodes[i].Left = input[1];
                nodes[i].Right = input[2];
                if (input[1] != NIL) { nodes[nodes[i].Left].Parent = input[0]; }
                if (input[2] != NIL) { nodes[nodes[i].Right].Parent = input[0]; }
            }

            for (int i = 0; i < n; i++)
            {
                if (nodes[i].Parent == NIL)
                {
                    root = i;
                }
            }

            PreParse(root, nodes, Answer);
            Console.WriteLine("Preorder");
            Console.WriteLine(" " + string.Join(" ", Answer));
            Answer.Clear();
            InParse(root, nodes, Answer);
            Console.WriteLine("Inorder");
            Console.WriteLine(" " + string.Join(" ", Answer));
            Answer.Clear();
            PostParse(root, nodes, Answer);
            Console.WriteLine("Postorder");
            Console.WriteLine(" " + string.Join(" ", Answer));
            Console.Out.Flush();
            Console.ReadLine();
        }

        private static bool PreParse(int u, Node[] nodes, List<int> answer)
        {
            if (u == NIL)
            {
                return false;
            }
            answer.Add(u);
            PreParse(nodes[u].Left, nodes, answer);
            PreParse(nodes[u].Right, nodes, answer);
            return true;
        }

        private static bool InParse(int u, Node[] nodes, List<int> answer)
        {
            if (u == NIL)
            {
                return false;
            }
            InParse(nodes[u].Left, nodes, answer);
            answer.Add(u);
            InParse(nodes[u].Right, nodes, answer);
            return true;
        }

        private static bool PostParse(int u, Node[] nodes, List<int> answer)
        {
            if (u == NIL)
            {
                return false;
            }
            PostParse(nodes[u].Left, nodes, answer);
            PostParse(nodes[u].Right, nodes, answer);
            answer.Add(u);
            return true;
        }
    }
}
