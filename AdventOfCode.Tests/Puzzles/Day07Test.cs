using System.IO;
using System.Linq;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day07))]
public class Day07Test
{

    private readonly Day07 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("07.txt");
        Assert.AreEqual(21, _program.First(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("07.txt");
        Assert.AreEqual(40, _program.Second(input));
    }
}