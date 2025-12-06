namespace AdventOfCode.Puzzles;

public class Day03 : IDailyPuzzle
{
    public readonly record struct BatteryBank(int[] Batteries)
    {
        public static BatteryBank From(string str)
        {
            return new BatteryBank(str.Select(it => it - '0').ToArray());
        }

        public long MaxJoltage(int outputDigits)
        {
            long maxJoltage = 0;
            var digitsCount = 0;
            var startOffset = 0;
            var endOffset = Batteries.Length - outputDigits;
            
            while (digitsCount < outputDigits)
            {
                var max = 0;
                var maxIdx = 0;
                for (var i = startOffset; i <= endOffset && max < 9; i++)
                {
                    if (Batteries[i] <= max)
                        continue;

                    max = Batteries[i];
                    maxIdx = i;
                }

                digitsCount++;
                maxJoltage = maxJoltage * 10 + max;
                startOffset = maxIdx + 1;
                endOffset++;
            }

            return maxJoltage;
        }
    }

    public long First(string[] input)
    {
        var batteryBanks = input.Select(BatteryBank.From);
        return batteryBanks.Select(it => it.MaxJoltage(2)).Sum();
    }

    public long Second(string[] input)
    {
        var batteryBanks = input.Select(BatteryBank.From);
        return batteryBanks.Select(it => it.MaxJoltage(12)).Sum();
    }
}