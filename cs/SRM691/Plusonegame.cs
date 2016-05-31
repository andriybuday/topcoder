// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Plusonegame
{
    public string getorder(string s)
    {
        var digits = s.Where(c => c != '+').Select(c => c - '0').OrderBy(d => d).ToArray();
        var p = s.Length - digits.Length;
        var curr = 0;
        var sb = new StringBuilder();
        foreach (var digit in digits)
        {
            while (curr < digit && p > 0)
            {
                sb.Append('+');
                curr++;
                p--;
            }
            sb.Append(digit);
        }
        while (p > 0)
        {
            sb.Append('+');
            p--;
        }
        return sb.ToString();
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new Plusonegame()).getorder("1++"), "+1+");
            eq(1, (new Plusonegame()).getorder("549"), "459");
            eq(2, (new Plusonegame()).getorder("++++++"), "++++++");
            eq(3, (new Plusonegame()).getorder("+++++2+"), "++2++++");
            eq(4, (new Plusonegame()).getorder("++++4++++200++2++1+6++++++"), "00+1+22++4++6+++++++++++++");
            eq(5, (new Plusonegame()).getorder("++11199999"), "+111+99999");
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
