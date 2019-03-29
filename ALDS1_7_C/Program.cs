using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALDS1_7_C
{
    struct Node
    {
        internal int left;
        internal int right;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Node[] nodes = new Node[n];
            bool[] isChild = new bool[n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                nodes[input[0]].left = input[1];
                nodes[input[0]].right = input[2];

                if (input[1] != -1)
                {
                    isChild[input[1]] = true;
                }
                if (input[2] != -1)
                {
                    isChild[input[2]] = true;
                }

                int rootIndex = Array.IndexOf(isChild, false);
                
            }
        }
    }
}
