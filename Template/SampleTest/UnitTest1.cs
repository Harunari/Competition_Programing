using System;
using System.IO;
using Xunit;
using Sample;
using System.Collections.Generic;
using System.Linq;
using static Sample.Settings;

namespace SampleTest
{
    public class ProblemsTest
    {
        [Fact]
        public void Test1()
        {
            AssertInOut(Input1, Output1);
        }

        [Fact]
        public void Test2()
        {
            AssertInOut(Input2, Output2);
        }

        [Fact]
        public void Test3()
        {
            AssertInOut(Input3, Output3);
        }

        [Fact]
        public void Test4()
        {
            AssertInOut(Input4, Output4);
        }

        internal void AssertInOut(string inputFileName, string outputFileName)
        {
            using (var input = new StreamReader(inputFileName))
            using (var output = new StringWriter())
            {
                Console.SetIn(input);
                Console.SetOut(output);

                Program.Solve();

                Assert.Equal(File.ReadAllText(outputFileName).Trim(), output.ToString().Trim());
            }
        }

        internal static string Input1 { get; set; } = "Input1.txt";
        internal static string Input2 { get; set; } = "Input2.txt";
        internal static string Input3 { get; set; } = "Input3.txt";
        internal static string Input4 { get; set; } = "Input4.txt";

        internal static string Output1 { get; set; } = "Output1.txt";
        internal static string Output2 { get; set; } = "Output2.txt";
        internal static string Output3 { get; set; } = "Output3.txt";
        internal static string Output4 { get; set; } = "Output4.txt";
    }

    public class LibraryTest
    {
        public class PriorityQueueTest : IDisposable
        {
            List<int> sourceList = new List<int> { 3, 5, 2, 1, 6, 7, 9, 8, 0, 4 };
            readonly PriorityQueue<int> dscQue = new PriorityQueue<int>(Priority.Larger);
            readonly PriorityQueue<int> ascQue = new PriorityQueue<int>(Priority.Smaller);

            public PriorityQueueTest()
            {
                foreach (var item in sourceList)
                {
                    dscQue.Enqueue(item);
                    ascQue.Enqueue(item);
                }
            }

            [Fact]
            public void 降順設定の場合中身を列挙するとき大きいもの順で出てくる()
            {
                var prev = int.MaxValue;
                for (int i = 0; i < sourceList.Count; i++)
                {
                    Assert.True(prev > dscQue.Peek());
                    prev = dscQue.Dequeue();
                }
            }

            [Fact]
            public void 昇順設定の場合中身を列挙するとき小さいもの順で出てくる()
            {
                var prev = int.MinValue;
                for (int i = 0; i < sourceList.Count; i++)
                {
                    Assert.True(prev < ascQue.Peek());
                    prev = ascQue.Dequeue();
                }
            }

            [Fact]
            public void 正しい要素数を返す()
            {
                Assert.Equal(sourceList.Count, dscQue.Count());
            }

            [Fact]
            public void 要素を削除できる()
            {
                dscQue.Dequeue();
                Assert.Equal(sourceList.Count - 1, dscQue.Count());
            }

            [Fact]
            public void 降順設定の場合要素を削除するとき一番大きい値が削除される()
            {
                Assert.Equal(sourceList.Max(), dscQue.Dequeue());
            }

            [Fact]
            public void 昇順設定の場合要素を削除するとき一番小さい値が削除される()
            {
                Assert.Equal(sourceList.Min(), ascQue.Dequeue());
            }

            [Fact]
            public void 降順設定の場合要素を削除したときも大きいもの順で残りの要素が列挙される()
            {
                dscQue.Dequeue();
                var prev = int.MaxValue;
                for (int i = 0; i < dscQue.Count(); i++)
                {
                    Assert.True(prev > dscQue.Peek());
                    prev = dscQue.Dequeue();
                }
            }

            [Fact]
            public void 昇順設定の場合要素を削除したときも小さいもの順で残りの要素が列挙される()
            {
                ascQue.Dequeue();
                var prev = int.MinValue;
                for (int i = 0; i < ascQue.Count(); i++)
                {
                    Assert.True(prev < ascQue.Peek());
                    prev = ascQue.Dequeue();
                }
            }

            [Fact]
            public void 要素が0のとき取り出そうとするとエラー()
            {
                try
                {
                    for (int i = 0; i <= sourceList.Count; i++)
                    {
                        dscQue.Dequeue();
                    }
                }
                catch (Exception ex)
                {
                    Assert.Equal("要素が空です", ex.Message);
                }
                try
                {
                    dscQue.Peek();
                }
                catch (Exception ex)
                {
                    Assert.Equal("要素が空です", ex.Message);
                }
            }

            [Fact]
            public void LINQを使用できる()
            {
                var result = dscQue.Where(q => q < 5).OrderBy(o => o);
                for (int i = 0; i < 5; i++)
                {
                    Assert.Equal(i, result.ElementAt(i));
                }
                Assert.Equal((0 + 4) * 5 / 2, result.Sum());
            }

            [Fact]
            public void リストに変換できその中の要素も正しい()
            {
                Assert.Equal(typeof(List<int>), dscQue.ToList().GetType());
                Assert.Equal(sourceList.Count, dscQue.ToList().Count);
            }

            [Fact]
            public void 配列に変換できその中の要素も正しい()
            {
                Assert.Equal(typeof(int[]), dscQue.ToArray().GetType());
                Assert.Equal(sourceList.Count, dscQue.ToList().Count);
            }

            [Fact]
            public void クリアすると中身がなくなる()
            {
                ascQue.Clear();
                Assert.Equal(0, ascQue.Count());
            }

            public void Dispose() { }
        }
    }
}
