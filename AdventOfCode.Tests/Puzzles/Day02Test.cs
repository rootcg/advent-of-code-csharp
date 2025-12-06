using System.IO;
using System.Linq;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day02))]
public class Day02Test
{

    private readonly Day02 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("02.txt");
        Assert.AreEqual(1227775554, _program.First(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("02.txt");
        Assert.AreEqual(4174379265, _program.Second(input));
    }
}