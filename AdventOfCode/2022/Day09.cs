using System.Drawing;

namespace AdventOfCode._2022;

public class Day09: Solution
{
    public override string Part1(IEnumerable<string> input)
    {
        var visited = new HashSet<Point>();
        var head = new Point(0, 0);
        var tail = new Point(0, 0);
        
        foreach (var instruction in input.Select(x => new Instruction(x)))
        {
            for (var i = 0; i < instruction.Count; i++)
            {
                head = head.Move(instruction.Direction);
                tail = GetTailPosition(head, tail);
                visited.Add(tail);
            }

        }
        return visited.Count.ToString();
    }
    
    public override string Part2(IEnumerable<string> input)
    {
        const int length = 10;
        var visited = new HashSet<Point>();
        var list = Enumerable.Repeat(new Point(0, 0), length).ToList();

        foreach (var instruction in input.Select(x => new Instruction(x)))
        {
            for (var i = 0; i < instruction.Count; i++)
            {
                list[0] = list[0].Move(instruction.Direction);
                for (var j = 1; j < length; j++)
                {
                    list[j] = GetTailPosition(list[j - 1], list[j]);
                }
                visited.Add(list[length-1]);
            }

        }
        return visited.Count.ToString();
    }

    //todo clean up
    private static Point GetTailPosition(Point head, Point tail)
    {
        var diffX = Math.Abs(head.X - tail.X);
        var diffY = Math.Abs(head.Y - tail.Y);

        if (diffX <= 1 && diffY <= 1)
        {
            return tail;
        }
        if (diffX > 1 && diffY == 0)
        {
            if (head.X > tail.X)
            {
                tail.X++;
            }
            else
            {
                tail.X--;
            }
            return tail;
        }
        if (diffY > 1 && diffX == 0)
        {
            if (head.Y > tail.Y)
            {
                tail.Y++;
            }
            else
            {
                tail.Y--;
            }

            return tail;
        }

        if (head.Y > tail.Y)
        {
            tail.Y++;
        }
        else
        {
            tail.Y--;
        }
        if (head.X > tail.X)
        {
            tail.X++;
        }
        else
        {
            tail.X--;
        }
        return tail;
    }
    
    private class Instruction
    {
        public Direction Direction { get; }
        public int Count { get; }
        
        public Instruction(string line)
        {
            var split = line.Split();
            Direction = split[0] switch
            {
                "U" => Direction.Up,
                "D" => Direction.Down,
                "L" => Direction.Left,
                "R" => Direction.Right,
                _ => throw new ArgumentOutOfRangeException()
            };
            Count = int.Parse(split[1]);
        }
    }
}