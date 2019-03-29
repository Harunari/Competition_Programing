using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubly_linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new Nodes();
            nodes.Init();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var inputStr = Console.ReadLine();
                int firstNodeKey = -1, lastNodeKey = -1;
                var key = int.Parse(inputStr[7].ToString());
                if (inputStr[0] == 'i')
                {
                    nodes = nodes.Insert(key);
                }
                else
                {
                    firstNodeKey = nodes.First().Key;
                    lastNodeKey = nodes.Last().Key;
                    if (firstNodeKey == key)
                    {
                        nodes.DeleteFirst();
                    }
                    else if (lastNodeKey == key)
                    {
                        nodes.DeleteLast();
                    }
                    else
                    {
                        nodes.DeleteNode(key);
                    }
                }
            }

            // 番兵消す
            nodes.RemoveAt(0);
            nodes.Reverse();

            var sb = new StringBuilder();
            nodes.ForEach(node => sb.Append($"{node.Key}" + ' '));
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
    }


    public class Node
    {
        public int Key { get; set; }
        public int Prev { get; set; }
        public int Next { get; set; }
    }

    public class Nodes : List<Node>
    {
        const int NIL = -1;

        public Nodes Init()
        {
            Add(new Node
            {
                Key = NIL,
                Prev = NIL,
                Next = NIL
            });

            return this;
        }
        public Nodes Insert(int newKey)
        {
            var sentinel = this[0];
            var thisIndex = Count;
            if (sentinel.Next != NIL)
            {
                var nextNode = this[sentinel.Next];
                nextNode.Prev = thisIndex;
            }

            Add(new Node
            {
                Key = newKey,
                Prev = 0,   // sentinelIndex
                Next = sentinel.Next
            });
            sentinel.Next = thisIndex;

            return this;
        }

        public int Search(int key)
        {
            var nextIndex = this[0].Next;
            while (nextIndex != NIL)
            {
                if (this[nextIndex].Key == key)
                {
                    return nextIndex;
                }
                nextIndex = this[nextIndex].Next;
            }
            return NIL;
        }

        private void Delete(int  deleteIndex)
        {
            RemoveAt(deleteIndex);
            for (int i = deleteIndex; i < Count; i++)
            {
                this[i].Next--;
                this[i].Prev--;
            }
            this[0].Next = Count - 1;
            this[Count - 1].Prev = 0;
        }

        public bool DeleteNode(int key)
        {
            if (key == 0) { return false; }

            int deleteIndex = Search(key);
            if (deleteIndex == NIL) { return false; }
            Delete(deleteIndex);

            return true;
        }

        public void DeleteFirst()
        {
            Delete(Count - 1);
        }

        public void DeleteLast()
        {
            Delete(1);
        }
    }
}
