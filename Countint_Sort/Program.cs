using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Counting_Sort
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var inputtedList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            var sb = new StringBuilder();
            CountingSort(inputtedList).ForEach(r => sb.Append(r.ToString() + ' '));
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }
        public static List<int> CountingSort(List<int> inputtedList)
        {
            if (inputtedList.Where(i => i < 0).Any())
            {
                throw new ArgumentException();
            }

            var cache = Enumerable.Repeat(0, inputtedList.Max() + 1).ToList();
            var result = Enumerable.Repeat(0, inputtedList.Count + 1).ToList();

            inputtedList.ForEach(i => cache[i]++);
            for (int i = 1; i < cache.Count; i++)
            {
                cache[i] = cache[i] + cache[i - 1];
            }
            inputtedList.ForEach(i =>
            {
                result[cache[i]] = i;
                cache[i]--;
            });
            result.RemoveAt(0);

            return result;
        }

    }
}
