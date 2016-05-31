// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Sunnygraphs2
{
    public long count(int[] a)
    {
        var n = a.Length;
        long result = 1L << n;
        var done = new bool[n];
        var components = 0;

        for (int i = 0; i < n; i++)
        {
            var x = i;
            for (int j = 0; j < n; j++)
                x = a[x];

            var incl = 0;
            for (int j = 0; j < n; j++)
            {
                x = a[x];
                if (!done[x])
                {
                    done[x] = true;
                    incl++;
                }
            }
            if (incl > 0)
            {
                result >>= incl;
                result *= (1L << incl) - 1;
                components++;
            }
        }

        return components == 1 ? result + 1 : result;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new Sunnygraphs2()).count(new int[] { 1, 0 }), 4L);
            eq(1, (new Sunnygraphs2()).count(new int[] { 1, 0, 0 }), 7L);
            eq(2, (new Sunnygraphs2()).count(new int[] { 2, 3, 0, 1 }), 9L);
            eq(3, (new Sunnygraphs2()).count(new int[] { 2, 3, 0, 1, 0 }), 18L);
            eq(4, (new Sunnygraphs2()).count(new int[] { 2, 3, 0, 1, 0, 4, 5, 2, 3 }), 288L);
            eq(5, (new Sunnygraphs2()).count(new int[] { 29, 34, 40, 17, 16, 12, 0, 40, 20, 35, 5, 13, 27, 7, 29, 13, 14, 39, 42, 9, 30, 38, 27, 40, 34, 33, 42, 20, 29, 42, 12, 29, 30, 21, 4, 5, 7, 25, 24, 17, 39, 32, 9 }), 6184752906240L);
            eq(6, (new Sunnygraphs2()).count(new int[] { 9, 2, 0, 43, 12, 14, 39, 25, 24, 3, 16, 17, 22, 0, 6, 21, 18, 29, 34, 35, 23, 43, 28, 28, 20, 11, 5, 12, 31, 24, 8, 13, 17, 10, 15, 9, 15, 26, 4, 13, 21, 27, 36, 39 }), 17317308137473L);
        }
        catch (Exception ex)
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
