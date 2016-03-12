using System;

namespace SRM560
{
    public class TypingDistance
    {
        public int minDistance(string keyboard, string word)
        {
            int dist = 0;
            int prev = keyboard.IndexOf(word[0]);
            int next = 0;
            foreach (char w in word)
            {
                next = keyboard.IndexOf(w);
                dist += Math.Abs(next - prev);
                prev = next;
            }
            return dist;
        }
    }

    public class DrawingPointsDivTwo
    {
        public int maxSteps(string[] points)
        {
            int dist = 0;

            return dist;
        }
    }


    public class TomekPhone
    {
        public int minKeystrokes(int[] occurences, int[] keySizes)
        {
            Array.Sort(occurences);
            Array.Reverse(occurences);

            Array.Sort(keySizes);
            Array.Reverse(keySizes);

            int allowed = 0;
            foreach (int keySize in keySizes) allowed += keySize;
            if(allowed < occurences.Length) return -1;

            int[] levels = new int[keySizes[0]];

            for (int i = 0; i < levels.Length; i++)
            {
                foreach (int keySize in keySizes)
                    levels[i] += (keySize > i) ? 1 : 0;
            }

            int min = 0;
            int next = 0;
            for (int i = 0; i < levels.Length; i++)
            {
                for (int j = next; j < next + levels[i] && j < occurences.Length; j++)
                {
                    min += occurences[j]*(i + 1);
                }
                next = next + levels[i];
            }

            return min;
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
            //var task2 = new TypingDistance();
            //var method1 = task2.minDistance("qwertyuiop", "potter");
            //var task2 = new TomekPhone();
            //var method1 = task2.minKeystrokes(new int[] { 11, 23, 4, 50, 1000, 7, 18 }, new int[] { 3, 1, 4 });

            var task2 = new DrawingPointsDivTwo();
            var method1 = task2.maxSteps(new string[]{"*..*"});

            Console.WriteLine(method1);

            Console.ReadKey();
        }
    }
}
