using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALDS1_7_A
{
    class Node
    {
        internal int parent;
        internal int sibling;
        internal int degree;
        internal int depth;
        internal int height;
        internal string type;
        internal List<int> children;

        public Node()
        {
            parent = -1;
            sibling = -1;
            children = new List<int>();
        }
    }

    class Class1
    {
        static void m()
        {
            int n = int.Parse(Console.ReadLine());
            Node[] nodes = new Node[n];

            for (int i = 0; i < n; i++) nodes[i] = new Node();

            for (int i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                if (input[1] != -1 && input[2] != -1)
                {
                    nodes[input[0]].children.Add(input[1]);
                    nodes[input[1]].parent = input[0];
                    nodes[input[1]].sibling = input[2];
                    nodes[input[0]].children.Add(input[2]);
                    nodes[input[2]].parent = input[0];
                    nodes[input[2]].sibling = input[1];
                    nodes[input[0]].degree = 2;
                }
                else if (input[1] != -1)
                {
                    nodes[input[0]].children.Add(input[1]);
                    nodes[input[1]].parent = input[0];
                    nodes[input[0]].degree++;
                }
                else if (input[2] != -1)
                {
                    nodes[input[0]].children.Add(input[2]);
                    nodes[input[2]].parent = input[0];
                    nodes[input[0]].degree++;
                }

            }

            Stack<Node> stkDepth = new Stack<Node>();
            Stack<Node> stkHeight = new Stack<Node>();

            for (int i = 0; i < n; i++)
            {
                if(nodes[i].parent == -1)
                {
                    nodes[i].type = "root";
                    stkDepth.Push(nodes[i]);
                }
                else
                {
                    if (nodes[i].children.Count > 0)
                    {
                        nodes[i].type = "internal node";
                    }
                    else
                    {
                        nodes[i].type = "leaf";
                        stkHeight.Push(nodes[i]);
                    }
                }
            }

            while (stkDepth.Count > 0)
            {
                Node temp = stkDepth.Pop();

                for (int i = 0; i < temp.children.Count; i++)
                {
                    nodes[temp.children[i]].depth = temp.depth + 1;
                    stkDepth.Push(nodes[temp.children[i]]);
                }
            }

            while (stkHeight.Count > 0)
            {
                Node temp = stkHeight.Pop();

                if (temp.parent != -1)
                {
                    nodes[temp.parent].height = Math.Max(nodes[temp.parent].height, temp.height + 1);
                    stkHeight.Push(nodes[temp.parent]);
                }
            }
        }
        
    }
}
