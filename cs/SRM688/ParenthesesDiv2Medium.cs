// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ParenthesesDiv2Medium
{
    public int[] correct(string s)
    {
        var result = new List<int>();
        int opened = 0;
        for (int i = 0; i < s.Length; ++i)
        {
            var c = s[i];
            if (opened == s.Length - i)
            {
                if (c == '(')
                {
                    result.Add(i);
                    
                }
                opened--;
            } else if (c == '(')
            {
                opened++;
            }
            else if (c == ')')
            {
                if (opened > 0)
                {
                    opened--;
                }
                else
                {
                    result.Add(i);
                    opened++;
                }
            }
        }

        return result.ToArray();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ParenthesesDiv2Medium()).correct(")("), new int[] { 0, 1 });
            eq(1, (new ParenthesesDiv2Medium()).correct(")))))((((("), new int[] { 0, 2, 4, 5, 7, 9 });
            eq(2, (new ParenthesesDiv2Medium()).correct("((()"), new int[] { 1 });
            eq(3, (new ParenthesesDiv2Medium()).correct(")))(()(())))))"), new int[] { 0, 1, 2 });
            eq(4, (new ParenthesesDiv2Medium()).correct("()()()()()()()()()()()()()"), new int[] { });
            eq(5, (new ParenthesesDiv2Medium()).correct("(((((((((((((((((((("), new int[] { });
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
