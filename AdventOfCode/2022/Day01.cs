namespace AdventOfCode._2022;

public class Day01: Solution<string, int>
{
    private static IEnumerable<int> Calories(string input) => input.Trim().Split("\n\n")
        .Select(x => x.Split("\n").Sum(int.Parse));
    
    protected override int Part1(string input)
    {
        return Calories(input).Max();
    }

    protected override int Part2(string input)
    {
        return Calories(input).OrderByDescending(x => x).Take(3).Sum();
    }
}