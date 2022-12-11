using System.Text;

namespace AdventOfCode._2022;

public class Day10: Solution
{
    private struct Instruction
    {
        public int Cycles { get; set; }
        public int Value { get; set; }
    }

    private Instruction Parse(string input)
    {
        if (input.StartsWith('a'))
        {
            return new Instruction
            {
                Cycles = 2,
                Value = int.Parse(input[5..])
            };
        }

        return new Instruction {Cycles = 1};
    }
    
    public override string Part1(IEnumerable<string> input)
    {
        var register = 1;
        var cycle = 1;
        var result = 0;

        foreach (var instruction in input.Select(Parse))
        {
            for (int i = 0; i < instruction.Cycles; i++)
            {
                if (IsInteresting(cycle))
                {
                    result += cycle * register;
                }

                cycle++;
            }

            register += instruction.Value;
        }
        
        return result.ToString();
    }

    private bool IsInteresting(int i) => (i - 20) % 40 == 0;

    public override string Part2(IEnumerable<string> input)
    {
        var spritePosition = 1;
        var cycle = 0;

        var column = 0;
        var sb = new StringBuilder();

        foreach (var instruction in input.Select(Parse))
        {
            for (int i = 0; i < instruction.Cycles; i++)
            {
                if (cycle % 40 == 0 && cycle !=0)
                {
                    column = 0;
                    sb.Append(Environment.NewLine);
                }

                sb.Append(Math.Abs(spritePosition - column) <= 1 ? '#' : '.');

                column++;
                cycle++;
            }

            spritePosition += instruction.Value;
        }
        return sb.ToString();
    }
}