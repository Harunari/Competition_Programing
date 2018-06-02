using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALDS1_7_A
{
    class Program
    {
        class Node
        {
            internal int parent;
            internal int depth;
            internal string type;
            internal List<int> children;

            public Node()
            {
                parent = -1;
                depth = 0;
                type = "";
                children = new List<int>();
            }
        }


        static void Main(string[] args)
        {
            int i, j;
            int n = int.Parse(Console.ReadLine());

            // 各要素がNode型の配列 ここでは型宣言しているだけでコンストラクタは実行されていない
            Node[] nodes = new Node[n];
            // new演算子でコンストラクタ実行
            for (i = 0; i < n; i++) nodes[i] = new Node();

            for (j = 0; j < n; j++)
            {
                int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                // 接点があれば
                if (input[1] > 0)
                {
                    // ここのfor文が実行されるたび、上のfor文のループ回数が減る(重複を防ぐため)
                    // 上のforループでは入力や入力場所がjに依存しないから大丈夫
                    for (j = 0; j < input[1]; j++)
                    {
                        nodes[input[0]].children.Add(input[j + 2]);
                        nodes[input[j + 2]].parent = input[0];
                    }
                }
            }
            int rootIndex = 0;

            for (i = 0; i < n; i++)
            {
                // nodes[i]に親ノードが存在すれば
                if (nodes[i].parent != -1)
                {
                    // node[i]に子ノードがあれば"internal node"
                    nodes[i].type = nodes[i].children.Count > 0 ?
                        "internal node" : "leaf";
                }
                else
                {
                    // node[i]はroot
                    rootIndex = i;
                    nodes[i].type = "root";

                }
            }

            // ここから各ノードの深さを計算していく
            Stack<Node> stk = new Stack<Node>();
            stk.Push(nodes[rootIndex]);

            while (stk.Count > 0)
            {
                Node temp = stk.Pop();

                foreach (var child in temp.children)
                {
                    nodes[child].depth = temp.depth + 1;

                    if (nodes[child].children.Count > 0)
                        stk.Push(nodes[child]);
                }

            }

            StringBuilder sb = new StringBuilder();
            for (i = 0; i < n; i++)
            {
                sb.AppendLine("node " + i + ": parent = " + nodes[i].parent + ", depth = " + nodes[i].depth + ", " + nodes[i].type +
                    ", [" + string.Join(", ", Array.ConvertAll(nodes[i].children.ToArray(), a => a.ToString())) + "]");
            }
            Console.Write(sb);
            Console.ReadLine();
        }
    }
}
