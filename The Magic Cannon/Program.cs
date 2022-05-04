Console.Title = "The Magic Cannon";

string blastElement;

for (int crankTurn = 1; crankTurn <= 100; crankTurn++)
{
    if (crankTurn % 15 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        blastElement = "Combined";
    }
    else if (crankTurn % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        blastElement = "Electric";
    }
    else if (crankTurn % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        blastElement = "Fire";
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.White;
        blastElement = "Normal";
    }
    Console.WriteLine($"{crankTurn}: {blastElement}");

    Console.ForegroundColor = ConsoleColor.White;
}