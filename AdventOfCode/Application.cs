using AdventOfCode.Puzzles;

namespace AdventOfCode;

public class Application
{
    private static readonly List<IDailyPuzzle> Puzzles = [new Day01()];

    public static void Main(string[] args)
    {
        Puzzles.ForEach(Run);
    }

    private static void Run(IDailyPuzzle puzzle)
    {
        var name = puzzle.GetType().Name[^2..];
        Console.WriteLine("Day01 - 1: " + puzzle.FirstExercise(File.ReadAllLines($"{name}_1.txt")));
        Console.WriteLine("Day01 - 2: " + puzzle.SecondExercise(File.ReadAllLines($"{name}_2.txt")));
        Console.WriteLine("");
    }
}