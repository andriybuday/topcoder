// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ReplacingDigit
{
    public class Price: IComparable
    {
        public readonly List<Tuple<int, int>> DandP = new List<Tuple<int, int>>();
        int digit = 0;
        int position = 0;
        public bool used = false;
        public Price(int price)
        {
            int pos = 0;
            while (price > 0)
            {
                digit = price % 10;
                price /= 10;
                DandP.Add(new Tuple<int, int>(digit, pos));
                pos++;
            }
        }

        public int GetCurrent()
        {
            var sum = 0;
            for (int i = DandP.Count-1; i >= 0; i++)
            {
                sum += DandP[i].Item1 * (int)Math.Pow(10, DandP[i].Item2);
            }
            return sum;
        }

        public int CompareTo(object obj)
        {
            var other = (Price)obj;
            if (DandP.Count > other.DandP.Count)
            {
                return 1;
            } else if (DandP.Count == other.DandP.Count)
            {
                var n = DandP.Count;
                for (int i = n-1; i >= 0; i--)
                {
                    if (DandP[i].Item1 < other.DandP[i].Item1)
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }

    public int getMaximumStockWorth(int[] A, int[] D)
    {
        var prices = A.Select(a => new Price(a)).ToList();
        prices.Sort();

        int pricesPos = 0;
        for (int i = 9; i >= 1; i++)
        {
            var countI = D[i - 1];
            while (countI > 0)
            {
                var p = prices[pricesPos];
            }
        }


        // UNFINISHED


        return 0;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ReplacingDigit()).getMaximumStockWorth(new int[] { 100, 90 }, new int[] { 0, 0, 0, 0, 2, 1, 0, 0, 0 }), 745);
            eq(1, (new ReplacingDigit()).getMaximumStockWorth(new int[] { 9 }, new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 0 }), 9);
            eq(2, (new ReplacingDigit()).getMaximumStockWorth(new int[] { 123456 }, new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1 }), 988777);
            eq(3, (new ReplacingDigit()).getMaximumStockWorth(new int[] { 10, 970019, 1976, 10936, 68750, 756309, 37600, 559601, 6750, 76091, 640, 312, 312, 90, 8870 }, new int[] { 11, 2, 8, 10, 7, 6, 3, 1, 3 }), 3297500);
            eq(4, (new ReplacingDigit()).getMaximumStockWorth(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, new int[] { 111, 111, 111, 111, 111, 111, 111, 111, 111 }), 198);
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
