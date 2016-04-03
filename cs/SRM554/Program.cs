using System;
using System.Linq;

namespace SRM554
{
    public class TheBrickTowerEasyDivTwo
    {
        public int find(int redCount, int redHeight, int blueCount, int blueHeight)
        {
            if (redHeight != blueHeight)
            {
                if (redCount < blueCount)
                {
                    return redCount * 3 + 1;
                }
                else if (redCount > blueCount)
                {
                    return blueCount * 3 + 1;
                }
                return redCount * 3;
            }
            else
            {
                if (redCount < blueCount)
                {
                    return redCount * 2 + 1;
                }
                else if (redCount > blueCount)
                {
                    return blueCount * 2 + 1;
                }
                return redCount * 2;
            }
        }
    }

    public class TheBrickTowerMediumDivTwo
    {
        private int level = -1;
        private int numOfElem;
        private int[] permutation = new int[0];
        private int[] bestPermutation = new int[0];
        private int minDistance = 100000000;

        public int[] InputSet;
        public int PermutationCount;

        public void NextPermutatoin(int k)
        {
            level++;
            permutation.SetValue(level, k);

            if (level != numOfElem)
            {
                for (int i = 0; i < numOfElem; i++)
                {
                    if (permutation[i] == 0)
                    {
                        NextPermutatoin(i);
                    }
                }
            }
            else
            {
                CalculateDistance(permutation);
            }
            level--;
            permutation.SetValue(0, k);
        }

        private void CalculateDistance(int[] currentPerm)
        {
            int sum = 0;
            for (int i = 0; i < numOfElem; i++)
            {
                int height = InputSet[currentPerm[i] - 1];
                if(i < numOfElem - 1)
                {
                    int nextHeight = InputSet[currentPerm[i+1]-1];
                    if(height > nextHeight)
                    {
                        sum += height;
                    }
                    else
                    {
                        sum += nextHeight;
                    }
                }
                
                //Console.Write(height);
            }

            if(sum < minDistance)
            {
                minDistance = sum;
                for (int i = 0; i < numOfElem; i++)
                {
                    bestPermutation[i] = currentPerm[i] - 1;
                }                
            }

            //Console.WriteLine();
            PermutationCount++;
        }

        public int[] find(int[] heights)
        {
            numOfElem = heights.Length;
            permutation = new int[heights.Length];
            bestPermutation = new int[heights.Length];
            InputSet = heights;

            NextPermutatoin(0);

            return bestPermutation;
        }

        public int[] find2(int[] heights)
        {
            int[] ret = new int[heights.Length];
            ret[0] = 0;
            var x = heights.ToList();
            x.RemoveAt(0);

            x.Sort();

            for (int i = 0; i < x.Count; i++)
            {
                for (int j = 1; j < heights.Length; j++)
                {
                    if(x[i] == heights[j])
                    {
                        ret[i + 1] = j;
                        heights[j] = -1;
                        break;
                    }
                }
            }
            return ret;
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
            var task2 = new TheBrickTowerMediumDivTwo();
            //var method1 = task2.find(new int[] { 4, 5, 7 });
            var method1 = task2.find2(new int[] { 4, 5, 7 });

            foreach (int i in method1)
            {
                Console.Write("_{0}", i);
            }

            Console.ReadKey();
        }

        private void Run()
        {
            var task1 = new TheBrickTowerEasyDivTwo();
            var method1 = task1.find(1, 5, 1, 1);

            Console.WriteLine(method1);

            Console.ReadKey();
        }
    }
}
