// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class SuperRot
{
    private char ConvertLetter(char c)
    {
        if (c == ' ') return ' ';
        if (char.IsDigit(c))
        {
            if (c < '5') return (char)(c + 5);
            else return (char)(c - 5);
        }
        else if (char.IsUpper(c))
        {
            if (c < 'N') return (char)(c + 13);
            else return (char)(c - 13);
        }
        else
        {
            if (c < 'n') return (char)(c + 13);
            else return (char)(c - 13);
        }
    }

    public string decoder(string message)
    {
        var sb = new StringBuilder();
        foreach (var c in message)
        {
            sb.Append(ConvertLetter(c));
        }
        return sb.ToString();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new SuperRot()).decoder("Uryyb 28"), "Hello 73");
            eq(1, (new SuperRot()).decoder("GbcPbqre"), "TopCoder");
            eq(2, (new SuperRot()).decoder(""), "");
            eq(3, (new SuperRot()).decoder("5678901234"), "0123456789");
            eq(4, (new SuperRot()).decoder("NnOoPpQqRr AaBbCcDdEe"), "AaBbCcDdEe NnOoPpQqRr");
            eq(5, (new SuperRot()).decoder("Gvzr vf 54 71 CZ ba Whyl 4gu bs gur lrne 7558 NQ"), "Time is 09 26 PM on July 9th of the year 2003 AD");
            eq(6, (new SuperRot()).decoder("Gur dhvpx oebja sbk whzcf bire n ynml qbt"), "The quick brown fox jumps over a lazy dog");
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
