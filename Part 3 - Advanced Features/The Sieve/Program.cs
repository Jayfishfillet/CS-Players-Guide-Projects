Console.Title = "the Sieve";

SieveDelegate? sieveFilter;
Sieve? sieve = null;
bool validInput = false;

Console.Write("[Numeromechanical Sieve Operational]\nSelect a filter:\n\n1. Even Number filter\n2. Positive Number Filter\n3. Multiples of 10 Filter\n");
while (!validInput) 
{
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int selection))
    {
        switch (selection)
        {
            case 1:
                sieveFilter = IsEven;
                sieve = new Sieve(sieveFilter);
                validInput = true;
                break;
            case 2:
                sieveFilter = IsPositive;
                sieve = new Sieve(sieveFilter);
                validInput = true;
                break;
            case 3:
                sieveFilter = IsMultipleOfTen;
                sieve = new Sieve(sieveFilter);
                validInput = true;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Make another selection. ");
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Make another selection. ");
        Console.ForegroundColor = ConsoleColor.Gray;
    }
}

sieve.GetNumbers();

bool IsEven(int number)
{
    if (number % 2 == 0) return true;
    else return false;
}

bool IsPositive(int number)
{
    if (number > 0) return true;
    else return false;
}

bool IsMultipleOfTen(int number)
{
    if (number % 10 == 0) return true;
    else return false;
}

class Sieve
{
    private SieveDelegate SieveFilter;

    public Sieve(SieveDelegate sieveFilter)
    {
        SieveFilter = sieveFilter;
    }

    public void GetNumbers()
    {
        while (true)
        {
            Console.Write("Enter a number to send through the sieve: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine($"Is good: {IsGood(choice)}\n");
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
            }
        }
    }

    public bool IsGood(int number)
    {
        return SieveFilter(number);
    }

}

public delegate bool SieveDelegate(int number);