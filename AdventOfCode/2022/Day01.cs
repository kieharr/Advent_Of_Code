namespace AdventOfCode._2022;

public class Day01: Solution<int>
{
    private static IEnumerable<int> Calories(IEnumerable<string> input) =>  
        input.JoinLines()
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => x.Split(Environment.NewLine).Sum(int.Parse));

    public override int Part1(IEnumerable<string> input)
    {
        return Calories(input).Max();
    }

    public override int Part2(IEnumerable<string> input)
    {
        return Calories(input).OrderByDescending(x => x).Take(3).Sum();
    }
}