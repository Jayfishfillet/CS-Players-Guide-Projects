Console.Title = "Safer Number Crunching";

for(;;)
{
    Console.Write("Enter an int32: ");
    string? choice = Console.ReadLine();

    if (int.TryParse(choice, out int parsedValue))
    {
        Console.WriteLine($"Your int is {parsedValue}");
        break;
    }
}

while (true)
{
    Console.Write("Enter a double: ");
    string? choice = Console.ReadLine();

    if (double.TryParse(choice, out double parsedValue))
    {
        Console.WriteLine($"Your double is {parsedValue}");
        break;
    }
}

do
{
    Console.Write("Enter True or False: ");
    string? choice = Console.ReadLine().ToLower();

    if (bool.TryParse(choice, out bool parsedValue))
    {
        Console.WriteLine($"Your bool is {parsedValue}");
        break;
    }
}
while(true);