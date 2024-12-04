string[] inputs = File.ReadAllLines("input.txt");

int xMax = inputs[0].Length;
int yMax = inputs.Length;

// create a charmap of the whole input
char[,] map = new char[xMax, yMax];
for (int y = 0; y < yMax; y++)
    for (int x = 0; x < xMax; x++)
        map[x, y] = char.Parse(inputs[y].Substring(x, 1));

int part1 = 0;
int part2 = 0;

for (int y = 0; y < yMax; y++)
{
    for (int x = 0; x < xMax; x++)
    {
        // Part 2 X-MAS
        if (x >= 1 && y >= 1 & x < xMax - 1 && y < yMax - 1 && map[x, y] == 'A')
            if (IsMAS(map[x - 1, y - 1], map[x + 1, y - 1], map[x, y], map[x - 1, y + 1], map[x + 1, y + 1])) part2++;

        // Part 1 XMAS
        if (map[x, y] != 'X') continue;

        // horizontal search
        if (x + 3 < xMax)
            if (IsXMAS(map[x, y], map[x + 1, y], map[x + 2, y], map[x + 3, y])) part1++;
        if (x - 3 >= 0)
            if (IsXMAS(map[x, y], map[x - 1, y], map[x - 2, y], map[x - 3, y])) part1++;

        // vertical search
        if (y+3 < yMax)
            if (IsXMAS(map[x, y], map[x, y + 1], map[x, y + 2], map[x, y + 3])) part1++;
        if (y - 3 >= 0)
            if (IsXMAS(map[x, y], map[x, y - 1], map[x, y - 2], map[x, y - 3])) part1++;

        // diagonal search 
        if (x + 3 < xMax && y+3 < yMax)
            if (IsXMAS(map[x, y], map[x + 1, y + 1], map[x + 2, y + 2], map[x + 3, y + 3])) part1++;
        if (x + 3 < xMax && y - 3 >= 0)
            if (IsXMAS(map[x, y], map[x + 1, y - 1], map[x + 2, y - 2], map[x + 3, y - 3])) part1++;
        if (x - 3 >= 0 && y + 3 < yMax)
            if (IsXMAS(map[x, y], map[x - 1, y + 1], map[x - 2, y + 2], map[x - 3, y + 3])) part1++;
        if (x - 3 >= 0 && y - 3 >= 0)
            if (IsXMAS(map[x, y], map[x - 1, y - 1], map[x - 2, y - 2], map[x - 3, y - 3])) part1++;
    }
}

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

// Part 1 lookup
static bool IsXMAS(char a, char b, char c, char d) => (a == 'X' && b == 'M' && c == 'A' && d == 'S');

// Part 2 lookup
static bool IsMAS(char a, char b, char c, char d, char e)
{
    if (a == 'M' && b == 'M' && c == 'A' && d == 'S' && e == 'S') return true;
    if (a == 'S' && b == 'M' && c == 'A' && d == 'S' && e == 'M') return true;
    if (a == 'M' && b == 'S' && c == 'A' && d == 'M' && e == 'S') return true;
    if (a == 'S' && b == 'S' && c == 'A' && d == 'M' && e == 'M') return true;
    return false;
}
