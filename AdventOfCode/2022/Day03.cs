using MoreLinq;
namespace AdventOfCode._2022;

public class Day03: Solution
{
    public override string Part1(IEnumerable<string> input)
    {
        return input.Select(x => x[..(x.Length / 2)].Intersect(x[(x.Length / 2)..]).First())
            .Sum(GetValue).ToString();
    }

    public override string Part2(IEnumerable<string> input)
    {
        return input.Batch(3).Select(x => x.ToList())
            .Sum(x => GetValue(x[0].Intersect(x[1]).Intersect(x[2]).First())).ToString();
    }
    
    private static int GetValue(char c) =>
        c switch
        {
            >= 'a' and <= 'z' => c - 96,
            >= 'A' and <= 'Z' => c - 38,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, null)
        };
}