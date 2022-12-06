using AdventOfCode;

namespace AdventOfCodeTests;

public abstract class AoCTest<TSolution, T> where TSolution : Solution<T>, new()
{
    private readonly TSolution _sut;
    protected AoCTest()
    {
        _sut = new TSolution();
    }
    public abstract void TestPart1_Solution(T value);
    public abstract void TestPart2_Solution(T value);
    
    protected void VerifyPart1(IEnumerable<string> input, T value)
    {
        Assert.That(_sut.Part1(input), Is.EqualTo(value));
    }
    protected void VerifyPart2(IEnumerable<string> input, T value)
    {
        Assert.That(_sut.Part2(input), Is.EqualTo(value));
    }
    
    protected void VerifyPart1(T value)
    {
        Assert.That(_sut.Part1(), Is.EqualTo(value));
    }
    protected void VerifyPart2(T value)
    {
        Assert.That(_sut.Part2(), Is.EqualTo(value));
    }
}