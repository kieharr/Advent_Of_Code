namespace AdventOfCodeTests;

public class Day01Tests
{
    private readonly IEnumerable<string> _input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        var sut = new Day01();
        
        var result = sut.Part1(_input);
        
        Assert.That(result, Is.EqualTo(24_000));
    }

    [Test]
    public void TestPart2()
    {
        var sut = new Day01();
        
        var result = sut.Part2(_input);
        
        Assert.That(result, Is.EqualTo(45_000));
    }
    
    [Test]
    public void TestPart1_Solution()
    {
        Assert.That(new Day01().Part1(), Is.EqualTo(69_177));
    }

    [Test]
    public void TestPart2_Solution()
    {
        Assert.That(new Day01().Part2(), Is.EqualTo(207_456));
    }
}
