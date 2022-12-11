namespace AdventOfCode._2022;

public class Day07: Solution
{
    private static Node GetStructure(IEnumerable<string> input)
    {
        Node root = new Directory("", null);
        var current = root;

        foreach (var line in input)
        {
            switch (line)
            {
                case "$ cd /" or "$ ls":
                    break;
                case "$ cd ..":
                    current = current?.Parent;
                    break;
                default:
                {
                    if (line.StartsWith("$ cd"))
                    {
                        current = current?.Children.First(x => x.Name == line[5..]);
                    }
                    else if (line.StartsWith("dir"))
                    {
                        current?.Children.Add(new Directory(line[4..], current));
                    }
                    else
                    {
                        var split = line.Split(' ');
                        current?.Children.Add(new File(split[1], current, long.Parse(split[0])));
                    }
                    break;
                }
            }
        }
        return root;
    }
    
    public override string Part1(IEnumerable<string> input)
    {
        var root = GetStructure(input);

        var sizes = new Dictionary<Node, long>();
        root.GetSize(sizes);

        return sizes.Where(x => x.Value <= 100000).Sum(x => x.Value).ToString();
    }

    public override string Part2(IEnumerable<string> input)
    {
        var root = GetStructure(input);

        var sizes = new Dictionary<Node, long>();
        var neededSpace = -(40_000_000 - root.GetSize(sizes));
        
        return sizes.Where(x => x.Value >= neededSpace).Min(x => x.Value).ToString();
    }
}

public abstract class Node
{
    protected Node(string name, Node? parent)
    {
        Name = name;
        Parent = parent;
    }
    
    public string Name { get; }

    public abstract long GetSize(Dictionary<Node, long> sizeDict);
    
    public Node? Parent { get; }
    public List<Node> Children { get; } = new ();
}

public class Directory : Node
{
    public override long GetSize(Dictionary<Node, long> sizeDict)
    {
        var size = Children.Sum(x => x.GetSize(sizeDict));
        sizeDict.Add(this, size);
        return size;
    }

    public Directory(string name, Node? parent) : base(name, parent) { }
}

public class File : Node
{
    private readonly long _size;
    
    public File(string name, Node? parent, long size) : base(name, parent)
    {
        _size = size;
    }

    public override long GetSize(Dictionary<Node, long> sizeDict)
    {
        return _size;
    }
}