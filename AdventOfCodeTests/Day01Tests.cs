namespace AdventOfCodeTests;

public class Day01Tests: AoCTest<Day01>
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
        VerifyPart1(_input, "24000");
    }

    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "45000");
    }

    [TestCase("69177")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("207456")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}
