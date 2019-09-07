using System;

public class Algorithm
{
    public static int Lcm(int a, int b) => a * b / Gcd(a, b);
    public static int Gcd(int a, int b)
    {
        if (a < b) { Gcd(b, a); }
        int tmp = 0;
        do
        {
            tmp = a % b;
            a = b;
            b = tmp;
        } while (tmp != 0);
        return a;
    }
    public static IEnumerable<int> GetDivisors(int num)
    {
        yield return 1;
        yield return num;
        for (int i = 2; i <= Pow(num, 0.5); i++)
        {
            if (num % i == 0)
            {
                yield return i;
                int div = num / i;
                if (i != div) { yield return div; }
            }
        }
    }
}
