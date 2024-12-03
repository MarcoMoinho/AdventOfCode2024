using System.Text.RegularExpressions;

string[] inputs = File.ReadAllLines("input.txt");

Regex regex = new(@"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");

int part1 = 0;
int part2 = 0;
bool enabled = true;

foreach (var input in inputs)
{
    MatchCollection matches = regex.Matches(input);

    foreach (Match match in matches)
    {
        if (match.Value == "do()")    { enabled = true; continue; }
        if (match.Value == "don't()") { enabled = false; continue; }

        part1 += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
        if (enabled) part2 += int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value);
    }
}

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");