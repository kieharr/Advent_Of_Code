namespace AdventOfCode;

public static class Extensions
{
    public static string JoinLines(this IEnumerable<string> lines) => string.Join(Environment.NewLine, lines);
}