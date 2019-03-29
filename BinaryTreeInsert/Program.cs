using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeInsert
{
    class Program
    {
        private const int NIL = -1;
        private const int ROOTINDEX = 0;

        class Node
        {
            public int Parent { get; set; }
            public int Value { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }

            public Node(int input)
            {
                Parent = NIL;
                Value = input;
                Left = NIL;
                Right = NIL;
            }
        }

        static void Main(string[] args)
        {
            var tree = new List<Node>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                if (str == "print")
                {
                    List<int> Answer = new List<int>();
                    InParse(0, tree, Answer);
                    Console.WriteLine(string.Join(" ", Answer));
                    Answer.Clear();
                    PreParse(0, tree, Answer);
                    Console.WriteLine(string.Join(" ", Answer));
                    Console.ReadLine();
                }
                else
                {
                    var insertStatement = str.Split();
                    int inputValue = int.Parse(insertStatement[1]);
                    Insert(tree, inputValue);
                }
            }


        }

        private static void Insert(List<Node> tree, int inputValue)
        {
            tree.Add(new Node(NIL));

            var y = new Node(NIL);
            var x = tree[ROOTINDEX];
            int newNodeIndex = tree.Count - 1;
            while (x.Value != NIL)
            {
                y = x;
                if (inputValue < x.Value)
                {
                    if (x.Left == NIL)
                    {
                        break;
                    }
                    x = tree[x.Left];
                }
                else
                {
                    if (x.Right == NIL)
                    {
                        break;
                    }
                    x = tree[x.Right];
                }
            }
            tree[newNodeIndex].Value = inputValue;
            tree[newNodeIndex].Parent = tree.Select(a => a.Value).ToList().IndexOf(y.Value);

            if (y.Value == NIL)
            {
                tree[ROOTINDEX].Value = inputValue;
            }
            else if (inputValue < y.Value)
            {
                y.Left = newNodeIndex;
            }
            else
            {
                y.Right = newNodeIndex;
            }
        }

        private static bool Find(List<Node> tree, int k)
        {
            var x = tree[ROOTINDEX];

            while (x.Value != NIL && x.Value != k)
            {
                if (x.Value > k)
                {
                    x = tree[x.Left];
                }
                else
                {
                    x = tree[x.Right];
                }
            }
            if (x.Value == NIL)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool PreParse(int u, List<Node> nodes, List<int> answer)
        {
            if (u == NIL)
            {
                return false;
            }
            answer.Add(nodes[u].Value);
            PreParse(nodes[u].Left, nodes, answer);
            PreParse(nodes[u].Right, nodes, answer);
            return true;
        }

        private static bool InParse(int u, List<Node> nodes, List<int> answer)
        {
            if (u == NIL)
            {
                return false;
            }
            InParse(nodes[u].Left, nodes, answer);
            answer.Add(nodes[u].Value);
            InParse(nodes[u].Right, nodes, answer);
            return true;
        }
    }
}
