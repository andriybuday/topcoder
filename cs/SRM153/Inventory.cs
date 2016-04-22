// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Inventory
{
    public int monthlyOrder(int[] sales, int[] daysAvailable)
    {
        int n = sales.Length;
        var sum = 0.0;
        int c = 0;
        for (int i = 0; i < n; i++)
        {
            if (sales[i] == 0 && daysAvailable[i] == 0) continue;

            var wouldHaveSold = sales[i] * 30.0 / (double) daysAvailable[i];
            sum += wouldHaveSold;
            c++;
        }
        sum /= c;
        sum -= Math.Pow(0.1, 9);
        sum = Math.Ceiling(sum);
        return (int)sum;
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new Inventory()).monthlyOrder(new int[] {5}, new int[] {15}),10);
            eq(1,(new Inventory()).monthlyOrder(new int[] {75,120,0,93}, new int[] {24,30,0,30}),103);
            eq(2,(new Inventory()).monthlyOrder(new int[] {8773}, new int[] {16}),16450);
            eq(3,(new Inventory()).monthlyOrder(new int[] {1115,7264,3206,6868,7301}
               , new int[] {1,3,9,4,18}),36091);
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
