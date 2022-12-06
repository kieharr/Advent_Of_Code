using System.Text.RegularExpressions;

namespace AdventOfCode._2022;

public class Day05: Solution<string>
{
    private readonly Regex _moveRegex = new(@"move (?'move'\d+) from (?'from'\d+) to (?'to'\d+)");

    public override string Part1(IEnumerable<string> input)
    {
        Dictionary<int, Stack<char>> stacks = new();
        Stack<string> boxLines = new();

        using var enumerator = input.GetEnumerator();
        enumerator.MoveNext();
        
        while (enumerator.Current.Contains('['))
        {
            boxLines.Push(enumerator.Current);
            enumerator.MoveNext();
        }

        foreach (var boxLine in boxLines)
        {
            AddBoxLineToStacks(boxLine, stacks);
        }
        
        enumerator.MoveNext();
        while (enumerator.MoveNext())
        {
            var instruction = ParseInstruction(enumerator.Current);
            for (var i = 0; i < instruction.Count; i++)
            {
                stacks[instruction.To].Push(stacks[instruction.From].Pop());
            }
        }

        return new string(stacks.Select(x => x.Value.Pop()).ToArray());
    }
    
    public override string Part2(IEnumerable<string> input)
    {
        Dictionary<int, Stack<char>> stacks = new();
        Stack<string> boxes = new();

        var enumerator = input.GetEnumerator();
        enumerator.MoveNext();
        
        while (enumerator.Current.Contains('['))
        {
            boxes.Push(enumerator.Current);
            enumerator.MoveNext();
        }

        foreach (var box in boxes)
        {
            AddBoxLineToStacks(box, stacks);
        }
        
        enumerator.MoveNext();
        while (enumerator.MoveNext())
        {
            var instruction = ParseInstruction(enumerator.Current);
            
            var stack = new Stack<char>();
            for (var i = 0; i < instruction.Count; i++)
            {
                stack.Push(stacks[instruction.From].Pop());
            }
            
            foreach (var c in stack)
            {
                stacks[instruction.To].Push(c);
            }
        }

        return new string(stacks.Select(x => x.Value.Pop()).ToArray());
    }
    
    private void AddBoxLineToStacks(string boxLine, Dictionary<int, Stack<char>> stacks)
    {
        var i = 0;            
        foreach (var chunk in boxLine.Chunk(4).ToList())
        {
            i++;
            if (!chunk.Contains('[')) continue;
            
            if (stacks.TryGetValue(i, out var stack))
            {
                stack.Push(chunk[1]);
            }
            else
            {
                stacks.Add(i, new Stack<char>(new []{ chunk[1] }));
            }
        }
    }
    
    private Instruction ParseInstruction(string inputLine)
    {
        var match = _moveRegex.Match(inputLine);
        var count = int.Parse(match.Groups["move"].Captures.First().Value);
        var from = int.Parse(match.Groups["from"].Captures.First().Value);
        var to = int.Parse(match.Groups["to"].Captures.First().Value);
        return new Instruction(count, from, to);
    }
    
    private record struct Instruction(int Count, int From, int To);
}