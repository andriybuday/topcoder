// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ColorfulGardenHard
{
    public int Factorial(int n)
    {
        if (n == 0) return 1;
        int m = 1;
        for (int i = 1; i <= n; i++)
        {
            m *= i;
            m = m % 1000000007;
        }
        return m;
    }

    public int count(string garden, string forbid)
    {
        var gd = garden.ToCharArray().Distinct().ToList();
        var fd = forbid.ToCharArray().Distinct().ToList();
        var unique = gd.Select(c => !fd.Contains(c)).ToList();

        var counter = Factorial(unique.Count);

        return counter;
    }

    private bool IsOk(string garden, string forbid, int[] permIndexes)
    {
        var prev = '#';
        for (int i = 0; i < garden.Length; i++)
        {
            var curr = garden[permIndexes[i]];
            if (curr == forbid[i] || prev == curr) return false;
            prev = curr;
        }
        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new ColorfulGardenHard()).count("aaabbb", "cccccc"),2);
            eq(1,(new ColorfulGardenHard()).count("aabbcc", "aabbcc"),5);
            eq(2,(new ColorfulGardenHard()).count("aaaabb", "xxxxxx"),0);
            eq(3,(new ColorfulGardenHard()).count("abcdefghijklmno", "zzzzzzzzzzzzzzz"),674358851);
            eq(4,(new ColorfulGardenHard()).count("a", "b"),1);
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
