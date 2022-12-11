namespace AdventOfCode._2022;

public class Day06: Solution
{
    public override string Part1(IEnumerable<string> input)
    {
        return GetMarker(input.First(), 4).ToString();
    }

    public override string Part2(IEnumerable<string> input)
    {
        return GetMarker(input.First(), 14).ToString();
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