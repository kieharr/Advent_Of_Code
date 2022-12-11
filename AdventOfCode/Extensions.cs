using System.Drawing;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public static class Extensions
{
    public static string JoinLines(this IEnumerable<string> lines) => string.Join(Environment.NewLine, lines);
    
    public static Point Move(this Point point, Direction direction)
    {
        return direction switch
        {
            Direction.Up => point with { Y = point.Y - 1 },
            Direction.Down => point with { Y = point.Y + 1 },
            Direction.Left => point with { X = point.X - 1 },
            Direction.Right => point with { X = point.X + 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public static string GetFirstInGroup(this Match match, string groupName)
        => match.Groups[groupName].Captures.First().Value;
    
    public static T GetFirstInGroup<T>(this Match match, string groupName)
        => (T)Convert.ChangeType(match.Groups[groupName].Captures.First().Value, typeof(T));

    public static IEnumerable<string> GetAllInGroup(this Match match, string groupName)
        => match.Groups[groupName].Captures.Select(x => x.Value);
    
    public static IEnumerable<T> GetAllInGroup<T>(this Match match, string groupName)
    => match.Groups[groupName].Captures.Select(x => (T)Convert.ChangeType(x.Value, typeof(T)));

}