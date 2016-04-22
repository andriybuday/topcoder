using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

public class FixedPointTheorem
{
        public double cycleRange(double R)
        {
            //F(X)=R*X*(1-X) //200,001//201,000
            var x = .25;
            var n1 = 200001;
            var n2 = 201000;
            for (int i = 0; i < n1-1; i++)
            {
                x = R*x*(1 - x);
            }
            double min = Double.MaxValue;
            double max = Double.MinValue;
            for (int i = n1; i <= n2; i++)
            {
                x = R * x * (1 - x);
                if (x < min) min = x;
                if (x > max) max = x;
            }
            return Math.Abs(min - max);
        }


}
//Powered by [KawigiEdit] 2.0!
