namespace AdventOfCodeTests;

public class Day05Tests
{
    private readonly IEnumerable<string> _input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        var sut = new Day05();
        
        var result = sut.Part1(_input);
        
        Assert.That(result, Is.EqualTo("CMZ"));
    }
    
    [Test]
    public void TestPart2()
    {
        var sut = new Day05();
        
        var result = sut.Part2(_input);
        
        Assert.That(result, Is.EqualTo("MCD"));
    }
    
    [Test]
    public void TestPart1_Solution()
    {
        Assert.That(new Day05().Part1(), Is.EqualTo("SHQWSRBDL"));
    }

    [Test]
    public void TestPart2_Solution()
    {
        Assert.That(new Day05().Part2(), Is.EqualTo("CDTQZHBRS"));
    }
}