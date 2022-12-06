namespace AdventOfCodeTests;

public class Day02Tests
{
    private readonly IEnumerable<string> _input = @"A Y
B X
C Z".Split(Environment.NewLine);

    [Test]
    public void TestPart1()
    {
        var sut = new Day02();
        
        var result = sut.Part1(_input);
        
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void TestPart2()
    {
        var sut = new Day02();
        
        var result = sut.Part2(_input);
        
        Assert.That(result, Is.EqualTo(12));
    }
    
    [Test]
    public void TestPart1_Solution()
    {
        Assert.That(new Day02().Part1(), Is.EqualTo(11_150));
    }

    [Test]
    public void TestPart2_Solution()
    {
        Assert.That(new Day02().Part2(), Is.EqualTo(8_295));
    }
}