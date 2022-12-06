namespace AdventOfCodeTests;

public class Day06Tests: AoCTest<Day06, int>
{
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void TestPart1(string input, int expected)
        {
            VerifyPart1(input.ToEnumerable(), expected);
        }
        
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void TestPart2(string input, int expected)
        {
            VerifyPart2(input.ToEnumerable(), expected);
        }
        
        [TestCase(1_300)]
        public override void TestPart1_Solution(int value)
        {
            VerifyPart1(value);
        }

        [TestCase(3_986)]
        public override void TestPart2_Solution(int value)
        {
            VerifyPart2(value);
        }
}