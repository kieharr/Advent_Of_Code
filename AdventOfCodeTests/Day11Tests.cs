namespace AdventOfCodeTests;

public class Day11Tests: AoCTest<Day11>
{
    private readonly IEnumerable<string> _input = @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1".ToEnumerable();

    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, "10605");
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, "2713310158");
    }

    [TestCase("99840")]
    public override void TestPart1_Solution(string value)
    {
        VerifyPart1(value);
    }

    [TestCase("20683044837")]
    public override void TestPart2_Solution(string value)
    {
        VerifyPart2(value);
    }
}