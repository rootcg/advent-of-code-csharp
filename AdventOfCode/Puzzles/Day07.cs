namespace AdventOfCode.Puzzles;

public class Day07 : IDailyPuzzle
{
    private class Beam(int row, int col)
    {
        public int Row = row;
        public readonly int Col = col;

        public void Move()
        {
            Row += 1;
        }
    }
    
    private class QuantumBeam(int row, int col, long timelines) : Beam(row, col)
    {
        public long Timelines = timelines;

        public void AddTimelines(long n)
        {
            Timelines += n;
        }
    }

    public long First(string[] input)
    {
        var splitCount = 0;
        
        var beams = new List<Beam> { new(0, input[0].IndexOf('S')) };
        for (var i = 0; i < input.Length - 1; i++)
        {
            var j = 0;
            var beamsCounter = beams.Count;
            var beamsChecked = 0;
            while (j < beams.Count && beamsChecked < beamsCounter)
            {
                var beam = beams[j];
                if (input[beam.Row + 1][beam.Col] == '^')
                {
                    beams.RemoveAt(j);
                    AddBeam(new Beam(beam.Row + 1, beam.Col - 1));
                    AddBeam(new Beam(beam.Row + 1, beam.Col + 1));
                    splitCount++;
                }
                else
                {
                    beam.Move();
                    j++;
                }

                beamsChecked++;
            }
        }
        
        return splitCount;
        
        void AddBeam(Beam beam)
        {
            if (beams.Any(it => it.Col == beam.Col))
                return;
            
            beams.Add(beam);
        }
    }
    
    public long Second(string[] input)
    {
        var beams = new List<QuantumBeam> { new(0, input[0].IndexOf('S'), 1) };
        for (var i = 0; i < input.Length - 1; i++)
        {
            var j = 0;
            var beamsCounter = beams.Count;
            var beamsChecked = 0;
            while (j < beams.Count && beamsChecked < beamsCounter)
            {
                var beam = beams[j];
                if (input[beam.Row + 1][beam.Col] == '^')
                {
                    beams.RemoveAt(j);
                    AddBeam(new QuantumBeam(beam.Row + 1, beam.Col - 1, beam.Timelines));
                    AddBeam(new QuantumBeam(beam.Row + 1, beam.Col + 1, beam.Timelines));
                }
                else
                {
                    beam.Move();
                    j++;
                }

                beamsChecked++;
            }
        }

        return beams.Select(it => it.Timelines).Sum();

        void AddBeam(QuantumBeam beam)
        {
            var existingBeam = beams.Find(it => it.Col == beam.Col);
            if (existingBeam != null)
            {
                existingBeam.AddTimelines(beam.Timelines);
            }
            else
            {
                beams.Add(beam);   
            }
        }
    }
}