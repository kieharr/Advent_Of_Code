namespace AdventOfCodeTests;

public class Day06Tests
{
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void TestPart1(string input, int expected)
        {
            var sut = new Day06();
            
            var result = sut.Part1(input.ToEnumerable());
            
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void TestPart2(string input, int expected)
        {
            var sut = new Day06();
            
            var result = sut.Part2(input.ToEnumerable());
            
            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void TestPart1_Solution()
        {
            Assert.That(new Day06().Part1(), Is.EqualTo(1300));
        }
    
        [Test]
        public void TestPart2_Solution()
        {
            Assert.That(new Day06().Part2(), Is.EqualTo(3986));
        }
}