using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCO14_Practice
{
    /// <summary>
    /// SRM 150 Div2 II
    /// </summary>
    public class InterestingDigits
    {

        public int[] digits(int Base)
        {
            var res = new List<int>();

            for (int i = 2; i < Base; i++)
            {
                var valid = true;
                for (int j = i + 1; j < 9999; j++)
                {
                    if (!Check(i, j, Base))
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid) res.Add(i);
            }
            return res.ToArray();
        }

        private bool Check(int i, int j, int @base)
        {
            var jInBase = toBase(j, @base);
            var m = M(i, jInBase, @base);

            int last = 0;
            int first = 0;
            foreach (var d in m)
            {
                int i1 = (d + last);
                last = i1 % @base;
                first += i1 / @base;
            }

            return (first * @base + last) % i == 0;
        }

        private List<int> M(int digit, List<int> number, int @base)
        {
            var res = new List<int>();
            int fromLast = 0;
            for (int i = 0; i < number.Count; i++)
            {
                int mult = number[i] * digit + fromLast;

                int lastDig = mult % @base;
                res.Add(lastDig);

                fromLast = mult / @base;
            }
            if (fromLast > 0) res.Add(fromLast);
            return res;
        }

        private List<int> toBase(int number, int @base)
        {
            var res = new List<int>();
            while (number > 0)
            {
                int lastDig = number % @base;
                res.Add(lastDig);
                if ((number / @base) == 0) break;
                number -= (number / @base) * @base;
            }
            //res.Reverse();
            return res;
        }
    }
}
