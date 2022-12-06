namespace AdventOfCodeTests;

public class Day03Tests
{
    private readonly IEnumerable<string> _input = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        var sut = new Day03();
        
        var result = sut.Part1(_input);
        
        Assert.That(result, Is.EqualTo(157));
    }

    [Test]
    public void TestPart2()
    {
        var sut = new Day03();
        
        var result = sut.Part2(_input);
        
        Assert.That(result, Is.EqualTo(70));
    }
    
    [Test]
    public void TestPart1_Solution()
    {
        Assert.That(new Day03().Part1(), Is.EqualTo(8_109));
    }

    [Test]
    public void TestPart2_Solution()
    {
        Assert.That(new Day03().Part2(), Is.EqualTo(2_738));
    }
}