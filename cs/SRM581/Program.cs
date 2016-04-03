using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM581
{
    public class SurveillanceSystem
    {
        public string getContainerInfo(string containers, int[] reports, int L)
        {
            return "A";
        }
    }

    //public class BlackAndWhiteSolitaire
    //{
    //    public int minimumTurns(string cardFront)
    //    {
    //        int N = cardFront.Length;
    //        int b = 0, w = 0;
    //        int bs = 0, ws = 0;
    //        int bsm = 0, wsm = 0;
    //        int count = 0;
    //        foreach (char c in cardFront)
    //        {
    //            bsm = (bs > bsm) ? bs : bsm;
    //            wsm = (ws > wsm) ? ws : wsm;
    //            if (c == 'B')
    //            {
    //                count += wsm / 2;
    //                ws = 0;
    //                bs++;
    //                b++;
    //            }
    //            else
    //            {
    //                count += bsm / 2;
    //                bs = 0;
    //                ws++;
    //                w++;
    //            }
    //        }

    //        return count;
    //    }

    public class BlackAndWhiteSolitaire
    {
        public int minimumTurns(string cardFront)
        {
            int n = cardFront.Length;
            char[] bs = new char[n];
            char[] ws = new char[n];
            char bnext = 'B', wnext = 'W';

            for (int i = 0; i < n; i++)
            {
                bs[i] = bnext;
                ws[i] = wnext;
                bnext = (bnext == 'B') ? 'W' : 'B';
                wnext = (wnext == 'B') ? 'W' : 'B';
            }

            int b = 0, w = 0;

            for (int i = 0; i < n; i++)
            {
                if (cardFront[i] != bs[i]) b++;
                if (cardFront[i] != ws[i]) w++;
            }

            return b > w ? w : b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run2();
        }

        private void Run2()
        {
            var task2 = new BlackAndWhiteSolitaire();
            var method1 = task2.minimumTurns("BBWBWWBWBWWBBBWBWBWBBWBBW");

            //var task2 = new SurveillanceSystem();
            //var method1 = task2.getContainerInfo("-X--XX", new int[] { 1, 2 }, 3);

            Console.WriteLine(method1);

            Console.ReadKey();
        }
    }
}
