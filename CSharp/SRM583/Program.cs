using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM583
{
    public class SwappingDigits
    {
        public string minNumber(string n)
        {
            char[] numOriginal = n.ToCharArray();
            char[] num = n.ToCharArray();

            Array.Sort(num);

            int leadingZeros = 0;
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] == '0')
                {
                    leadingZeros++;
                    continue;
                }

                int orPos = i - leadingZeros;

                if (numOriginal[orPos] == '0')
                {
                    leadingZeros--;
                    orPos = i - leadingZeros;
                }

                if (num[i] != numOriginal[orPos])
                {
                    char tmp = numOriginal[orPos];
                    numOriginal[orPos] = num[i];

                    for (int j = num.Length-1; j >= 0; j--)
                    {
                        if (numOriginal[j] == num[i])
                        {
                            numOriginal[j] = tmp;
                            break;
                        }
                    }
                    break;
                }
            }

            return new string(numOriginal);
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            var aaaa = new SwappingDigits();

            var res = aaaa.minNumber("102033045020203100");

            Console.WriteLine(res);

            Console.ReadKey();
        }
    }
}
