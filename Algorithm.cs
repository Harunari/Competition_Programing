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
}
