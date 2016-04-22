// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class MostProfitable
{
    public string bestItem(int[] costs, int[] prices, int[] sales, string[] items)
    {
        var length = costs.Length;
        var maxSales = Int32.MinValue;
        int maxSalesIndex = -1;
        for (int i = 0; i < length; i++)
        {
            var made = sales[i] * (prices[i] - costs[i]);
            if(made > maxSales)
            {
                maxSales = made;
                maxSalesIndex = i;
            }
        }
        if(maxSales > 0 && maxSalesIndex >= 0)
        {
            return items[maxSalesIndex];
        }
        return "";
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new MostProfitable()).bestItem(new int[] {100,120,150,1000}, new int[] {110,110,200,2000}, new int[] {20,100,50,3}, new string[] {"Video Card","256M Mem","CPU/Mobo combo","Complete machine"}),"Complete machine");
            eq(1,(new MostProfitable()).bestItem(new int[] {100}, new int[] {100}, new int[] {134}, new string[] {"Service, at cost"}),"");
            eq(2,(new MostProfitable()).bestItem(new int[] {38,24}, new int[] {37,23}, new int[] {1000,643}, new string[] {"Letter","Postcard"}),"");
            eq(3,(new MostProfitable()).bestItem(new int[] {10,10}, new int[] {11,12}, new int[] {2,1}, new string[] {"A","B"}),"A");
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
