namespace AdventOfCode.Puzzles;

public class Day02 : IDailyPuzzle
{
    private readonly record struct Range(long First, long Last)
    {
        public static Range From(string str)
        {
            var ids = str.Split('-');
            return new Range(long.Parse(ids[0]), long.Parse(ids[1]));
        }

        public IEnumerable<long> Iterate()
        {
            var values = new List<long>();
            
            for (var i = First; i <= Last; i++)
                values.Add(i);

            return values;
        }
    }

    public long First(string[] input)
    {
        var ranges = input[0].Split(',').Select(Range.From);
        return ranges.SelectMany(it => it.Iterate().Where(IsInvalidId)).Sum();

        bool IsInvalidId(long id)
        {
            var strId = id.ToString();
            return strId.Length % 2 == 0 && strId[(strId.Length / 2)..].Equals(strId[..(strId.Length / 2)]);
        }
    }

    public long Second(string[] input)
    {
        var ranges = input[0].Split(',').Select(Range.From);
        return ranges.SelectMany(it => it.Iterate().Where(IsInvalidId)).Sum();

        bool IsInvalidId(long id)
        {
            var strId = id.ToString();

            for (var sequenceSize = 1; sequenceSize <= strId.Length / 2; sequenceSize++)
            {
                var sequence = strId[..sequenceSize];
                if (strId.Chunk(sequenceSize).All(it => it.SequenceEqual(sequence)))
                    return true;
            }
            
            return false;
        }
    }
}