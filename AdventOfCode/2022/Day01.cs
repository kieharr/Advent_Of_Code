namespace AdventOfCode._2022;

public class Day01: Solution
{
    private static IEnumerable<int> Calories(IEnumerable<string> input) =>  
        input.JoinLines()
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => x.Split(Environment.NewLine).Sum(int.Parse));

    public override string Part1(IEnumerable<string> input)
    {
        return Calories(input).Max().ToString();
    }

    public override string Part2(IEnumerable<string> input)
    {
        return Calories(input).OrderByDescending(x => x).Take(3).Sum().ToString();
    }
}