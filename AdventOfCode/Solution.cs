using System.Diagnostics;

namespace AdventOfCode;

public abstract class Solution<TInput, TResult> where TInput: class
{
    public TResult RunPart1(TInput? input = null)
    {
        var stopwatch = Stopwatch.StartNew();
        input ??= GetInput();
        var result = Part1(input);
        stopwatch.Stop();
        
        Console.WriteLine("Part 1:");
        Console.WriteLine(result);
        Console.WriteLine($"In {stopwatch.ElapsedMilliseconds} ms");
        return result;
    }
    
    public TResult RunPart2(TInput? input = null)
    {
        var stopwatch = Stopwatch.StartNew();
        input ??= GetInput();
        var result = Part2(input);
        stopwatch.Stop();

        Console.WriteLine("Part 2:");
        Console.WriteLine(result);
        Console.WriteLine($"In {stopwatch.ElapsedMilliseconds} ms");
        return result;
    }
    
    protected abstract TResult Part1(TInput input);
    protected abstract TResult Part2(TInput input);
    
    private readonly string _filename;

    protected Solution()
    {
        var type = GetType();
        var year = type.Namespace[^4..];
        var day = int.Parse(type.Name[3..]);

        var baseDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
        _filename = Path.Combine(baseDir, "AdventOfCode", year, "inputs", $"{day:00}.txt");

        if (!File.Exists(_filename))
        {
            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", File.ReadAllText(Path.Combine(baseDir, "config")));
            var cont = client.GetStringAsync(url).Result;

            new FileInfo(_filename).Directory.Create();
            File.WriteAllText(_filename, cont);
        }
    }

    public TInput GetInput()
    {
        if (typeof(TInput) == typeof(string))
        {
            return (TInput)(object)File.ReadAllText(_filename);
        }
        if(typeof(TInput) == typeof(IEnumerable<string>))
        {
            return (TInput)File.ReadLines(_filename);
        }

        throw new ArgumentException($"No parser found for type {typeof(TInput)}");
    }
    
    // private static object ParseInput(string filename)
    // {
    //     if (typeof(TInput) == typeof(string))
    //     {
    //         return File.ReadAllText(filename);
    //     }
    //     if(typeof(TInput) == typeof(IEnumerable<string>))
    //     {
    //         return File.ReadLines(filename);
    //     }
    //
    //     throw new ArgumentException($"No parser found for type {typeof(TInput)}");
    // }
}