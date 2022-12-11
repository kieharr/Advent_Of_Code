namespace AdventOfCodeTests;

public class Day03Tests: AoCTest<Day03>
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
        VerifyPart1(_input, "157");
    }

    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "70");
    }

    [TestCase("8109")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("2738")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}