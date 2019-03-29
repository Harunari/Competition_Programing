using System;
using System.Linq;

namespace Hash
{
    public class Program
    {
        const int NIL = -1;
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var array = Enumerable.Repeat(NIL, 1046527).ToArray();

            while (0 == n)
            {
                var inputStr = Console.ReadLine();
                if (inputStr[0] == 'i')
                {
                    var str = inputStr.Substring(7);
                    Insert(array, GetKey(str));
                }
                else
                {
                    var str = inputStr.Substring(5);
                    if (Search(array, GetKey(str)))
                    {
                        Console.WriteLine("yes");
                    }
                    else
                    {
                        Console.WriteLine("no");
                    }
                };
                n--;
            }
        }

        public static int GetChar(char c)
        {
            if (c == 'A')
            {
                return 1;
            }
            else if (c == 'C')
            {
                return 2;
            }
            else if (c == 'G')
            {
                return 3;
            }
            else if (c == 'T')
            {
                return 4;
            }
            return 0;
        }

        public static int GetKey(string str)
        {
            int sum = 0, p = 1;
            for (int i = 0; i < str.Length; i++)
            {
                sum += p * (GetChar(str[i]));
                // 行48の4 < 5
                p *= 5;
            }
            return sum;
        }

        public static int H1(int key, int listSize)
        {
            if (key < 0 || listSize <= 0)
            {
                throw new ArgumentException();
            }
            return key % listSize;
        }

        public static int H2(int key, int listSize)
        {
            if (key < 0 || listSize <= 0)
            {
                throw new ArgumentException();
            }
            return 1 + key % (listSize - 1);
        }

        public static int H(int key, int listSize, int index)
        {
            if (key < 0 || listSize <= 0 || index < 0)
            {
                throw new ArgumentException();
            }
            return (H1(key, listSize) + index * H2(key, listSize)) % listSize;
        }

        public static bool Insert(int[] array, int key)
        {
            if (key < 0 || array.Length < 1)
            {
                throw new ArgumentException();
            }
            int i = 0;
            int listSize = array.Length;

            while (true)
            {
                int hash = H(key, listSize, i);
                if (array[hash] == NIL)
                {
                    array[hash] = key;
                    return true;
                }
                i++;
            }
        }

        public static bool Search(int[] array, int key)
        {
            if (key < 0 || array.Length < 1)
            {
                throw new ArgumentException();
            }
            int i = 0;
            int listSize = array.Length;

            while (true)
            {
                int hash = H(key, listSize, i);
                if (array[hash] == key)
                {
                    return true;
                }
                else if (array[hash] == NIL || i > listSize)
                {
                    return false;
                }
                i++;
            }
        }
    }
}
