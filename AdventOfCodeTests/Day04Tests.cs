namespace AdventOfCodeTests;

public class Day04Tests
{
    private readonly IEnumerable<string> _input = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        var sut = new Day04();
        
        var result = sut.Part1(_input);
        
        Assert.That(result, Is.EqualTo(2));
    }
    
    [Test]
    public void TestPart2()
    {
        var sut = new Day04();
        
        var result = sut.Part2(_input);
        
        Assert.That(result, Is.EqualTo(4));
    }
    
    [Test]
    public void TestPart1_Solution()
    {
        Assert.That(new Day04().Part1(), Is.EqualTo(305));
    }

    [Test]
    public void TestPart2_Solution()
    {
        Assert.That(new Day04().Part2(), Is.EqualTo(811));
    }
}