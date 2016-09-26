using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class Plusonegame
{
    public string getorder(string s)
    {
        var chars = s.ToCharArray();
        var digits = chars.Where(c => char.IsDigit(c)).Select(c => (int)(c - '0')).OrderBy(c => c).ToList();
        long numPlus = chars.Length - digits.Count;
        long current = 0;

        var sb = new StringBuilder();
        foreach (int digit in digits)
        {
            if (current < digit)
            {
                long needMore = digit - current;

                long havePlusses = Math.Min(needMore, numPlus);
                numPlus -= havePlusses;

                for (int i = 0; i < havePlusses; i++)
                {
                    sb.Append('+');
                }

                current += havePlusses;

                current -= Math.Abs(current - digit);

                sb.Append(digit);
            }
            else if (current == digit)
            {
                sb.Append(digit);
            }
        }
        for (int i = 0; i < numPlus; i++)
        {
            sb.Append('+');
        }

        return sb.ToString();
    }

}


// Powered by FileEdit
// Powered by CodeProcessor
