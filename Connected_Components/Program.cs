using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Connected_Components
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            int userSize = input.ElementAt(0);
            int relationSize = input.ElementAt(1);
            var relations = new Queue<int>[userSize];
            for (int i = 0; i < userSize; i++)
            {
                relations[i] = new Queue<int>();
            }
            for (int i = 0; i < relationSize; i++)
            {
                var relation = Console.ReadLine().Split(' ').Select(int.Parse);
                relations[relation.ElementAt(0)].Enqueue(relation.ElementAt(1));
            }
            int questionSize = int.Parse(Console.ReadLine());
            for (int i = 0; i < questionSize; i++)
            {
                var searchContent = Console.ReadLine().Split(' ').Select(int.Parse);
                Console.WriteLine(Dfs(searchContent.ElementAt(0), userSize, relations, searchContent.ElementAt(1)) ? "yes" : "no");
            }
            Console.ReadLine();

        }

        public static bool Dfs(int rootNode, int n, Queue<int>[] relations, int searchNode)
        {
            var copiedRelations = new Queue<int>[n];
            for (int i = 0; i < relations.Length; i++)
            {
                copiedRelations[i] = new Queue<int>(relations[i]);
            }
            var stack = new Stack();
            var colors = new Color[n + 1];

            stack.Push(rootNode);
            colors[rootNode] = Color.Gray;
            
            while (stack.Count != 0)
            {
                int refferensedNode = (int)stack.Peek();
                int nextNode = GetNextNode(refferensedNode, relations);
                if (searchNode == nextNode)
                {
                    return true;
                }
                if (nextNode != -1)
                {
                    if (colors[nextNode] == Color.White)
                    {
                        colors[nextNode] = Color.Gray;
                        stack.Push(nextNode);
                    }
                }
                else
                {
                    stack.Pop();
                    colors[refferensedNode] = Color.Black;
                }
            }
            return false;
        }

        public static int GetNextNode(int node, Queue<int>[] relations)
        {
            if (relations[node].Any())
            {
                return relations[node].Dequeue();
            }
            return -1;
        }

        enum Color
        {
            White = 0,
            Gray,
            Black
        }
    }
}
