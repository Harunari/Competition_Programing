using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BST1
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodesList = new NodeList(10);
            var nodes = new List<Node>();
            
            var result = new StringBuilder();
            Node rootNode = new Node();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                if (input[0][0] == 'i')
                {
                    rootNode = rootNode.Insert(int.Parse(input[1]));
                }
                else if (input[0][0] == 'f')
                {
                    string answer = "yes";
                    if (rootNode.Find(int.Parse(input[1])) is null)
                    {
                        answer = "no";
                    }
                    result.AppendLine(answer);
                }
                else if (input[0][0] == 'd')
                {
                    rootNode = rootNode.Delete(int.Parse(input[1]));
                }
                else
                {
                    result.AppendLine(string.Join(' ', rootNode.InParse()));
                    result.AppendLine(string.Join(' ', rootNode.PreParse()));
                }
                nodesList[0] = rootNode;
                
            }
            IEnumerable<Tuple<Node, int>> aa = nodesList.Where(node => node != null)
                .Select((node, index) => Tuple.Create(node, index));
            Console.WriteLine(result.ToString());
            Console.ReadLine();
        }
    }

    class Node
    {
        public int Key { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int value = -1)
        {
            Key = value;
        }

        public Node Insert(int key)
        {
            if (Key == -1)
            {
                return new Node
                {
                    Key = key,
                    Parent = null,
                    Left = null,
                    Right = null
                };
            }
            var insertNode = new Node(key);
            var parent = new Node();
            var refferensedNode = this;
            while (refferensedNode != null)
            {
                parent = refferensedNode;
                if (insertNode.Key < refferensedNode.Key)
                {
                    refferensedNode = refferensedNode.Left;
                }
                else
                {
                    refferensedNode = refferensedNode.Right;
                }
            }

            insertNode.Parent = parent;

            if (insertNode.Key < parent.Key)
            {
                parent.Left = insertNode;
            }
            else
            {
                parent.Right = insertNode;
            }
            return this;
        }
        public Node Find(int key)
        {
            var refferensedNode = this;
            while (true)
            {
                if (refferensedNode is null)
                {
                    return null;
                }
                else if (refferensedNode.Key == key)
                {
                    return refferensedNode;
                }

                if (refferensedNode.Key > key)
                {
                    refferensedNode = refferensedNode.Left;
                }
                else
                {
                    refferensedNode = refferensedNode.Right;
                }
            }
        }
        public Node Delete(int key)
        {
            var havingDeleteKey = Find(key);
            if (havingDeleteKey is null) { return this; }

            Node selectedForDelete;
            if (havingDeleteKey.Left is null || havingDeleteKey.Right is null)
            {
                selectedForDelete = havingDeleteKey;
            }
            else
            {
                selectedForDelete = havingDeleteKey.GetSuccessor();
            }

            Node childNode;
            if (selectedForDelete.Left != null)
            {
                childNode = selectedForDelete.Left;
            }
            else
            {
                childNode = selectedForDelete.Right;
            }

            if (childNode != null)
            {
                childNode.Parent = selectedForDelete.Parent;
            }

            // 選ばれているノードがrootであれば
            if (selectedForDelete.Parent is null)
            {
                selectedForDelete = childNode;
            }
            else if (selectedForDelete == selectedForDelete.Parent.Left)
            {
                selectedForDelete.Parent.Left = childNode;
            }
            else
            {
                selectedForDelete.Parent.Right = childNode;
            }

            if (selectedForDelete.Key != havingDeleteKey.Key)
            {
                havingDeleteKey.Key = selectedForDelete.Key;
            }
            return this;
        }

        public List<int> InParse()
        {
            var result = new List<int>();

            if (Left != null)
            {
                result.AddRange(Left.InParse());
            }
            result.Add(Key);
            if (Right != null)
            {
                result.AddRange(Right.InParse());
            }

            return result;
        }
        public List<int> PreParse()
        {
            var result = new List<int> { Key };
            if (Left != null)
            {
                result.AddRange(Left.PreParse());
            }
            if (Right != null)
            {
                result.AddRange(Right.PreParse());
            }

            return result;
        }

        protected Node GetSuccessor()
        {
            if (Right != null)
            {
                return Right.GetMinimum();
            }

            var parent = Parent;
            var refferensedNode = this;
            while (parent != null && refferensedNode == parent.Right)
            {
                refferensedNode = parent;
                parent = parent.Parent;
            }
            return parent;
        }
        protected Node GetMinimum()
        {
            var node = this;
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
    }

    class NodeList : ICollection, IEnumerable<Node>
    {
        private List<Node> _nodes { get; set; } = new List<Node>();
        public Node this[int index]
        {
            get
            {
                return _nodes[index];
            }
            set
            {
                _nodes[index] = value;
            }
        }


        int ICollection.Count
        {
            get { return _nodes.Count; }
        }

        object ICollection.SyncRoot
        {
            get { return this; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        public NodeList()
        {
            _nodes.Clear();
        }
        public NodeList(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                _nodes.Add(new Node());
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            _nodes.ForEach(node =>
            {
                array.SetValue(node, index);
                index++;
            });
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach (var node in _nodes)
            {
                if (node != null)
                {
                    yield return node;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddRange(IEnumerable<Node> nodes)
        {
            _nodes.AddRange(nodes);
        }
    }
}
