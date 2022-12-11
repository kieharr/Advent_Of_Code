namespace AdventOfCode;

public abstract class Solution
{
    public abstract string Part1(IEnumerable<string> input);
    public abstract string Part2(IEnumerable<string> input);

    public string Part1()
    {
        return Part1(File.ReadLines(_filename));
    }

    public string Part2()
    {
        return Part2(File.ReadLines(_filename));
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
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", File.ReadAllText(Path.Combine(baseDir, "config")));
            var content = client.GetStringAsync($"https://adventofcode.com/{year}/day/{day}/input").Result;

            new FileInfo(_filename).Directory.Create();
            File.WriteAllText(_filename, content);
        }
    }
}