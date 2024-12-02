string[] inputs = File.ReadAllLines("input.txt");


int part1Safe = 0;
int part2Safe = 0;

foreach (string line in inputs)
{
    List<int> reports = [];
    line.Split(' ').ToList().ForEach(r => reports.Add(int.Parse(r)));

    // part 1
    if (IsSafe(reports)) part1Safe++;

    // verify all possible combinations for part 2
    for (int i = 0; i < reports.Count; i++)
    {
        List<int> reportsDampened = new(reports);
        reportsDampened.RemoveAt(i);

        if (IsSafe(reportsDampened))
        {
            part2Safe++;
            break;
        }
    }
}

Console.WriteLine($"Part 1: {part1Safe}");
Console.WriteLine($"Part 2: {part2Safe}");


static bool IsSafe(List<int> values)
{
    bool increasing = false;

    increasing = values[1] > values[0];

    for (int i = 0; i < values.Count - 1; i++)
    {
        int diff = (values[i + 1] - values[i]) * (increasing ? 1 : -1);
        if (diff < 1 || diff > 3)
            return false;
    }

    return true;
}