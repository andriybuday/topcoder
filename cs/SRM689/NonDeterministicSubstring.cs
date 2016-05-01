// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class NonDeterministicSubstring
{
    public long ways(string A, string B)
    {
        if (B.Length > A.Length) return 0;

        int subLen = B.Length;
        var hash = new HashSet<string>();
        for (int i = 0; i <= A.Length - subLen; i++)
        {
            if(Test(A, i, B))
            {
                hash.Add(A.Substring(i, subLen));
            }
        }
        return (long)hash.Count;
    }

    private bool Test(string a, int i, string b)
    {
        for (int j = 0; j < b.Length; j++)
        {
            if(b[j] != '?' && b[j] != a[j + i])
            {
                return false;
            }
        }
        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new NonDeterministicSubstring()).ways("00010001", "??"),3L);
            eq(1,(new NonDeterministicSubstring()).ways("00000000", "??0??0"),1L);
            eq(2,(new NonDeterministicSubstring()).ways("001010101100010111010", "???"),8L);
            eq(3,(new NonDeterministicSubstring()).ways("00101", "??????"),0L);
            eq(4,(new NonDeterministicSubstring()).ways("1101010101111010101011111111110001010101", "???????????????????????????????????"),6L);
            eq(5, (new NonDeterministicSubstring()).ways("11010101011110101010111111111100010101011101010101111010101011111111110001010101", "?????????????1?0????"), 6L);
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
