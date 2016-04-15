// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ParenthesesDiv2Hard
{
    public Tuple<int, int> correct(string s, int l, int r)
    {
        var result = new List<int>();
        int opened = 0;
        for (int i = l; i <= r; ++i)
        {
            var c = s[i];
            if (opened == (r - l + 1) - i - l)
            {
                if (c == '(')
                {
                    result.Add(i);
                }
                opened--;
            }
            else if (c == '(')
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
        var openCount = 0;
        var closedCount = 0;
        foreach (var i in result)
        {
            if (s[i] == '(') openCount++;
            if (s[i] == ')') closedCount++;
        }
        return new Tuple<int, int>(openCount, closedCount);
    }

    public int minSwaps(string s, int[] L, int[] R)
    {
        var n = L.Length;
        var openCount = 0;
        var closedCount = 0;
        for (int i = 0; i < n; i++)
        {
            if ((R[i] - L[i]) % 2 == 0)
            {
                return -1;
            }
            else
            {
                var tuple = correct(s, L[i], R[i]);
                openCount += tuple.Item1;
                closedCount += tuple.Item2;
            }
        }

        if (openCount == closedCount)
        {
            return closedCount;
        }
        else
        {
            var openLeftOver = 0;
            var closedLeftOver = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var isLeft = true;
                for (int j = 0; j < n; j++)
                {
                    if (i >= L[j] && i <= R[j])
                    {
                        isLeft = false;
                        break;
                    }
                }
                if (isLeft)
                {
                    if (c == '(')
                        openLeftOver++;
                    else
                        closedLeftOver++;
                }
            }

            if (closedCount > openCount)
            {
                if (closedCount - openCount <= openLeftOver)
                    return closedCount;
            }

            if (closedCount < openCount)
            {
                if (openCount - closedCount <= closedLeftOver)
                    return openCount;
            }
        }
        return -1;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ParenthesesDiv2Hard()).minSwaps(")(", new int[] { 0 }, new int[] { 1 }), 1);
            eq(1, (new ParenthesesDiv2Hard()).minSwaps("(())", new int[] { 0, 2 }, new int[] { 1, 3 }), 1);
            eq(2, (new ParenthesesDiv2Hard()).minSwaps("(((())", new int[] { 0, 2 }, new int[] { 1, 3 }), 2);
            eq(3, (new ParenthesesDiv2Hard()).minSwaps("(((((((((", new int[] { 0, 2 }, new int[] { 1, 3 }), -1);
            eq(4, (new ParenthesesDiv2Hard()).minSwaps("))()())((()()()()()())))((((((", new int[] { 1, 6, 13, 17, 23, 25 }, new int[] { 4, 7, 16, 20, 24, 28 }), 5);
            eq(5, (new ParenthesesDiv2Hard()).minSwaps("(", new int[] { 0 }, new int[] { 0 }), -1);
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
