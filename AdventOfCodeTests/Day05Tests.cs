namespace AdventOfCodeTests;

public class Day05Tests: AoCTest<Day05, string>
{
    private readonly IEnumerable<string> _input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, "CMZ");
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "MCD");
    }

    [TestCase("SHQWSRBDL")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("CDTQZHBRS")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}