using System.IO;
using System.Linq;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day05))]
public class Day05Test
{

    private readonly Day05 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("05.txt");
        Assert.AreEqual(3, _program.First(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("05.txt");
        Assert.AreEqual(14, _program.Second(input));
    }
}