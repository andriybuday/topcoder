// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class UpDownHiking
{
    public int maxHeight(int N, int A, int B)
    {
        var max = 0;
        for (int i = 1; i <= N; i++)
        {
            for (int a = 1; a <= A; a++)
            {
                for (int b = 1; b <= B; b++)
                {
                    var aSum = i * a;
                    var bSum = (N - i) * b;

                    if (aSum - bSum <= 0)
                    {
                        if (max <= aSum) max = aSum;
                    }
                    if (bSum - aSum <= 0)
                    {
                        if (max <= bSum) max = bSum;
                    }
                }
            }
        }
        return max;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new UpDownHiking()).maxHeight(3, 7, 10),10);
            eq(1,(new UpDownHiking()).maxHeight(5, 40, 30),80);
            eq(2,(new UpDownHiking()).maxHeight(2, 50, 1),1);
            eq(3,(new UpDownHiking()).maxHeight(3, 42, 42),42);
            eq(4,(new UpDownHiking()).maxHeight(20, 7, 9),77);
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
