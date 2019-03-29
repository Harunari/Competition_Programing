using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B022
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int candidates = input[0];
            int voters = input[1];
            int times = input[2];
            var votersOfCandidates = Enumerable.Repeat(0, candidates).ToList();
            
            for (int i = 0; i < times; i++)
            {
                var candidate = int.Parse(Console.ReadLine()) - 1;
                if (voters > 0)
                {
                    voters--;
                    votersOfCandidates[candidate]++;
                }
                if (voters != input[1] - 1)
                {
                    for (int j = 0; j < candidates; j++)
                    {
                        if (votersOfCandidates[j] > 0 && j != candidate)
                        {
                            votersOfCandidates[j]--;
                            votersOfCandidates[candidate]++;
                        }
                    }
                }
                
            }
            var sb = new StringBuilder();
            int maxValue = votersOfCandidates.Max();
            var result = votersOfCandidates
                .Select((p, i) => new { Content = p, Index = i })
                .Where(item => item.Content == maxValue)
                .Select(item => item.Index);
            result.ToList().ForEach(index => sb.AppendLine((index + 1).ToString()));
            Console.Write(sb);
            Console.ReadLine();
        }
    }
}
