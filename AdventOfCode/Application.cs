using AdventOfCode.Puzzles;

namespace AdventOfCode;

public class Application
{
    public static void Main(string[] args)
    {
        Run(new Day03());
    }

    private static void Run(IDailyPuzzle puzzle)
    {
        var name = puzzle.GetType().Name[^2..];
        Console.WriteLine($"Day {name}");
        Console.WriteLine("First Puzzle: " + puzzle.First(File.ReadAllLines($"{name}.txt")));
        Console.WriteLine("Second Puzzle: " + puzzle.Second(File.ReadAllLines($"{name}.txt")));
        Console.WriteLine("");
    }
}