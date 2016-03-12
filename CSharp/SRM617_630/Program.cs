using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SRM617_630
{
    public class SilverbachConjecture
    {
        public int[] solve(int n)
        {
            var composite = new List<int>();
            for (int i = 4; i <= n; i++)
            {
                for (int j = 4; j <= n; j++)
                {
                    if (j % i == 0 && j / i > 1) composite.Add(j);
                }
            }

            foreach (var i in composite)
            {
                foreach (var j in composite)
                {
                    if (i + j == n)
                    {
                        Console.WriteLine("{0},{1}", i, j);
                    }
                       // return new int[] { i, j };
                }
            }
            return null;
        }
    }

    public class SlimeXSlimonadeTycoon
    {
        public int sell(int[] morning, int[] customers, int stale_limit)
        {
            int counter = 0;
            stale_limit--;
            for (int i = 0; i < morning.Length; i++)
            {
                int left_ind = (i - stale_limit) >= 0 ? (i - stale_limit) : 0;
                for (int j = left_ind; j <= i; j++)
                {
                    int canSellAllForJ = customers[i] - morning[j];
                    if (canSellAllForJ >= 0)
                    {
                        counter += morning[j];
                        morning[j] = 0;
                    }
                    else
                    {
                        counter += customers[i];
                        morning[j] -= customers[i];
                    }
                }
            }
            return counter;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int sell = new SlimeXSlimonadeTycoon().sell(
                new int[] {0, 1, 0, 1}, new int[] {1, 0, 1, 0}, 2);//1

            sell = new SlimeXSlimonadeTycoon().sell(
                new int[] { 0, 1, 0, 1 }, new int[] { 1, 0, 1, 0 }, 1);//0

            sell = new SlimeXSlimonadeTycoon().sell(
              new int[] { 100, 1, 5, 1 }, new int[] { 1, 1, 1, 1 }, 1);//0

            int[] solve = new SilverbachConjecture().solve(35);
            //Console.WriteLine(solve[0]);
            //Console.WriteLine(solve[1]);
            Console.WriteLine(sell);
            Console.ReadKey();
        }
    }
}
