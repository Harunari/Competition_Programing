using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complete_Binary_Tree
{
    class Node
    {
        public int Value { get; set; }
        public int Parent { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
    class Program
    {
        private const int NIL = -1;
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            int n = int.Parse(Console.ReadLine());
            var inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            var nodes = new List<Node>();

            foreach (var item in inputList)
            {
                int indexOfThisNode = nodes.Count + 1;
                
                nodes.Add(new Node
                {
                    Value = item,
                    Parent = (indexOfThisNode / 2 != 0) ? indexOfThisNode / 2 : NIL,
                    Left = indexOfThisNode * 2,
                    Right = indexOfThisNode * 2 + 1
                });
            }
            foreach (var node in nodes)
            {
                var sb = new StringBuilder();
                int i = 1;
                sb.Append($"node {i}: ");
                sb.Append($"key = {node.Value}, ");
                if (node.Parent != NIL)
                {
                    sb.Append($"parent key = {nodes[node.Parent - 1].Value}, ");
                }
                if (nodes.Count >= node.Left)
                {
                    sb.Append($"left key = {nodes[node.Left - 1].Value},");
                }
                if (nodes.Count >= node.Right)
                {
                    sb.Append($" right key = {nodes[node.Right - 1].Value},");
                }
                Console.WriteLine(sb);
                i++;
            }
            Console.Out.Flush();
            Console.ReadLine();
        }
    }
}
