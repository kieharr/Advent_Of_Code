namespace AdventOfCodeTests;

public static class TestExtensions
{
    public static IEnumerable<string> ToEnumerable(this string input) => input.Split(Environment.NewLine);
}