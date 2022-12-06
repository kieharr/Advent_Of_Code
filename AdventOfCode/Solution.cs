using System.Diagnostics;

namespace AdventOfCode;

public abstract class Solution<TInput, TResult> where TInput: class
{
    public abstract TResult Part1(TInput input);
    public abstract TResult Part2(TInput input);

    public TResult Part1()
    {
        return Part1(GetInput());
    }

    public TResult Part2()
    {
        return Part2(GetInput());
    }
    
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

    private TInput GetInput()
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
}