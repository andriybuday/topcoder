using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;

public class CeyKaps
{
    public string decipher(string typed, string[] switches)
    {
        var sb = new StringBuilder();

        foreach (var t in typed)
        {
            var current = t;
            foreach (var s in switches)
            {
                if (s[0] == current)
                    current = s[2];
                else if (s[2] == current)
                    current = s[0];
            }
            sb.Append(current);
        }
        return sb.ToString();
    }
}


// Powered by FileEdit
// Powered by CodeProcessor
