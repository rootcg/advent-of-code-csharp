using System.IO;
using System.Linq;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day03))]
public class Day03Test
{

    private readonly Day03 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("03.txt");
        Assert.AreEqual(357, _program.First(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("03.txt");
        Assert.AreEqual(3121910778619, _program.Second(input));
    }
}