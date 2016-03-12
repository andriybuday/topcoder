using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace SRM524
{
    public class MultiplesWithLimit
    {
        public string minMultiples(int n, int[] forbidden)
        {
            bool[] allowed = GetAllowedArray(forbidden);
            DigitsRepresentation nRep = DigitsRepresentation.GetDigitsRepresentation(n);

            for (int i = 0; i < 1000000; i++)
            {
                DigitsRepresentation iRep = DigitsRepresentation.GetDigitsRepresentation(i);

                List<List<int>> rowsToAdd = new List<List<int>>();
                int counter = 0;
                for (int j = 0; j < iRep.Digits.Count; j++)
                {
                    var multRow = new List<int>();
                    for (int ghajdg = 0; ghajdg < counter; ghajdg++)
                    {
                        multRow.Add(0);
                    }

                    int leftToAdd = 0;
                    for (int k = 0; k < nRep.Digits.Count; k++)
                    {
                        var multNumber = nRep.Digits[k] * iRep.Digits[j] + leftToAdd;
                        if (multNumber >= 10)
                        {
                            leftToAdd = multNumber / 10;
                        }
                        multRow.Add(multNumber % 10);
                    }
                    counter++;
                    rowsToAdd.Add(multRow);
                }
                rowsToAdd.Add(new List<int>(){0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0});
                // Adding it together...
                List<int> finalRow = new List<int>();
                for (int j = 0; j < rowsToAdd.Count-1; j++)
                {
                    int leftItem = 0;
                    for (int k = 0; k < Math.Max(rowsToAdd[j].Count, rowsToAdd[j+1].Count); k++)
                    {
                        int sumRes = rowsToAdd[j][k] + rowsToAdd[j + 1][k] + leftItem;
                        if (sumRes >= 10)
                        {
                            leftItem = sumRes / 10;
                        }
                        finalRow[k] = finalRow[k] + sumRes%10;
                    }
                }


            }


            foreach (bool b in allowed)
            {

            }

            return "IMPOSSIBLE";
        }

        public class DigitsRepresentation
        {
            public List<int> Digits { get; private set; }

            public static DigitsRepresentation GetDigitsRepresentation(int n)
            {
                var digitsRepresentation = new DigitsRepresentation();
                digitsRepresentation.Digits = new List<int>();

                while (n > 0)
                {
                    int lastDigit = n % 10;
                    digitsRepresentation.Digits.Add(lastDigit);
                    n = n / 10;
                }

                return digitsRepresentation;
            }
        }

        private bool[] GetAllowedArray(int[] forbidden)
        {
            var allowed = new bool[10];
            for (int i = 0; i < allowed.Length; i++)
            {
                allowed[i] = true;
            }
            for (int i = 0; i < forbidden.Length; i++)
            {
                allowed[forbidden[i]] = false;
            }
            return allowed;
        }
    }

    public class MagicDiamonds
    {
        public long minimalTransfer(long n)
        {
            if (n == 3)
            {
                return 3;
            }

            if (isPrime(n))
            {
                return 2;
            }

            return 1;
        }

        public bool isPrime(long number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            long upTo = (long)Math.Ceiling(Math.Sqrt(number));
            for (long i = 2; i <= upTo; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;

        }
    }

    public class ShippingCubes
    {
        public int minimalCost(int N)
        {
            int min_cost = 1000000;

            for (int a = 1; a < 201; a++)
            {
                for (int b = 1; b < 201; b++)
                {
                    for (int c = 1; c < 201; c++)
                    {
                        if (a * b * c == N)
                        {
                            if (a + b + c < min_cost)
                            {
                                min_cost = a + b + c;
                            }
                        }
                    }
                }
            }
            return min_cost;
        }
    }




    [TestFixture]
    internal class TopCoderTests
    {
        //[Test]
        //public void MethodToImplemnt_1()
        //{
        //    var target = new TopCoderClass();

        //    int result = target.MethodToImplemnt(5, 6);

        //    var expected = 11;
        //    Assert.That(result, Is.EqualTo(expected));    
        //}

        [Test]
        public void MagicDiamonds_Test1()
        {
            var target = new MagicDiamonds();

            long result = target.minimalTransfer(5);
            var expected = 2;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MagicDiamonds_Test2()
        {
            var target = new MagicDiamonds();

            long result = target.minimalTransfer(13);
            var expected = 2;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MagicDiamonds_Test3()
        {
            var target = new MagicDiamonds();

            long result = target.minimalTransfer(98);
            var expected = 1;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MagicDiamonds_Test4()
        {
            var target = new MagicDiamonds();

            long result = target.minimalTransfer(3);
            var expected = 3;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void DigitsRepresentation_get()
        {
            var rep = MultiplesWithLimit.DigitsRepresentation.GetDigitsRepresentation(356);


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

