using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class DivisorDigits
{
    public int howMany(int number)
    {
        int numberCopy = number;
        int counter = 0;
        while (numberCopy != 0)
        {
            int r = numberCopy % 10;
            numberCopy /= 10;
            if (r != 0 && number % r == 0)
            {
                counter++;
            }
        }
        return counter;
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
