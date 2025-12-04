using System.IO;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace AdventOfCode.Tests.Day01;

[TestClass]
[TestSubject(typeof(AdventOfCode.Day01.Day01))]
public class Day01Test
{

    private readonly AdventOfCode.Day01.Day01 _program = new();
    
    [TestMethod]
    public void first_exercise_example()
    {
        var input = File.ReadAllLines("Day01/input-1-example.txt");
        Assert.AreEqual(3, _program.FirstExercise(input));
    }
}