using System.Drawing;

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
}