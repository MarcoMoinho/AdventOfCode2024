string[] inputs = File.ReadAllLines("input.txt");

List<int> left = [];
List<int> right = [];

foreach (string line in inputs)
{
    string[] tmp = line.Split("   ");
    left.Add(int.Parse(tmp[0]));
    right.Add(int.Parse(tmp[1]));
}

left.Sort();
right.Sort();

int part1 = 0;
for (int i = 0; i < left.Count; i++)
    part1 += Math.Abs(left[i] - right[i]);

Console.WriteLine($"Part 1: {part1}");

int part2 = 0;
left.ForEach(n => part2 += n * right.Count(x => x == n));

Console.WriteLine($"Part 2: {part2}");