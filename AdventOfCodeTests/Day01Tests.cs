using AdventOfCode._2022;

namespace AdventOfCodeTests;

public class Day01Tests
{
    private readonly string _input = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000".Replace(Environment.NewLine, "\n");

    [Test]
    public void TestPart1()
    {
        var sut = new Day01();
        
        var result = sut.RunPart1(_input);
        
        Assert.That(result, Is.EqualTo(24_000));
    }

    [Test]
    public void TestPart1_Solution()
    {
        var sut = new Day01();
        var input = sut.GetInput();
        
        var result = sut.RunPart1(input);
        
        Assert.That(result, Is.EqualTo(69_177));
    }
    
    [Test]
    public void TestPart2()
    {
        var sut = new Day01();
        
        var result = sut.RunPart2(_input);
        
        Assert.That(result, Is.EqualTo(45_000));
    }

    [Test]
    public void TestPart2_Solution()
    {
        var sut = new Day01();
        var input = sut.GetInput();
        
        var result = sut.RunPart2(input);
        
        Assert.That(result, Is.EqualTo(207_456));
    }
}
