// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Queueing
{
    public double probFirst(int len1, int len2, int p1, int p2)
    {
        var x1 = Prob(p1, len1);
        var x2 = Prob(p2, len2);
        var x = (1.0 - x1) * x2;
        var y = 1 - x;
        var sum = 0.0;
        int n = 100;
        for (int k = 1; k < n; k++)
        {
            var prob1 = Prob(p1, k);
            var prob2 = Prob(p2, k);
            var probLine1 = Math.Pow(prob1, len1);
            var probLine2 = Math.Pow(prob2, len2);
            sum += (1.0 - probLine2) * probLine1;
            //sum += probLine1 / probLine2;
        }
        return sum;
    }
    public double Prob(double p, double k)
    {
        if (p == 0 || k == 0) return 1;
        return (1 / p) * Math.Pow(1.0 - 1 / p, k - 1);
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            //eq(0,(new Queueing()).probFirst(1, 2, 2, 1),0.5);
            eq(1,(new Queueing()).probFirst(1, 3, 3, 7),0.9835390946502058);
            //eq(2,(new Queueing()).probFirst(3, 1, 7, 3),0.010973936899862834);
            //eq(3,(new Queueing()).probFirst(12, 34, 56, 78),0.999996203228025);
            //eq(4,(new Queueing()).probFirst(3, 6, 8, 4),0.5229465300297028);
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
