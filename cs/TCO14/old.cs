using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCO14
{
    public class GameOfSegments
    {
        public int winner(int N)
        {
            var outcomes = new int[N + 1];
            for (int i = 0; i <= N; i++)
            {
                var possibilities = new List<int>();
                for (int j = 0; j <= i - 2; j++)
                {
                    var xor = outcomes[j] ^ outcomes[i - 2 - j];
                    possibilities.Add(xor);
                }
                var minNotInPos = 0;
                while (possibilities.Contains(minNotInPos))
                {
                    minNotInPos++;
                }
                outcomes[i] = minNotInPos;
            }
            return outcomes[N] > 0 ? 1 : 2;
        }

    }

    public class WolvesAndSheep
    {
        public int getmin(string[] field)
        {
            var l_rows = field.Length;
            var l_cols = field[0].Length;
            var r = new bool[l_rows + 1];
            var c = new bool[l_cols + 1];
            for (int i = 1; i < l_rows + 1; i++)
            {
                r[i] = true;
            }
            for (int i = 1; i < l_cols + 1; i++)
            {
                c[i] = true;
            }

            var min = int.MaxValue;
            for (int i = 1; i < l_rows; i++)
            {
                for (int j = 1; j < l_cols; j++)
                {
                    r[i] = false;
                    int currentMin = runTest(field, r, c);
                    if (currentMin == -1)
                        r[i] = true;
                    else if (currentMin < min)
                        min = currentMin;

                    c[j] = false;
                    currentMin = runTest(field, r, c);
                    if (currentMin == -1)
                    {
                        c[j] = true;
                    }
                    else if (currentMin < min)
                        min = currentMin;

                }
            }
            return min;
        }

        private int runTest(string[] field, bool[] r, bool[] c)
        {
            int count = 0;
            var rows = new List<int>();
            var cols = new List<int>();
            for (int i = 0; i < field.Length + 1; i++)
            {
                if (r[i])
                {
                    count++;
                    rows.Add(i);
                }
            }
            for (int i = 0; i < field[0].Length + 1; i++)
            {
                if (c[i])
                {
                    count++;
                    cols.Add(i);
                }
            }
            if (isSafe(field, rows, cols))
            {
                return count - 2;
            }
            return -1;
        }

        private bool isSafe(string[] field, List<int> rows, List<int> cols)
        {
            int l_rows = field.Length;
            int l_cols = field[0].Length;
            foreach (var row in field)
            {
                int start = 0;
                for (int i = 0; i < cols.Count; i++)
                {
                    bool? S = null;
                    for (int j = start; j < cols[i]; j++)
                    {
                        bool? tmpS = getState(row[j]);
                        if (tmpS.HasValue && !S.HasValue) S = tmpS;
                        else if (tmpS.HasValue && S.HasValue)
                        {
                            if (tmpS.Value != S.Value) return false;
                        }

                    }
                    start = cols[i];
                }
            }

            for (int column = 0; column < l_cols; column++)
            {
                int start = 0;
                for (int i = 0; i < rows.Count; i++)
                {
                    bool? S = null;
                    for (int j = start; j < rows[i]; j++)
                    {
                        bool? tmpS = getState(field[j][column]);
                        if (tmpS.HasValue && !S.HasValue) S = tmpS;
                        else if (tmpS.HasValue && S.HasValue)
                        {
                            if (tmpS.Value != S.Value) return false;
                        }

                    }
                    start = rows[i];
                }
            }
            return true;
        }

        private static bool? getState(char value)
        {
            return value == 'S' ? true : (value == 'W' ? false : (bool?)null);
        }
    }


    //public class Aaaaaaaaaaaaa
    //{
    //    public string getMin(string letters, int maxDistance)
    //    {
    //        char[] original = letters.ToCharArray();
    //        int L = maxDistance + 1;
    //        int length = letters.Length;
    //        string[] cases = new string[L];

    //        var newArray = new char[length];
    //        var movements = new int[length];
    //        Array.Copy(original, newArray, length);
    //        int start = 0;
    //        while (start < length)
    //        {
    //            var toSort = new char[L];
    //            int lToSort = (start + L < length) ? L : length - start;
    //            Array.Copy(newArray, start, toSort, 0, lToSort);
    //            Array.Sort(toSort);
    //            for (int i = 0; i < lToSort; i++)
    //            {

    //            }
    //            var toLeave = toSort[0];
    //            var pos = Array.FindIndex(newArray, start, (x) => x == toLeave);

    //            if (pos > 0)
    //                swap(newArray, movements, start, pos);
    //            start++;
    //            Console.WriteLine(new string(newArray));
    //        }
    //        //Array.Sort(cases);

    //        return new string(newArray);
    //    }

    //    private void swap(char[] newArray, int[] m, int a, int b)
    //    {
    //        char t = newArray[a];
    //        m[]
    //        newArray[a] = newArray[b];
    //        newArray[b] = t;
    //    }

    //    //public string getMin(string letters, int maxDistance)
    //    //{
    //    //    char[] original = letters.ToCharArray();
    //    //    int L = maxDistance + 1;
    //    //    int length = letters.Length;
    //    //    string[] cases = new string[L];
    //    //    for (int i = 0; i < L; i++)
    //    //    {
    //    //        var newArray = new char[length];
    //    //        Array.Copy(original, newArray, length);
    //    //        int start = i;
    //    //        Array.Sort(newArray, 0, start);
    //    //        while (start < length)
    //    //        {
    //    //            int lToSort = (start + L < length) ? L : length - start;
    //    //            Array.Sort(newArray, start, lToSort);
    //    //            start += L;
    //    //        }
    //    //        cases[i] = new string(newArray);
    //    //    }

    //    //    Array.Sort(cases);

    //    //    return cases[0];
    //    //}

    //    public string getMin2(string S, int L)
    //    {
    //        char[] c = S.ToCharArray();
    //        Array.Sort(c, c.Length - L, L);
    //        while (c.Length > L)
    //        {
    //            Array.Sort(c, c.Length - L - 1, L);
    //            var newC = new char[c.Length - 1];
    //            Array.Copy(c, newC, c.Length - 1);
    //            c = newC;
    //        }
    //        return new string(c);
    //    }
    //}

    //public class Unique
    //{
    //    public string removeDuplicates(string S)
    //    {
    //        var sb = new StringBuilder();
    //        var a = new bool[30];
    //        foreach (var s in S)
    //        {
    //            if (!a[s - 'a'])
    //            {
    //                sb.Append(s);
    //                a[s - 'a'] = true;
    //            }
    //        }
    //        return sb.ToString();
    //    }

    //}

    //public class FizzBuzzTurbo
    //{
    //    public long[] counts(long A, long B)
    //    {
    //        var start3 = A;
    //        var end3 = B;
    //        var start5 = A;
    //        var end5 = B;
    //        var start15 = A;
    //        var end15 = B;

    //        for (long i = 0; i < 15; i++)
    //        {
    //            if (start3 % 3 != 0 && start3 < B) start3++;
    //            if (start5 % 5 != 0 && start5 < B) start5++;
    //            if (start15 % 15 != 0 && start15 < B) start15++;
    //            if (end3 % 3 != 0 && end3 > A) end3--;
    //            if (end5 % 5 != 0 && end5 > A) end5--;
    //            if (end15 % 15 != 0 && end15 > A) end15--;
    //        }
    //        long Z = (end15 - start15 >= 0) ? (end15 - start15) / 15 + 1 : 0;
    //        long X = (end3 - start3 >= 0) ? (end3 - start3) / 3 + 1 : 0;
    //        long Y = (end5 - start5 >= 0) ? (end5 - start5) / 5 + 1 : 0;
    //        //if (X < 0) X = 0;
    //        //if (Y < 0) Y = 0;
    //        //if (Z < 0) Z = 0;
    //        X -= Z;
    //        Y -= Z;

    //        return new long[] { X, Y, Z };
    //    }
    //}


    //public class FibonacciDiv2
    //{
    //    public int find(int N)
    //    {
    //        if (N < 4) return 0;
    //        var f = new List<int>() { 0, 1, 1 };
    //        var x = 1;
    //        var xp = 1;
    //        while (x <= 1000000)
    //        {
    //            xp = f[f.Count - 2] + f[f.Count - 3];
    //            x = f[f.Count - 1] + f[f.Count - 2];
    //            if (xp <= N && x >= N)
    //            {
    //                return Math.Min(N - xp, x - N);
    //            }
    //            f.Add(x);
    //        }
    //        return 0;
    //    }
    //}
    //public class BoxesDiv2
    //{
    //    public int getNext(int x)
    //    {
    //        var pow = 1;
    //        while (pow < x)
    //        {
    //            pow *= 2;
    //        }
    //        return pow;
    //    }
    //    public int findSize(int[] candyCounts)
    //    {
    //        var c = new List<int>(candyCounts);
    //        c.Sort();
    //        for (int i = 0; i < c.Count; i++)
    //            c[i] = getNext(c[i]);

    //        while (c.Count > 1)
    //        {
    //            c[1] = getNext(c[0] + c[1]);
    //            c.RemoveAt(0);
    //            c.Sort();
    //        }
    //        return c[0];
    //    }
    //}

    /*
     *     public class CatchTheBeatEasy
    {
        struct pair : IComparable
        {
            public int x;
            public int y;

            public pair(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int CompareTo(object obj)
            {
                return y.CompareTo(((pair)obj).y);
            }
        }
        public string ableToCatchAll(int[] x, int[] y)
        {
            var tuples = new List<pair>();
            for (int i = 0; i < x.Length; i++)
            {
                tuples.Add(new pair(x[i], y[i]));
            }
            tuples.Sort();
            int p = 0;
            int t = 0;
            for (int i = 0; i < tuples.Count; i++)
            {
                if (Math.Abs(p - tuples[i].x) > tuples[i].y - t)
                    return "Not able to catch";
                p = tuples[i].x;
                t = tuples[i].y;
            }
            return "Able to catch";
        }

    }

    public class CatAndRat
    {

        public double getTime(int R, int T, int Vrat, int Vcat)
        {
            var d = T*Vrat <= Math.PI*R ? T*Vrat : Math.PI*R;
            if (Vcat - Vrat == 0)
                return -1;
            var t = (double)d / (double) (Vcat - Vrat);
            if (t > 0) return t;
            return -1;
        }

    }*/

}
