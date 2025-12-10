using System.IO;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day08))]
public class Day08Test
{
    private readonly Day08 _program = new();

    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("08.txt");
        Assert.AreEqual(40, _program.First(input));
    }

    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("08.txt");
        Assert.AreEqual(25272, _program.Second(input));
    }
}