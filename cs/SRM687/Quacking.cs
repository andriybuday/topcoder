// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Quacking
{
    public int quack(string s)
    {
        if (s.Length % 5 != 0) return -1;
        var quack = "quack";
        int counter = 0;
        while(s.Length > 0)
        {
            var sbDuck = new StringBuilder();
            var sbOthers = new StringBuilder();
            var qPos = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] == quack[qPos])
                {
                    sbDuck.Append(s[i]);
                    qPos++;
                    if (qPos > 4) qPos = 0;
                }
                else
                {
                    sbOthers.Append(s[i]);
                }
            }
            var isDuck = sbDuck.ToString().Length % 5 == 0;
            if (!isDuck)
            {
                return -1;
            }
            s = sbOthers.ToString();
            counter++;
        }
        return counter;
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new Quacking()).quack("quqacukqauackck"),2);
            eq(1,(new Quacking()).quack("kcauq"),-1);
            eq(2,(new Quacking()).quack("quackquackquackquackquackquackquackquackquackquack"),1);
            eq(3,(new Quacking()).quack("qqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkk"),10);
            eq(4,(new Quacking()).quack("quqaquuacakcqckkuaquckqauckack"),3);
            eq(5,(new Quacking()).quack("quackqauckquack"),-1);
            eq(6, (new Quacking()).quack("qqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkkqqqqqqqqqquuuuuuuuuuaaaaaaaaaacccccccccckkkkkkkkkk"), 10);
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
