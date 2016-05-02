// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ContestScore
{
    class GroupJudge
    {
        public string Name { get; set; }
        public int[] Judges { get; set; }
        public int[] JudgeRanks { get; set; }
        public int TotalRank { get; set; }
        public int TotalScore { get; set; }

        public static GroupJudge Parse(string input)
        {
            var inputSplit = input.Split(' ');
            var judges = inputSplit.Skip(1).Select(x => (int)(double.Parse(x) * 10)).ToArray();
            return new GroupJudge()
            {
                Name = inputSplit[0],
                Judges = judges,
                JudgeRanks = new int[judges.Length],
                TotalScore = judges.Sum()
            };
        }

        public static string Output(GroupJudge gj)
        {
            return string.Format("{0} {1} {2:0.0}", gj.Name, gj.TotalRank, gj.TotalScore / 10.0);
        }
    }

    public string[] sortResults(string[] data)
    {
        if (data == null || data.Length == 0) return new string[0];

        var groups = data.Select(GroupJudge.Parse).ToList();
        var n = groups.First().Judges.Length;

        for (int i = 0; i < n; i++)
        {
            var gByJudgeScore = groups.OrderByDescending(g => g.Judges[i]);
            var lastScore = gByJudgeScore.First().Judges[i];
            var rankNumber = 1;
            var nextToAdd = 0;
            foreach (var groupJudge in gByJudgeScore)
            {
                if (Math.Abs(groupJudge.Judges[i] - lastScore) > 0.0000001)
                {
                    rankNumber += nextToAdd;
                    nextToAdd = 1;
                    groupJudge.JudgeRanks[i] = rankNumber;
                    lastScore = groupJudge.Judges[i];
                }
                else
                {
                    groupJudge.JudgeRanks[i] = rankNumber;
                    nextToAdd++;
                }
            }
        }

        foreach (var groupJudge in groups)
        {
            groupJudge.TotalRank = groupJudge.JudgeRanks.Sum();
        }

        var result = groups
            .OrderBy(g => g.TotalRank)
            .ThenByDescending(g => g.TotalScore)
            .ThenBy(g => g.Name)
            .Select(GroupJudge.Output)
            .ToArray();

        return result;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            eq(0, (new ContestScore()).sortResults(new string[] {"A 90.7 92.9 87.4",
                "B 90.5 96.6 88.0",
                "C 92.2 91.0 95.3"}), new string[] { "C 5 278.5", "B 6 275.1", "A 7 271.0" });
            eq(1, (new ContestScore()).sortResults(new string[] {"STANFORD 85.3 90.1 82.6 84.6 96.6 94.5 87.3 90.3",
                "MIT 95.5 83.9 80.4 85.5 98.7 98.3 96.7 82.7",
                "PRINCETON 99.2 79.1 87.6 85.1 93.6 96.4 86.0 90.6",
                "HARVARD 83.6 92.0 85.5 94.3 97.5 91.5 92.5 83.0",
                "YALE 99.5 92.6 86.2 82.0 96.4 92.6 84.5 78.6",
                "COLUMBIA 97.2 87.6 81.7 93.7 88.0 86.3 95.9 89.6",
                "BROWN 92.2 95.8 92.1 81.5 89.5 87.0 95.5 86.4",
                "PENN 96.3 80.7 81.2 91.6 85.8 92.2 83.9 87.8",
                "CORNELL 88.0 83.7 85.0 83.8 99.8 92.1 91.0 88.9"}), new string[] { "PRINCETON 34 717.6", "MIT 36 721.7", "HARVARD 38 719.9", "COLUMBIA 39 720.0", "STANFORD 39 711.3", "YALE 40 712.4", "BROWN 41 720.0", "CORNELL 42 712.3", "PENN 51 699.5" });
            eq(2, (new ContestScore()).sortResults(new string[] { }), new string[] { });
            eq(3, (new ContestScore()).sortResults(new string[] {"AA 90.0 80.0 70.0 60.0 50.0 40.0",
                "BBB 80.0 70.0 60.0 50.0 40.0 90.0",
                "EEE 70.0 60.0 50.0 40.0 90.0 80.0",
                "AAA 60.0 50.0 40.0 90.0 80.0 70.0",
                "DDD 50.0 40.0 90.0 80.0 70.0 60.0",
                "CCC 40.0 90.0 80.0 70.0 60.0 50.0"}), new string[] { "AA 21 390.0", "AAA 21 390.0", "BBB 21 390.0", "CCC 21 390.0", "DDD 21 390.0", "EEE 21 390.0" });
            eq(4, (new ContestScore()).sortResults(new string[] { "A 00.1", "B 05.2", "C 29.0", "D 00.0" }), new string[] { "C 1 29.0", "B 2 5.2", "A 3 0.1", "D 4 0.0" });
        }
        catch (Exception ex)
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
