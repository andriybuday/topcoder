using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

public class WidgetRepairs
{
    public int days(int[] arrivals, int numPerDay)
    {
        int days = 0;
        int overleft = 0;
        for (int i = 0; i < arrivals.Length; ++i)
        {
            if (overleft > 0 || arrivals[i] > 0) ++days;
            overleft = arrivals[i] + overleft - numPerDay;
            if (overleft <= 0) overleft = 0;
        }

        while (overleft > 0)
        {
            overleft -= numPerDay;
            ++days;
        }

        return days;
    }


}
//Powered by [KawigiEdit] 2.0!
