using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MNS
{
    //Members of vals must be distinct
    //Based on C++ next_permutation function
    public bool NextPermutation(int[] vals)
    {
        int i = vals.Length - 1;
        while (true)
        {
            int ii = i;
            i--;
            if (vals[i] < vals[ii])
            {
                int j = vals.Length;
                while (vals[i] >= vals[--j]) ;
                int temp = vals[i];  //Swap
                vals[i] = vals[j];
                vals[j] = temp;
                int begin = ii, end = vals.Length - 1;
                while (end > begin)
                {
                    int stemp = vals[end];   //Swap
                    vals[end] = vals[begin];
                    vals[begin] = stemp;
                    end--; begin++;
                }
                return true;
            }
            else if (vals[i] == vals[0])
            {
                int begin = 0, end = vals.Length - 1;
                while (end > begin)
                {
                    int stemp = vals[end];   //Swap
                    vals[end] = vals[begin];
                    vals[begin] = stemp;
                    end--; begin++;
                }
                return false;
            }
        }
    }

    public bool IsMagicMatrix(int[] a, int[] i)
    {
        var r1 = a[i[0]] + a[i[1]] + a[i[2]];
        var r2 = a[i[3]] + a[i[4]] + a[i[5]];
        var r3 = a[i[6]] + a[i[7]] + a[i[8]];
        var c1 = a[i[0]] + a[i[3]] + a[i[6]];
        var c2 = a[i[1]] + a[i[4]] + a[i[7]];
        var c3 = a[i[2]] + a[i[5]] + a[i[8]];
        return (r1 == r2 && r2 == r3 && r3 == c1 && c1 == c2 && c2 == c3);
    }

    public int Factorial(int n)
    {
        if (n == 0) return 1;
        int m = 1;
        for (int i = 1; i <= n; i++)
        {
            m *= i;
        }
        return m;
    }

    public int combos(int[] numbers)
    {
        var numCounter = new int[10];
        foreach (var n in numbers)
        {
            numCounter[n]++;
        }
        int div = 1;
        foreach (var nc in numCounter)
        {
            div *= Factorial(nc);
        }
        int[] permIndexes = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
        int counter = IsMagicMatrix(numbers, permIndexes) ? 1 : 0;
        while (NextPermutation(permIndexes))
        {
            if (IsMagicMatrix(numbers, permIndexes))
            {
                counter++;
            }
        }
        return counter / div;
    }
}