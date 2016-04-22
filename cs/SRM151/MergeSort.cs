using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

public class MergeSort
{
        private int counter = 0;
	    public int howManyComparisons(int[] numbers)
	    {
	        counter = 0;
	        mergeSort(numbers.ToList());
            return counter;
	    }

        public List<int> mergeSort(List<int> a)
        {
            int len = a.Count;
            if (len <= 1) return a;

            List<int> b, c;
            int k = len/2;
            b = a.Take(k).ToList();
            c = a.Skip(k).Take(len - k).ToList();
            var sb = mergeSort(b);
            var sc = mergeSort(c);

            return merge(sb, sc);
        }

        private List<int> merge(List<int> b, List<int> c)
        {
            var a = new List<int>();
            while (b.Count > 0 && c.Count > 0)
            {
                if (b[0] < c[0])
                {
                    a.Add(b[0]);
                    b.RemoveAt(0);
                }
                else if (b[0] > c[0])
                {
                    a.Add(c[0]);
                    c.RemoveAt(0);
                }
                else
                {
                    a.Add(b[0]);
                    a.Add(c[0]);
                    b.RemoveAt(0);
                    c.RemoveAt(0);
                }
                counter++;
            }
            if(b.Count > 0)a.AddRange(b);
            if(c.Count > 0)a.AddRange(c);

            return a;
        }


}
//Powered by [KawigiEdit] 2.0!
