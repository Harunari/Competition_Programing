using System;
using System.Collections.Generic;
using System.Text;

namespace ALDS1_7_B
{
    class Node
    {
        public int Parent { get; set; }
        public int Sibling { get; set; }
        public int Degree { get; set; }
        public int Depth { get; set; }
        public int Hight { get; set; }
        public string Type { get; set; }
        public List<int> Children { get; set; }


        public Node()
        {
            Parent = -1;
            Sibling = -1;
            Degree = 0;
            Depth = -1;
            Hight = -1;
            Type = "";
            Children = new List<int>();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            var n = int.Parse(Console.ReadLine());
            var Nodes = new Node[n];
            for (i = 0; i < n; i++) Nodes[i] = new Node();

            for (i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int parent = input[0], left = input[1], right = input[2];
                if (left == -1 && right == -1)
                {
                    Nodes[parent].Type = "leaf";
                    Nodes[parent].Hight = 0;
                }
                else if (left == -1 || right == -1)
                {
                    var child = (left > -1) ? left : right;
                    Nodes[parent].Children.Add(child);
                    Nodes[child].Parent = parent;
                    Nodes[parent].Degree = 1;
                }
                else
                {
                    Nodes[parent].Children.Add(right);
                    Nodes[parent].Children.Add(left);

                    Nodes[left].Parent = parent;
                    Nodes[left].Sibling = right;

                    Nodes[right].Parent = parent;
                    Nodes[right].Sibling = left;

                    Nodes[parent].Degree = 2;
                }
            }

            int rootIndex = 0;

            for (i = 0; i < n; i++)
            {
                if (Nodes[i].Parent == -1)
                {
                    Nodes[i].Type = "root";
                    Nodes[i].Depth = 0;
                    rootIndex = i;
                }
                else if (Nodes[i].Type != "leaf")
                {
                    Nodes[i].Type = "internal node";
                }
            }

            var stk = new Stack<Node>();
            var MaxDepth = 0;
            stk.Push(Nodes[rootIndex]);

            while (stk.Count > 0)
            {
                Node temp = stk.Pop();

                foreach (var child in temp.Children)
                {
                    Nodes[child].Depth = temp.Depth + 1;
                    MaxDepth = (Nodes[child].Depth > MaxDepth) ? Nodes[child].Depth : MaxDepth;
                    if (Nodes[child].Children.Count > 0)
                    {
                        stk.Push(Nodes[child]);
                    }
                }

            }

            var ParentPushflag = true;
            stk.Push(Nodes[rootIndex]);
            while (stk.Count > 0)
            {
                var node = stk.Pop();
                foreach (var child in node.Children)
                {
                    if (Nodes[child].Hight == -1)
                    {
                        if (ParentPushflag)
                        {
                            stk.Push(node);
                            ParentPushflag = false;
                        }
                        
                        stk.Push(Nodes[child]);
                    }
                    else
                    {
                        node.Hight = (Nodes[child].Hight + 1 > node.Hight) ? Nodes[child].Hight + 1 : node.Hight;
                    }
                }
                ParentPushflag = true;
            }
            

            StringBuilder sb = new StringBuilder();
            for (i = 0; i < n; i++)
            {
                sb.AppendLine("node " + i + ": parent = " + Nodes[i].Parent + ", sibling = " + Nodes[i].Sibling + ", degree = " +
                    Nodes[i].Degree + ", depth = " + Nodes[i].Depth + ", height = " + Nodes[i].Hight + ", " + Nodes[i].Type);
            }
            Console.Write(sb);
            Console.ReadLine();
        }
    }

}