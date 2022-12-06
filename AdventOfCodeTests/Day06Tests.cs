using AdventOfCode._2022;

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
            
            var result = sut.RunPart1(input);
            
            Assert.That(result, Is.EqualTo(expected));
        }
    
        [Test]
        public void TestPart1_Solution()
        {
            var sut = new Day06();
            var input = sut.GetInput();
            
            var result = sut.RunPart1(input);
            
            Assert.That(result, Is.EqualTo(1300));
        }
        
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void TestPart2(string input, int expected)
        {
            var sut = new Day06();
            
            var result = sut.RunPart2(input);
            
            Assert.That(result, Is.EqualTo(expected));
        }
    
        [Test]
        public void TestPart2_Solution()
        {
            var sut = new Day06();
            var input = sut.GetInput();
            
            var result = sut.RunPart2(input);
            
            Assert.That(result, Is.EqualTo(3986));
        }
}