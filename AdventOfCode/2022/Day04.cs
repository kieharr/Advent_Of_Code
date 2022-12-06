using System.Text.RegularExpressions;

namespace AdventOfCode._2022;

public class Day04: Solution<int>
{
    private readonly Regex _regex = new (@"(\d+)-(\d+),(\d+)-(\d+)");

    public override int Part1(IEnumerable<string> input)
    {
        return input.Select(GetRanges)
            .Count(x => !x.Item1.Except(x.Item2).Any() || !x.Item2.Except(x.Item1).Any());
    }

    public override int Part2(IEnumerable<string> input)
    {
        return input.Select(GetRanges)
            .Count(x => x.Item1.Intersect(x.Item2).Any());
    }
    
    private (List<int>, List<int>) GetRanges(string input)
    {
        var nums = _regex.Match(input).Groups.Values.Skip(1).Select(x => int.Parse(x.Value)).ToList();
        var range1 = Enumerable.Range(nums[0], nums[1] - nums[0] + 1).ToList();
        var range2 = Enumerable.Range(nums[2], nums[3] - nums[2] + 1).ToList();

        return (range1, range2);
    }
}