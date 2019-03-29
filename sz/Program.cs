using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sz
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var words = new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine().TrimEnd());
            }
            var result = new List<string>();
            foreach (var item in words)
            {
                char tail1 = item[item.Length - 1];
                char tail2 = item[item.Length - 2];
                var sox = new List<char> { 's', 'o', 'x' };
                var cs = new List<char> { 'c', 's' };
                var aiueo = new List<char> { 'a', 'i', 'u', 'e', 'o' };
                if (sox.Contains(tail1))
                {
                    result.Add(item + "es");
                }
                else if ((cs.Contains(tail2)) && tail1 == 'h')
                {
                    result.Add(item + "es");
                }

                else if (tail2 == 'f' && tail1 == 'e')
                {
                    result.Add(item.Remove(item.Length - 2 , 2) + "ves");
                }
                else if (tail1 == 'f')
                {
                    result.Add(item.Remove(item.Length - 1, 1) + "ves");
                }
                else if (tail1 == 'y' && (!aiueo.Contains(tail2)))
                {
                    result.Add(item.Remove(item.Length - 1, 1) + "ies");
                }

                else
                {
                    result.Add(item + "s");
                }
            }
            result.ForEach(Console.WriteLine);
            Console.ReadLine();

        }
    }
}
