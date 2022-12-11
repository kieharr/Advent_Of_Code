namespace AdventOfCode._2022;

public class Day02: Solution
{
    public override string Part1(IEnumerable<string> input)
    {
        var lookup = new Dictionary<string, int>
        {
            { "A X", 4 },
            { "A Y", 8 },
            { "A Z", 3 },
            { "B X", 1 },
            { "B Y", 5 },
            { "B Z", 9 },
            { "C X", 7 },
            { "C Y", 2 },
            { "C Z", 6 },
        };
        return input.Sum(x => lookup[x]).ToString();
    }

    public override string Part2(IEnumerable<string> input)
    {
        var lookup = new Dictionary<string, int>
        {
            { "A X", 3 },
            { "A Y", 4 },
            { "A Z", 8 },
            { "B X", 1 },
            { "B Y", 5 },
            { "B Z", 9 },
            { "C X", 2 },
            { "C Y", 6 },
            { "C Z", 7 },
        };
        return input.Sum(x => lookup[x]).ToString();
    }
}