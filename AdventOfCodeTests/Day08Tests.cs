namespace AdventOfCodeTests;

public class Day08Tests: AoCTest<Day08, int>
{
    private readonly IEnumerable<string> _input = @"30373
25512
65332
33549
35390".ToEnumerable();
    
    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, 21);
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, 8);
    }
    
    [TestCase(1681)]
    public override void TestPart1_Solution(int value)
    {
        VerifyPart1(value);
    }

    [TestCase(201684)]
    public override void TestPart2_Solution(int value)
    {
        VerifyPart2(value);
    }
}