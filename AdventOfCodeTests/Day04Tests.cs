namespace AdventOfCodeTests;

public class Day04Tests: AoCTest<Day04, int>
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
        VerifyPart1(_input, 2);
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, 4);
    }

    [TestCase(305)]
    public override void TestPart1_Solution(int value)
    {
        VerifyPart1(value);
    }

    [TestCase(811)]
    public override void TestPart2_Solution(int value)
    {
        VerifyPart2(value);
    }
}