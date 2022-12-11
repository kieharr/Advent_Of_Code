namespace AdventOfCodeTests;

public class Day02Tests: AoCTest<Day02>
{
    private readonly IEnumerable<string> _input = @"A Y
B X
C Z".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, "15");
    }

    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "12");
    }

    [TestCase("11150")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("8295")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}