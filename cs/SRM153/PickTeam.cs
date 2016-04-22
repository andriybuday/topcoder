// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class PickTeam
{
    public class Person
    {
        public string Name;
        public int[] GetsAlong;

        public Person(string p)
        {
            var split = p.Split(' ');
            Name = split[0];
            GetsAlong = split.Skip(1).Take(100).Select(Int32.Parse).ToArray();
        }
    }
    public int CountEnabledBits(int n)
    {
        var count = 0;
        while(n > 0)
        {
            count += (n & 1);
            n = n >> 1;
        }
        return count;
    }
    public List<int> GetEnabledIndexes(int n)
    {
        var r = new List<int>();
        var ind = 0;
        while (n > 0)
        {
            if((n & 1) > 0)
            {
                r.Add(ind);
            }
            n = n >> 1;
            ind++;
        }
        return r;
    }
    public string[] pickPeople(int teamSize, string[] people)
    {
        var persons = new List<Person>();
        Array.ForEach(people, p => persons.Add(new Person(p)));
        int maxGetAlong = Int32.MinValue;
        var winTeam = new List<int>();
        for (int n = 0; n < 1 << people.Length; n++)
        {
            if(CountEnabledBits(n) == teamSize)
            {
                var enablIndx = GetEnabledIndexes(n);
                int currSum = 0;
                for (int i = 0; i < enablIndx.Count; i++)
                {
                    for (int j = i + 1; j < enablIndx.Count; j++)
                    {
                        currSum += persons[enablIndx[i]].GetsAlong[enablIndx[j]];
                    }
                }
                if(currSum > maxGetAlong)
                {
                    maxGetAlong = currSum;
                    winTeam = enablIndx;
                }
            }
        }
        var names = new List<string>();
        for (int i = 0; i < winTeam.Count; i++)
        {
            names.Add(persons[winTeam[i]].Name);
        }
        names.Sort();
        return names.ToArray();
    }

// BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0,(new PickTeam()).pickPeople(3, new string[] {"ALICE 0 1 -1 3",
                "BOB 1 0 2 -4",
                "CAROL -1 2 0 2",
                "DAVID 3 -4 2 0"}),new string[] { "ALICE",  "CAROL",  "DAVID" });
            eq(1,(new PickTeam()).pickPeople(2, new string[] {"ALICE 0 1 -1 3",
                "BOB 1 0 2 -4",
                "CAROL -1 2 0 2",
                "DAVID 3 -4 2 0"}),new string[] { "ALICE",  "DAVID" });
            eq(2,(new PickTeam()).pickPeople(2, new string[] {"A 0 -2 -2","B -2 0 -1","C -2 -1 0"}),new string[] { "B",  "C" });
            eq(3,(new PickTeam()).pickPeople(13, new string[] {"A 0 2 8 7 1 -4 -3 1 8 2 8 2 1 -3 7 1 3 9 -6 -5",
                "A 2 0 0 7 -7 -5 8 -8 -9 -9 6 -9 -4 -8 8 1 7 0 3 3",
                "A 8 0 0 -5 -5 -7 1 -3 1 9 -6 6 1 5 6 -9 8 6 -8 -8",
                "A 7 7 -5 0 7 -5 3 9 8 3 -6 -5 -5 2 -6 2 -2 -1 -2 8",
                "B 1 -7 -5 7 0 7 -2 -9 3 7 0 -2 1 1 -9 -3 -2 2 1 -2",
                "B -4 -5 -7 -5 7 0 4 8 6 0 -1 4 1 -2 -9 4 0 -7 6 -2",
                "B -3 8 1 3 -2 4 0 8 -1 1 -2 -7 5 0 -6 9 0 -3 1 3",
                "B 1 -8 -3 9 -9 8 8 0 0 -2 5 0 5 8 3 5 2 4 5 4",
                "C 8 -9 1 8 3 6 -1 0 0 8 -3 8 -6 -4 7 -4 1 -5 5 4",
                "C 2 -9 9 3 7 0 1 -2 8 0 -9 -6 6 5 -8 -3 -8 2 2 4",
                "C 8 6 -6 -6 0 -1 -2 5 -3 -9 0 2 7 8 2 -6 -4 -6 4 4",
                "C 2 -9 6 -5 -2 4 -7 0 8 -6 2 0 0 -3 6 7 -1 2 -4 -2",
                "D 1 -4 1 -5 1 1 5 5 -6 6 7 0 0 -7 -4 8 -6 -3 4 -6",
                "D -3 -8 5 2 1 -2 0 8 -4 5 8 -3 -7 0 7 -3 5 -8 5 1",
                "D 7 8 6 -6 -9 -9 -6 3 7 -8 2 6 -4 7 0 9 -5 -5 -8 3",
                "D 1 1 -9 2 -3 4 9 5 -4 -3 -6 7 8 -3 9 0 -2 -7 8 -7",
                "E 3 7 8 -2 -2 0 0 2 1 -8 -4 -1 -6 5 -5 -2 0 6 0 5",
                "E 9 0 6 -1 2 -7 -3 4 -5 2 -6 2 -3 -8 -5 -7 6 0 4 8",
                "E -6 3 -8 -2 1 6 1 5 5 2 4 -4 4 5 -8 8 0 4 0 1",
                "E -5 3 -8 8 -2 -2 3 4 4 4 4 -2 -6 1 3 -7 5 8 1 0"}),new string[] { "A",  "A",  "B",  "B",  "B",  "B",  "C",  "C",  "C",  "D",  "D",  "D",  "E" });
        } 
        catch(Exception ex)
        {
            System.Console.WriteLine(ex);
            System.Console.WriteLine(ex.StackTrace);
        }
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
// END CUT HERE
}
