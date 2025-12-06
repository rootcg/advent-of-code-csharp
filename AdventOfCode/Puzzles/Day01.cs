namespace AdventOfCode.Puzzles;

public class Day01 : IDailyPuzzle
{
    private class Dial
    {
        private const int Min = 0;
        private const int Max = 99;

        public int Value = 50;

        public int Add(int n)
        {
            var zeroPasses = 0;
            
            for (var i = 0; i < n; i++)
            {
                Value++;

                if (Value > Max)
                {
                    Value = 0;
                    zeroPasses++;
                }
            }

            return zeroPasses;
        }

        public int Sub(int n)
        {
            var zeroPasses = 0;
            
            for (var i = 0; i < n; i++)
            {
                Value--;

                if (Value == 0)
                    zeroPasses++;
                
                if (Value < Min)
                    Value = 99;
            }
            
            return zeroPasses;
        }
    }
    
    public long First(string[] input)
    {
        var rotationsEndingOnZero = 0;
        
        var dial = new Dial();
        foreach (var action in input)
        {
            var direction = action[0];
            var steps = int.Parse(action[1..]);
            
            if (direction == 'R')
                dial.Add(steps);
            else
                dial.Sub(steps);
            
            if (dial.Value == 0) 
                rotationsEndingOnZero++;
        }

        return rotationsEndingOnZero;
    }
    
    public long Second(string[] input)
    {
        var zeroPasses = 0;
        
        var dial = new Dial();
        foreach (var action in input)
        {
            var direction = action[0];
            var steps = int.Parse(action[1..]);
            
            if (direction == 'R')
                zeroPasses += dial.Add(steps);
            else
                zeroPasses += dial.Sub(steps);
        }

        return zeroPasses;
    }
}