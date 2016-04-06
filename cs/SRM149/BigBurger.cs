using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class BigBurger
{
    public int maxWait(int[] arrival, int[] service)
    {
        var burgerPos = arrival[0];
        var max = Int32.MinValue;
        for (int i = 0; i < arrival.Length; i++)
        {
            var current = 0;
            if (arrival[i] > burgerPos)
                burgerPos = arrival[i];
            else
                current = burgerPos - arrival[i];
            if (max < current)
                max = current;
            burgerPos += service[i];
        }
        return max;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
