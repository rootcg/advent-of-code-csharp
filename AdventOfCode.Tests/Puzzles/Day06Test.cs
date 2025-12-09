using System.IO;
using System.Linq;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day06))]
public class Day06Test
{

    private readonly Day06 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("06.txt");
        Assert.AreEqual(4277556, _program.First(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("06.txt");
        Assert.AreEqual(3263827, _program.Second(input));
    }
}