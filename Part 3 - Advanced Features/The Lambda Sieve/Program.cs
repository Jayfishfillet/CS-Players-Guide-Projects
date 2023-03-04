Console.Title = "The Lambda Sieve";

Sieve? sieve = null;
bool validInput = false;

Console.Write("[Numeromechanical Sieve Operational]\nSelect a filter:\n\n1. Even Number filter\n2. Positive Number Filter\n3. Multiples of 10 Filter\n");
while (!validInput)
{
    string? input = Console.ReadLine();

    (validInput, sieve) = input switch
    {
        "1" => (true, new Sieve(n => n % 2 == 0)),
        "2" => (true, new Sieve(n => n > -1)),
        "3" => (true, new Sieve(n => n % 10 == 0)),
        _ => (false, null)
    };

    if (!validInput)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Make another selection.");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

sieve?.GetNumbers();

class Sieve
{
    private Func<int, bool> sieveFilter;

    public Sieve(Func<int, bool> sieveFilter) => this.sieveFilter = sieveFilter;

    public void GetNumbers()
    {
        while (true)
        {
            Console.Write("Enter a number to send through the sieve: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine($"Is good: {IsGood(choice)}\n");
            }
            else Console.WriteLine("Invalid selection. Try again.");
        }
    }

    public bool IsGood(int number)
    {
        return sieveFilter(number);
    }
}