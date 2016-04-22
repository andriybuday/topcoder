using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

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
//Powered by [KawigiEdit] 2.0!
