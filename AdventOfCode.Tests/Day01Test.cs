using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace AdventOfCode.Tests;

[TestClass]
[TestSubject(typeof(Day01))]
public class Day01Test
{

    private readonly Day01 _program = new();
    
    [TestMethod]
    public void Return_0()
    {
        Assert.AreEqual(1, _program.Run());
    }
}