using System.IO;
using AdventOfCode.Puzzles;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace AdventOfCode.Tests.Puzzles;

[TestClass]
[TestSubject(typeof(Day01))]
public class Day01Test
{

    private readonly Day01 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("01.txt");
        Assert.AreEqual(3, _program.FirstExercise(input));
    }
    
    [TestMethod]
    public void second_exercise_example()
    {
        var input = File.ReadAllLines("01.txt");
        Assert.AreEqual(6, _program.SecondExercise(input));
    }
}