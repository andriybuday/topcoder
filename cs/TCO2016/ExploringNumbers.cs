// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;

public class ExploringNumbers
{
    public int numberOfSteps(int n)
    {
        Int64 current = n;
        for (var i = 1; i <= n; i++)
        {
            if (IsPrime(current)) return i;
            current = GetSum(current);
            if (current == 1) return -1;
        }
        return -1;
    }

    private Int64 GetSum(Int64 n)
    {
        Int64 sum = 0;
        while (n > 0)
        {
            var r = n%10;
            sum += r*r;
            n /= 10;
        }
        return sum;
    }

    public static bool IsPrime(Int64 n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return (n == 2);
        var sqrt = (Int64)Math.Sqrt((double)n);
        for (Int64 i = 3; i <= sqrt; i += 2)
            if (n % i == 0) return false;
        return true;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            // Test for timeout
            //for (int i = 1; i <= 1000000000; i*=10)
            //{
            //    var sw = new Stopwatch();
            //    sw.Start();
            //    (new ExploringNumbers()).numberOfSteps(i);
            //    sw.Stop();
            //    if (sw.ElapsedMilliseconds > 2000)
            //    {
            //        i++;
            //    }
            //}

            eq(0, (new ExploringNumbers()).numberOfSteps(5), 1);
            eq(1, (new ExploringNumbers()).numberOfSteps(57), 4);
            eq(2, (new ExploringNumbers()).numberOfSteps(1), -1);
            eq(3, (new ExploringNumbers()).numberOfSteps(6498501), 2);
            eq(4, (new ExploringNumbers()).numberOfSteps(989113), 6);
            eq(5, (new ExploringNumbers()).numberOfSteps(12366), -1);
            eq(6, (new ExploringNumbers()).numberOfSteps(100000000), -1);
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
