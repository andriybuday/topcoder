// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SimilarUserDetection
{
    public string haveSimilar(string[] handles)
    {
        var distinct = new List<string>();
        for (int i = 0; i < handles.Length; i++)
        {
            var x = handles[i].Replace('O', '0').Replace('I', '1').Replace('l', '1');
            distinct.Add(x);
        }
        return distinct.Distinct().Count() != handles.Length ?
            "Similar handles found" :
            "Similar handles not found";
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new SimilarUserDetection()).haveSimilar(new string[] {"top", "coder", "TOPCODER", "TOPC0DER"}),"Similar handles found");
            eq(1,(new SimilarUserDetection()).haveSimilar(new string[] {"Topcoder", "topcoder", "t0pcoder", "topcOder"}),"Similar handles not found");
            eq(2,(new SimilarUserDetection()).haveSimilar(new string[] {"same", "same", "same", "different"}),"Similar handles found");
            eq(3,(new SimilarUserDetection()).haveSimilar(new string[] {"0123", "0I23", "0l23", "O123", "OI23", "Ol23"}),"Similar handles found");
            eq(4,(new SimilarUserDetection()).haveSimilar(new string[] {"i23", "123", "456", "789", "000", "o", "O"}),"Similar handles not found");
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
