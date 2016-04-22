// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class ProblemWriting
{
    private const string NOT_DOT_FORMAT = "dotForm is not in dot notation, check character {0}.";
    private char[] allowed = new[] { '.', '+', '-', '*', '/' };
    private enum States
    {
        S0 = 0,
        S1,
        S2,
        S3
    }
    private bool isAllowed(char c)
    {
        return char.IsDigit(c) || allowed.Contains(c);
    }
    public string myCheckData(string dotForm)
    {
        if (dotForm.Length > 25)
            return "dotForm must contain between 1 and 25 characters, inclusive.";
        var good = true;
        var STATE = States.S0;
        for (int i = 0; i < dotForm.Length; i++)
        {
            char curr = dotForm[i];
            good = true;
            if (STATE == States.S0)
            {
                if (char.IsDigit(curr)) STATE = States.S1;
                else good = false;
            }
            else if (STATE == States.S1 || STATE == States.S2)
            {
                if (curr == '.') STATE = States.S2;
                else if (allowed.Contains(curr)) STATE = States.S3;
                else good = false;
            }
            else if (STATE == States.S3)
            {
                if (curr == '.') STATE = States.S3;
                else if (char.IsDigit(curr)) STATE = States.S1;
                else good = false;
            }
            if (!good) return string.Format(NOT_DOT_FORMAT, i);
        }
        if (STATE != States.S1) return string.Format(NOT_DOT_FORMAT, dotForm.Length);
        return "";
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ProblemWriting()).myCheckData("3+5"), "");
            eq(1, (new ProblemWriting()).myCheckData("9..+.5...*....3"), "");
            eq(2, (new ProblemWriting()).myCheckData("5.3+4"), "dotForm is not in dot notation, check character 2.");
            eq(3, (new ProblemWriting()).myCheckData("9*9*9*9*9*9*9*9*9*9*9*9*9*9"), "dotForm must contain between 1 and 25 characters, inclusive.");
            eq(4, (new ProblemWriting()).myCheckData("3.........../...........4"), "");
            eq(5, (new ProblemWriting()).myCheckData("9.....*8..+.3./."), "dotForm is not in dot notation, check character 16.");
            eq(6, (new ProblemWriting()).myCheckData("12"), "dotForm is not in dot notation, check character 1.");
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
