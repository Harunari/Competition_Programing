using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BinaryTree
{
    public class Node
    {
        internal const int NIL = -1;

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

    public class BinaryTree : List<Node>
    {
        internal const int NIL = -1;
        internal const int ROOTINDEX = 0;

        public void Insert(int insertValue)
        {
            Add(new Node(NIL));

            var y = new Node(NIL);
            var x = this[ROOTINDEX];
            int newNodeIndex = Count - 1;
            while (x.Value != NIL)
            {
                y = x;
                if (insertValue < x.Value)
                {
                    if (x.Left == NIL)
                    {
                        break;
                    }
                    x = this[x.Left];
                }
                else
                {
                    if (x.Right == NIL)
                    {
                        break;
                    }
                    x = this[x.Right];
                }
            }
            this[newNodeIndex].Value = insertValue;
            this[newNodeIndex].Parent = this.Select(a => a.Value).ToList().IndexOf(y.Value);

            if (y.Value == NIL)
            {
                this[ROOTINDEX].Value = insertValue;
            }
            else if (insertValue < y.Value)
            {
                y.Left = newNodeIndex;
            }
            else
            {
                y.Right = newNodeIndex;
            }
        }
        public bool Find(int searchValue)
        {
            var x = this[ROOTINDEX];

            while (x.Value != NIL && x.Value != searchValue)
            {
                if (x.Value > searchValue)
                {
                    if (x.Left == NIL)
                    {
                        return false;
                    }
                    x = this[x.Left];
                }
                else
                {
                    if (x.Right == NIL)
                    {
                        return false;
                    }
                    x = this[x.Right];
                }
            }
            return true;
        }
        public bool Delete(int searchValue)
        {
            var y = new Node(NIL);
            var x = new Node(NIL);
            int key = this.Select(a => a.Value).ToList().IndexOf(searchValue);

            if (key == NIL)
            {
                return false;
            }
            else if (this[key].Left == NIL || this[key].Right == NIL)
            {
                y = this[key];
            }
            else
            {
                y = GetSuccessor(this[key], this);
            }

            if (y.Left != NIL)
            {
                x = this[y.Left];
            }
            else if (y.Right != NIL)
            {
                x = this[y.Right];
            }
            else
            {
                if (this[y.Parent].Left == y.Value)
                {
                    this[y.Parent].Left = NIL;
                }
                else
                {
                    this[y.Parent].Right = NIL;
                }
                return true;
            }

            x.Parent = y.Parent;
            
            // ここで消すノードの子と消すノードの親を連結させる
            if (y.Parent == NIL)
            {
                this[ROOTINDEX] = x;
            }
            else if (y == this[this[y.Parent].Left])
            {
                this[this[y.Parent].Left] = x;
            }
            else
            {
                this[this[y.Parent].Right] = x;
            }

            // case3の場合のみ
            if (searchValue != y.Value)
            {
                this[key] = y;
                return true;
            }
            else
            {
                return true;
            }

        }
        public bool PreParse(int treeIndex, List<int> answer)
        {
            if (treeIndex == NIL || treeIndex >= Count)
            {
                return false;
            }
            answer.Add(this[treeIndex].Value);
            PreParse(this[treeIndex].Left, answer);
            PreParse(this[treeIndex].Right, answer);
            return true;
        }
        public bool InParse(int treeIndex, List<int> answer)
        {
            if (treeIndex == NIL || treeIndex >= Count)
            {
                return false;
            }
            InParse(this[treeIndex].Left, answer);
            answer.Add(this[treeIndex].Value);
            InParse(this[treeIndex].Right, answer);
            return true;
        }
        private static Node GetSuccessor(Node x, BinaryTree tree)
        {
            if (x.Right != NIL)
            {
                return GetMinimum(tree[x.Right], tree);
            }
            var y = new Node(NIL);
            if (x.Parent != NIL)
            {
                y = tree[x.Parent];
            }
            while (x == tree[y.Right])
            {
                x = y;
                if (y.Parent != NIL)
                {
                    y = tree[y.Parent];
                }
                else
                {
                    break;
                }
            }
            return y;
        }
        private static Node GetMinimum(Node x, BinaryTree tree)
        {
            while (x.Left != NIL)
            {
                x = tree[x.Left];
            }
            return x;
        }
    }

    class Program
    {
        public enum Orders { print = 0, insert, find, delete };
        public const int NIL = -1;
        public const int ROOTINDEX = 0;

        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);

            var tree = new BinaryTree();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine();
                var order = str.Split();
                var enumOrder = (Orders)Enum.Parse(typeof(Orders), order[0], true);
                switch (enumOrder)
                {
                    case Orders.print:
                        List<int> Answer = new List<int>();
                        tree.InParse(ROOTINDEX, Answer);
                        Console.WriteLine(string.Join(" ", Answer));
                        Answer.Clear();
                        tree.PreParse(ROOTINDEX, Answer);
                        Console.WriteLine(string.Join(" ", Answer));
                        break;
                    case Orders.insert:
                        tree.Insert(int.Parse(order[1]));
                        break;
                    case Orders.find:
                        if (tree.Find(int.Parse(order[1])))
                        {
                            Console.WriteLine("yes");
                        }
                        else
                        {
                            Console.WriteLine("no");
                        }
                        break;
                    case Orders.delete:
                        tree.Delete(int.Parse(order[1]));
                        break;
                }
            }
            Console.Out.Flush();
            Console.ReadLine();
        }
    }
}
