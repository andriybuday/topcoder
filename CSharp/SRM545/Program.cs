using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRM545
{
    public class StrIIRec
    {
        public int getInvCount(char[] arr, int n)
        {
            int inv_count = 0;
            int i, j;

            for (i = 0; i < n - 1; i++)
                for (j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        inv_count++;

            return inv_count;
        }

        public int Mahonian(int n, int x)
        {
            int mult = 1;
            for (int i = 0; i < n; i++)
            {
                int m = i;
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += (int)Math.Pow(x, j);
                }
                mult *= sum;
            }

            return mult;
        }

        public string recovstr(int n, int minInv, string minStr)
        {
            var invCount = getInvCount(minStr.ToCharArray(), minStr.Length);

            var toBeLeft = minInv - invCount;

            for (int i = 0; i < n - minStr.Length; i++)
            {
             //Mahonian()    
            }

            return string.Empty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var className = new ANDEquation();

            //var res = className.restoreY(new int[] { 31, 7, 7 });


            Console.ReadLine();
        }
    }
}
