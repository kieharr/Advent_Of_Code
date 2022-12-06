namespace AdventOfCode._2022;

public class Day06: Solution<int>
{
    public override int Part1(IEnumerable<string> input)
    {
        return GetMarker(input.First(), 4);
    }

    public override int Part2(IEnumerable<string> input)
    {
        return GetMarker(input.First(), 14);
    }

    private static int GetMarker(string input, int distinctCount)
    {
        var recent = input.Take(distinctCount).ToList();
        for (var i = distinctCount; i < input.Length; i++)
        {
            if (recent.Distinct().Count() == distinctCount)
            {
                return i;
            }
            recent.RemoveAt(0);
            recent.Add(input[i]);
        }
        throw new Exception("Marker not found");
    }
}