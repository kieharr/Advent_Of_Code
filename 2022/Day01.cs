namespace AdventOfCode._2022;

public class Day01: Solution<string, int>
{
    private IEnumerable<int> Calories => Input.Split("\n\n")
        .Select(x => x.Split("\n").Select(int.Parse).Sum());
    
    public override int Part1()
    {
        return Calories.Max();
    }

    public override int Part2()
    {
        return Calories.OrderByDescending(x => x).Take(3).Sum();
    }
}