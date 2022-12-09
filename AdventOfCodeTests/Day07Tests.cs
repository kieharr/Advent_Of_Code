using System.Diagnostics;

namespace AdventOfCodeTests;

public class Day07Tests: AoCTest<Day07, long>
{
    private readonly IEnumerable<string> _input = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k".ToEnumerable();
    
    [Test]
    public void TestPart1()
    {
        VerifyPart1(_input, 95437);
    }
    
    [Test]
    public void TestPart2()
    {
        VerifyPart2(_input, 24933642);
    }
    
    [TestCase(1391690)]
    public override void TestPart1_Solution(long value)
    {
        VerifyPart1(value);
    }

    [TestCase(5469168)]
    public override void TestPart2_Solution(long value)
    {
        VerifyPart2(value);
    }
}