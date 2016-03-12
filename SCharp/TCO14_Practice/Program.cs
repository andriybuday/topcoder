using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCO14_Practice
{
    public class PrefixCode
    {
        public string isOne(string[] words)
        {
            for (int i = 0; i < words.Length; ++i)
            {
                for (int j = 0; j < words.Length; ++j)
                {
                    if (i != j && words[j].StartsWith(words[i]))
                        return string.Format("No, {0}", i);
                }

            }
            return "Yes";
        }

    }


    public class Birthday
    {
        public string getNext(string date, string[] birthdays)
        {
            var currentDate = convertToDate(date);

            var bDays = new List<DateTime>();
            foreach (var birthday in birthdays)
            {
                string bd = birthday.Split(' ')[0];
                DateTime dateTime = convertToDate(bd);
                if (dateTime < currentDate)
                {
                    dateTime = dateTime.AddYears(1);
                }
                bDays.Add(dateTime);
            }
            bDays.Sort();

            return bDays[0].ToString("MM/dd", CultureInfo.InvariantCulture);
        }

        public DateTime convertToDate(string d)
        {
            return DateTime.ParseExact(d + "/2000", "MM/dd/yyyy", CultureInfo.InvariantCulture);
        }

    }

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

    /*
 List mergeSort(List a)
1. if size(a) <= 1, return a
2. split a into two sublists b and c
if size(a) = 2*k, b contains the first k elements of a, c the last k elements
if size(a) = 2*k+1, b contains the first k elements of a, c the last k+1 elements
3. List sb = mergeSort(b)
List sc = mergeSort(c)
4. return merge(sb, sc)
 
List merge(List b, List c)
1. create an empty list a
2. while both b and c are not empty, compare the first elements of b and c
first(b) < first(c): remove the first element of b and append it to the end of a
first(b) > first(c): remove the first element of c and append it to the end of a
first(b) = first(c): remove the first elements of b and c and append them to the end of a
3. if either b or c is not empty, append that non-empty list to the end of a
4. return a
 */

    class Program
    {
        static void Main(string[] args)
        {
            string next = new Birthday().getNext("06/17", new string[] { "02/17 Wernie", "10/12 Stefan" });
            Console.WriteLine(next);
            //var answer = new InterestingDigits().digits(26);
            //foreach (var i in answer)
            //{
            //    Console.Write("{0} ", i);
            //}
            Console.ReadKey();
        }
    }
}
