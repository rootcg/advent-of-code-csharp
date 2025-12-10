using System.Collections;

namespace AdventOfCode.Puzzles;

public class Day08 : IDailyPuzzle
{
    private readonly record struct JunctionBox(int X, int Y, int Z)
    {
        public override string ToString()
        {
            return $"({X},{Y},{Z})";
        }
    };

    public long First(string[] input)
    {
        var boxes = input.Select(it => it.Split(','))
            .Select(it => new JunctionBox(int.Parse(it[0]), int.Parse(it[1]), int.Parse(it[2])))
            .ToArray();

        var pairsPerDistance = new List<(double distance, JunctionBox A, JunctionBox B)>();
        for (var i = 0; i < boxes.Length - 1; i++)
        {
            var a = boxes[i];
            for (var j = i + 1; j < boxes.Length; j++)
            {
                var b = boxes[j];
                var distance = EuclideanDistance(a, b);
                pairsPerDistance.Add((distance, a, b));
            }
        }

        pairsPerDistance.Sort((a, b) => a.distance.CompareTo(b.distance));

        var circuits = boxes.Select(it => new HashSet<JunctionBox> { it }).ToList();
        foreach (var connection in pairsPerDistance.Take(3)) // 3 for example and 1000 for the real input
        {
            var circuitA = circuits.Find(it => it.Contains(connection.A));
            var circuitB = circuits.Find(it => it.Contains(connection.B));

            // merge circuits
            if (circuitA != null && circuitB != null && circuitA != circuitB)
            {
                circuits.Remove(circuitB);
                foreach (var junctionBox in circuitB)
                {
                    circuitA.Add(junctionBox);
                }

                continue;
            }

            // add B to A
            if (circuitA != null && circuitB == null)
            {
                circuitA.Add(connection.B);
                continue;
            }

            // add A to B
            if (circuitA == null && circuitB != null)
            {
                circuitB.Add(connection.A);
            }
        }

        return circuits.Select(it => it.Count).OrderDescending().Take(3).Aggregate((a, b) => a * b);
    }

    public long Second(string[] input)
    {
        var boxes = input.Select(it => it.Split(','))
            .Select(it => new JunctionBox(int.Parse(it[0]), int.Parse(it[1]), int.Parse(it[2])))
            .ToArray();

        var pairsPerDistance = new List<(double distance, JunctionBox A, JunctionBox B)>();
        for (var i = 0; i < boxes.Length - 1; i++)
        {
            var a = boxes[i];
            for (var j = i + 1; j < boxes.Length; j++)
            {
                var b = boxes[j];
                var distance = EuclideanDistance(a, b);
                pairsPerDistance.Add((distance, a, b));
            }
        }

        pairsPerDistance.Sort((a, b) => a.distance.CompareTo(b.distance));

        var circuits = boxes.Select(it => new HashSet<JunctionBox> { it }).ToList();
        foreach (var connection in pairsPerDistance)
        {
            var circuitA = circuits.Find(it => it.Contains(connection.A));
            var circuitB = circuits.Find(it => it.Contains(connection.B));

            // merge circuits
            if (circuitA != null && circuitB != null && circuitA != circuitB)
            {
                circuits.Remove(circuitB);
                foreach (var junctionBox in circuitB)
                {
                    circuitA.Add(junctionBox);
                }

                if (circuits.Count == 1)
                {
                    return connection.A.X * connection.B.X;
                }
                
                continue;
            }

            // add B to A
            if (circuitA != null && circuitB == null)
            {
                circuitA.Add(connection.B);
                continue;
            }

            // add A to B
            if (circuitA == null && circuitB != null)
            {
                circuitB.Add(connection.A);
            }
        }


        return circuits.Select(it => it.Count).OrderDescending().Take(3).Aggregate((a, b) => a * b);
    }

    private double EuclideanDistance(JunctionBox a, JunctionBox b)
    {
        return Math.Sqrt(MathF.Pow(a.X - b.X, 2) + MathF.Pow(a.Y - b.Y, 2) + MathF.Pow(a.Z - b.Z, 2));
    }
}