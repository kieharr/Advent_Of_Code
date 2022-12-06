namespace AdventOfCode._2022;

public class Day06: Solution<string, int>
{ 
    protected override int Part1(string input)
    {
        return GetMarker(input, 4);
    }

    protected override int Part2(string input)
    {
        return GetMarker(input, 14);
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