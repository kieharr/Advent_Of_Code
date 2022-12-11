using AdventOfCode;

namespace AdventOfCodeTests;

public abstract class AoCTest<TSolution> where TSolution : Solution, new()
{
    private readonly TSolution _sut;
    protected AoCTest()
    {
        _sut = new TSolution();
    }
    public abstract void TestPart1_Solution(string value);
    public abstract void TestPart2_Solution(string value);
    
    protected void VerifyPart1(IEnumerable<string> input, string value)
    {
        Assert.That(_sut.Part1(input), Is.EqualTo(value));
    }
    protected void VerifyPart2(IEnumerable<string> input, string value)
    {
        Assert.That(_sut.Part2(input), Is.EqualTo(value));
    }
    
    protected void VerifyPart1(string value)
    {
        Assert.That(_sut.Part1(), Is.EqualTo(value));
    }
    protected void VerifyPart2(string value)
    {
        Assert.That(_sut.Part2(), Is.EqualTo(value));
    }
}