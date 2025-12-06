namespace AdventOfCode.Puzzles;

public class Day04 : IDailyPuzzle
{
    private const char PaperRoll = '@';
    private const char Empty = '.';

    private class Map(char[][] content)
    {

        public static Map From(string[] strings)
        {
            return new Map(strings.Select(it => it.ToArray()).ToArray());
        }
        
        private readonly (int, int)[] _offsets =
        [
            (-1, -1), (-1, 0), (-1, 1),
            (0, -1), (0, 1), // skip (0, 0)
            (1, -1), (1, 0), (1, 1)
        ];

        public int CountAccessiblePaperRolls()
        {
            var accessiblePaperRolls = 0;
            for (var i = 0; i < content.Length; i++)
            {
                for (var j = 0; j < content[i].Length; j++)
                {
                    if (content[i][j] == Empty)
                        continue;

                    var adjacentRolls = _offsets.Count(offset => IsPaperRoll(offset, i, j));
                    if (adjacentRolls < 4)
                        accessiblePaperRolls++;
                }
            }

            return accessiblePaperRolls;
        }
        
        public int RemoveAccessiblePaperRolls()
        {
            var accessiblePaperRolls = 0;
            for (var i = 0; i < content.Length; i++)
            {
                for (var j = 0; j < content[i].Length; j++)
                {
                    if (content[i][j] == Empty)
                        continue;

                    var adjacentRolls = _offsets.Count(offset => IsPaperRoll(offset, i, j));
                    if (adjacentRolls >= 4) 
                        continue;
                    
                    accessiblePaperRolls++;
                    content[i][j] = Empty;
                }
            }

            return accessiblePaperRolls;
        }
        
        private bool IsPaperRoll((int, int) pos, int i, int j)
        {
            var row = i + pos.Item1;
            var col = j + pos.Item2;
            return IsInBounds(row, col) && content[row][col] == PaperRoll;
        }

        private bool IsInBounds(int row, int col) =>
            row >= 0 && row < content.Length && col >= 0 && col < content[row].Length;
        
    }
    
    public long First(string[] input)
    {
        var map = Map.From(input);
        return map.CountAccessiblePaperRolls();
    }

    public long Second(string[] input)
    {
        var map = Map.From(input);
        var totalRemovedPaperRolls = 0;
        
        int localRemovedPaperRolls;
        do
        {
            localRemovedPaperRolls = map.RemoveAccessiblePaperRolls();
            totalRemovedPaperRolls += localRemovedPaperRolls;
        } while (localRemovedPaperRolls > 0);

        return totalRemovedPaperRolls;
    }
}