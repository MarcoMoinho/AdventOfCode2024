string[] inputs = File.ReadAllLines("input.txt");

int xMax = inputs[0].Length;
int yMax = inputs.Length;

int guardX = 0;
int guardY = 0;

// create a charmap of the whole input
char[,] map = new char[xMax, yMax];
for (int y = 0; y < yMax; y++)
    for (int x = 0; x < xMax; x++)
    {
        map[x, y] = char.Parse(inputs[y].Substring(x, 1));
        if (map[x, y] == '^') { guardX = x; guardY = y; map[x, y] = '.'; }
    }

// solve part 1
List<(int,int)> distinct;
_ = IsLoop(map, (xMax, yMax), (guardX, guardY), true, out distinct);

// solve part 2
int part2 = 0;
foreach ((int x, int y) coord in distinct)
{
    map[coord.x, coord.y] = '#';
    if (IsLoop(map, (xMax, yMax), (guardX, guardY), false, out _)) part2++;
    map[coord.x, coord.y] = '.';
}

Console.WriteLine($"Part1: {distinct.Count}");
Console.WriteLine($"Part2: {part2}");

static bool IsLoop(char[,] map, (int x, int y) maxPos, (int x, int y) startPos, bool distinctNeeded, out List<(int,int)> distinct)
{
    distinct = [];

    int guardX = startPos.x;
    int guardY = startPos.y;

    int yDir = -1;
    int xDir = 0;

    List<(int x, int y, int xDir, int yDir)> positions = [];

    do
    {
        // check for out of bounds
        if (guardX + xDir < 0 || guardX + xDir >= maxPos.x) break;
        if (guardY + yDir < 0 || guardY + yDir >= maxPos.y) break;
        
        // check for obstacle
        if (map[guardX + xDir, guardY + yDir] != '.')
        {
            (xDir, yDir) = Rotate(xDir, yDir);
            continue;
        }

        // move
        guardX += xDir;
        guardY += yDir;

        if (distinctNeeded && !distinct.Contains((guardX,guardY)))
            distinct.Add((guardX, guardY));

        // check if same position and orientation, then it's a loop
        if (positions.Contains((guardX,guardY,xDir,yDir)))
            return true;

        positions.Add((guardX, guardY, xDir, yDir));

    } while (true);

    return false;
}

static (int xDir, int yDir) Rotate(int xDir, int yDir)
{
    if (xDir == 0 && yDir == -1) return (+1, 0); // right
    if (xDir == +1 && yDir == 0) return (0, +1); // down
    if (xDir == 0 && yDir == +1) return (-1, 0); // left
    if (xDir == -1 && yDir == 0) return (0, -1); // up
    throw new NotImplementedException();
}