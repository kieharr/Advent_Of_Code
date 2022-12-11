namespace AdventOfCodeTests;

public class Day09Tests: AoCTest<Day09>
{
    private readonly IEnumerable<string> _input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".ToEnumerable();

    private readonly IEnumerable<string> _input2 = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, "13");
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "1");
    }

    [Test]
    public void TestPart2Big()
    {
        VerifyPart2(_input2, "36");
    }
    
    [TestCase("6642")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("2765")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}