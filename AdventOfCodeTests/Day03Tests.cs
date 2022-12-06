using AdventOfCode._2022;

namespace AdventOfCodeTests;

public class Day03Tests
{
    private readonly IEnumerable<string> _input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".Split(Environment.NewLine);

    [Test]
    public void TestPart1()
    {
        var sut = new Day03();
        
        var result = sut.RunPart1(_input);
        
        Assert.That(result, Is.EqualTo(157));
    }

    [Test]
    public void TestPart1_Solution()
    {
        var sut = new Day03();
        var input = sut.GetInput();
        
        var result = sut.RunPart1(input);
        
        Assert.That(result, Is.EqualTo(8_109));
    }
    
    [Test]
    public void TestPart2()
    {
        var sut = new Day03();
        
        var result = sut.RunPart2(_input);
        
        Assert.That(result, Is.EqualTo(70));
    }

    [Test]
    public void TestPart2_Solution()
    {
        var sut = new Day03();
        var input = sut.GetInput();
        
        var result = sut.RunPart2(input);
        
        Assert.That(result, Is.EqualTo(2_738));
    }
}