namespace AdventOfCode;

public abstract class Solution<TInput, TResult> where TInput: class
{
    public abstract TResult Part1();
    public abstract TResult Part2();
    
    protected readonly TInput Input;

    protected Solution()
    {
        var type = GetType();
        var year = type.Namespace[^4..];
        var day = int.Parse(type.Name[3..]);

        var baseDir = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName);
        var filename = Path.Combine(baseDir, year, "inputs", $"{day:00}.txt");

        if (!File.Exists(filename))
        {
            var url = $"https://adventofcode.com/{year}/day/{day}/input";
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", File.ReadAllText(Path.Combine(baseDir, "config")));
            var cont = client.GetStringAsync(url).Result;

            new FileInfo(filename).Directory.Create();
            File.WriteAllText(filename, cont.Trim());
        }
        
        Input = (TInput)ParseInput(filename);
    }

    private static object ParseInput(string filename)
    {
        if (typeof(TInput) == typeof(string))
        {
            return File.ReadAllText(filename);
        }
        if(typeof(TInput) == typeof(IEnumerable<string>))
        {
            return File.ReadLines(filename);
        }

        throw new ArgumentException($"No parser found for type {typeof(TInput)}");
    }
}