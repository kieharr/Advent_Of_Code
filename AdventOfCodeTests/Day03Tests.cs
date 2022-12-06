namespace AdventOfCodeTests;

public class Day03Tests: AoCTest<Day03, int>
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
        VerifyPart1(_input, 157);
    }

    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, 70);
    }

    [TestCase(8_109)]
    public override void TestPart1_Solution(int value)
    {
        VerifyPart1(value);
    }

    [TestCase(2_738)]
    public override void TestPart2_Solution(int value)
    {
        VerifyPart2(value);
    }
}