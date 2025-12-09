namespace AdventOfCode.Puzzles;

public class Day06 : IDailyPuzzle
{
    private class MathProblem(char operation)
    {
        private readonly List<long> _params = [];
        
        public void AddParam(long param) => _params.Add(param);

        public long Result()
        {
            var result = _params[0];
            
            for (var i = 1; i < _params.Count; i++)
                result = ApplyOperation(_params[i], result);

            return result;
        }

        private long ApplyOperation(long a, long b)
        {
            return operation switch {
                '+' => a + b,
                '*' => a * b,
                _ => throw new InvalidOperationException()
            };
        }
    }
    
    public long First(string[] input)
    {
        var problems = input[^1].Split(' ')
            .Select(it => it.Trim())
            .Where(it => it.Length > 0)
            .Select(char.Parse)
            .Select(it => new MathProblem(it))
            .ToList();
        
        for (var i = 0; i < input.Length - 1; i++)
        {
            var numbers = input[i].Split(' ')
                .Where(it => it.Trim().Length > 0)
                .Select(long.Parse)
                .ToList();

            for (var j = 0; j < numbers.Count; j++)
            {
                problems[j].AddParam(numbers[j]);
            }
        }

        return problems.Select(it => it.Result()).Sum();
    }

    public long Second(string[] input)
    {
        var problems = new List<MathProblem>();

        var numbersBuffer = new List<long>();
        var cols = input[0].Length;
        for (var i = cols - 1; i >= 0; i--)
        {
            var strNumber = "";
            for (var j = 0; j < input.Length - 1; j++)
            {
                if (char.IsNumber(input[j][i]))
                    strNumber += input[j][i];
            }
            numbersBuffer.Add(long.Parse(strNumber));

            var operation = input[^1][i];
            if (char.IsWhiteSpace(operation)) 
                continue;
            
            var problem = new MathProblem(operation);
            numbersBuffer.ForEach(it => problem.AddParam(it));
            numbersBuffer.Clear();
            problems.Add(problem);

            i--; // jump one extra column to the next problem
        }

        return problems.Select(it => it.Result()).Sum();
    }
}