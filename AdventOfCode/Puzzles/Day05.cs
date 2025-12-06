namespace AdventOfCode.Puzzles;

public class Day05 : IDailyPuzzle
{
    public long First(string[] input)
    {
        var freshRanges = input.TakeWhile(it => it.Length > 0)
            .Select(it => it.Split('-'))
            .Select(it => (long.Parse(it[0]), long.Parse(it[1])))
            .ToArray();

        var ingredientIds = input[(freshRanges.Length + 1)..].Select(long.Parse).ToArray();
        return ingredientIds.Count(id => freshRanges.Any(range => id >= range.Item1 && id <= range.Item2));
    }

    public long Second(string[] input)
    {
        var freshRanges = input.TakeWhile(it => it.Length > 0)
            .Select(it => it.Split('-'))
            .Select(it => (long.Parse(it[0]), long.Parse(it[1])))
            .ToArray();

        for (var i = 0; i < freshRanges.Length; i++)
        {
            var range = freshRanges[i];

            for (var j = 0; j < freshRanges.Length; j++)
            {
                if (i == j)
                    continue;

                var otherRange = freshRanges[j];
                if (IsInRange(range.Item1, otherRange))
                    range.Item1 = otherRange.Item2 + 1;
            }

            freshRanges[i] = range;
        }

        return freshRanges.Select(Length).Sum();

        bool IsInRange(long x, (long, long) range)
        {
            return IsValidRange(range) && x >= range.Item1 && x <= range.Item2;
        }

        long Length((long, long) range)
        {
            if (!IsValidRange(range))
                return 0;

            return range.Item2 - range.Item1 + 1;
        }

        bool IsValidRange((long, long) range)
        {
            return range.Item1 <= range.Item2;
        }
    }
}