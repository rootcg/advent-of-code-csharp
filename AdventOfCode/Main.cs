namespace AdventOfCode;

public class Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("Day01/input-1.txt");
            var program = new Day01.Day01();
            Console.WriteLine("Day01 - 1: " + program.FirstExercise(input));
            Console.WriteLine("Day01 - 2: " + program.SecondExercise(input));
        }
    }
}