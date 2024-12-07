string[] inputs = File.ReadAllLines("input.txt");

char[] operations = { '+', '*', '|' };

Console.WriteLine($"Part1: " + Calculate(inputs, ['+', '*']));
Console.WriteLine($"Part2: " + Calculate(inputs, ['+', '*', '|']));

static long Calculate(string[] inputs, char[] operations)
{
    long sum = 0;
    foreach (string input in inputs)
    {
        var tmp = input.Split(':', StringSplitOptions.TrimEntries);

        long expected = long.Parse(tmp[0]);
        long[] values = tmp[1].Split(" ").Select(n => long.Parse(n)).ToArray();

        List<string> ops = GeneratePermutations(operations, values.Length - 1);

        foreach (string op in ops)
        {
            if (DoMath(values, op.ToCharArray(), false) == expected)
            {
                sum += expected;
                break;
            }
        }
    }

    return sum;
}


static List<string> GeneratePermutations(char[] characters, int length)
{
    var results = new List<string>();
    GeneratePermutationsRecursive(characters, "", length, results);
    return results;
}

static void GeneratePermutationsRecursive(char[] characters, string current, int length, List<string> results)
{
    if (current.Length == length)
    {
        results.Add(current);
        return;
    }

    foreach (var ch in characters)
        GeneratePermutationsRecursive(characters, current + ch, length, results);
}

static long DoMath(long[] numbers, char[] ops, bool reverse)
{
    long total = numbers[0];

    for (int i = 0; i < numbers.Length - 1; i++)
    {
        int x = reverse ? numbers.Length - 2 - i : i;
        switch (ops[x])
        {
            case '+':
                total = total + numbers[i + 1];
                break;
            case '*':
                total = total * numbers[i + 1];
                break;
            case '|':
                total = long.Parse(total.ToString() + numbers[i + 1].ToString());
                break;
            default:
                break;
        }
    }

    return total;
}