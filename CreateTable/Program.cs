using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateTable
{
    class Program
    {
        public static int?[,] cells;

        static void Main(string[] args)
        {
            int[] hw = Console.ReadLine().Split(' ').Select(int.Parse).ToArray(); ;
            cells = new int?[hw[0], hw[1]];

            var firstRow = Console.ReadLine().Split(' ').Select(int.Parse);
            var secondRow = Console.ReadLine().Split(' ').Select(int.Parse);
            cells[0, 0] = firstRow.ElementAt(0);
            cells[0, 1] = firstRow.ElementAt(1);
            cells[1, 0] = secondRow.ElementAt(0);
            cells[1, 1] = secondRow.ElementAt(1);
            CreateY(hw[0] - 1);
            CreateX(hw[1] - 1);
            CreateCells(hw[0] - 1, hw[1] - 1);
            for (int i = 0; i < hw[0]; i++)
            {
                var list = new List<string>();
                for (int j = 0; j < hw[1]; j++)
                {
                    list.Add(cells[i, j].ToString());
                    
                }
                Console.WriteLine(String.Join(" ", list));
            }
            Console.ReadLine();

        }

        public static int? CreateY(int i)
        {
            if (i == 1)
            {
                return cells[1, 0];
            }
            return cells[i, 0] = CreateY(i - 1) + (cells[1, 0] - cells[0, 0]);
        }
        public static int? CreateX(int j)
        {
            if (j == 1)
            {
                return cells[0, 1];
            }
            return cells[0, j] = CreateX(j - 1) + (cells[0, 1] - cells[0, 0]);
        }

        public static int? CreateCells(int i, int j)
        {
            if (cells[i, j] != null)
            {
                return cells[i, j];
            }
            int? a = CreateCells(i, j - 1) + (cells[0, 1] - cells[0, 0]);
            int? b = CreateCells(i - 1, j) + (cells[1, 0] - cells[0, 0]);

            return cells[i, j];
        }
    }
}
