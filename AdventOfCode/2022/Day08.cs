using System.Drawing;

namespace AdventOfCode._2022;

public class Day08: Solution<int>
{
    private Dictionary<Point, int> _map = new();

    public override int Part1(IEnumerable<string> input)
    {
        _map = BuildMap(input);
        return _map.Count(x => IsVisible(x.Key));
    }
    
    public override int Part2(IEnumerable<string> input)
    {
        _map = BuildMap(input);
        return _map.Select(x => GetScenicScore(x.Key)).Max();
    }

    private bool IsVisible(Point point)
    {
        return Enum.GetValues<Direction>().Any(direction => IsVisibleInDirection(point, direction));
    }
    
    private bool IsVisibleInDirection(Point point, Direction direction)
    {
        var value = _map[point];
        var newPoint = point.Move(direction);
        while (_map.TryGetValue(newPoint, out var height))
        {
            if (height >= value)
            {
                return false;
            }

            newPoint = newPoint.Move(direction);
        }

        return true;
    }
    
    private int GetScenicScore(Point point)
    {
        return Enum.GetValues<Direction>().Aggregate(1, (current, direction) => current * GetScenicScoreForDirection(point, direction));
    }

    private int GetScenicScoreForDirection(Point point, Direction direction)
    {
        var score = 0;
        var value = _map[point];
        var newPoint = point.Move(direction);
        while (_map.TryGetValue(newPoint, out var height))
        {
            score++;
            if (height >= value)
            {
                return score;
            }

            newPoint = newPoint.Move(direction);
        }

        return score;
    }
    
    private static Dictionary<Point, int> BuildMap(IEnumerable<string> input)
    {
        var map = new Dictionary<Point, int>();
        var row = 0;
        foreach (var line in input)
        {
            var column = 0;
            foreach (var character in line)
            {
                map.Add(new Point(row, column++), character - '0');
            }
            row++;
        }
        return map;
    }
}