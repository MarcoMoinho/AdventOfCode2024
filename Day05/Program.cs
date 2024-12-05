string[] inputs = File.ReadAllLines("input.txt");


List<string> order = [];
List<string> pageNumbers = [];

foreach (string input in inputs)
    if (input.Contains('|')) order.Add(input); else if (input != "") pageNumbers.Add(input);


int part1 = 0;
int part2 = 0;
bool orderOk;

foreach (string input in pageNumbers)
{
    string[] pages = input.Split(',');

    // part 1
    orderOk = true;
    for (int i = 0; i < pages.Length - 1; i++)
    {
        if (order.Contains($"{pages[i]}|{pages[i + 1]}")) continue;
        orderOk = false;
        break;
    }

    if (orderOk)
    {
        part1 += int.Parse(pages[(pages.Length - 1) / 2]);
        continue;
    }

    // part 2
    for (int i = 0; i < pages.Length - 1; i++)
    {
        if (order.Contains($"{pages[i]}|{pages[i + 1]}")) continue;

        // swap and start again
        (pages[i], pages[i + 1]) = (pages[i + 1], pages[i]);
        i = -1;
    }

    part2 += int.Parse(pages[(pages.Length - 1) / 2]);
}

Console.WriteLine(part1);
Console.WriteLine(part2);