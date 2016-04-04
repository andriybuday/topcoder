using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class MNS
{

    public bool IsMagicMatrix(int[] a)
    {
        var r1 = a[0] + a[1] + a[2];
        var r2 = a[3] + a[4] + a[5];
        var r3 = a[6] + a[7] + a[8];
        var c1 = a[0] + a[3] + a[6];
        var c2 = a[1] + a[4] + a[7];
        var c3 = a[2] + a[5] + a[8];
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
            numCounter[n]++;
        int div = 1;
        foreach (var nc in numCounter)
        {
            div *= Factorial(nc);
        }
        var numbersCopy = numbers.ToArray();
        int counter = IsMagicMatrix(numbers) ? 1 : 0;
        int numPerm = Factorial(9);
        //for each permutation
        //{
            if (IsMagicMatrix(permutation.ToArray()))
            {
                counter++;
            }
        //}
        return counter / div;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
