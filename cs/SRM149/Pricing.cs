// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Pricing
{
    public int maxSales(int[] price)
    {
        Array.Sort(price);
        Array.Reverse(price);
        int len = price.Length;
        int max = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                for (int k = j; k < len; k++)
                {
                    for (int m = k; m < len; m++)
                    {
                        int sum = 0;
                        for (int n = 0; n < len; n++)
                        {
                            if (price[n] >= price[i])
                                sum += price[i];
                            else if (price[n] >= price[j])
                                sum += price[j];
                            else if (price[n] >= price[k])
                                sum += price[k];
                            else if (price[n] >= price[m])
                                sum += price[m];
                        }
                        if (max < sum) max = sum;
                    }
                }
            }
        }
        return max;
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new Pricing()).maxSales(new int[] {9,1,5,5,5,5,4,8,80}),120);
            eq(1,(new Pricing()).maxSales(new int[] {17,50,2}),69);
            eq(2,(new Pricing()).maxSales(new int[] {130,110,90,13,6,5,4,3,0}),346);
        } 
        catch(Exception ex)
        {
            System.Console.WriteLine(ex);
            System.Console.WriteLine(ex.StackTrace);
        }
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
// END CUT HERE
}
