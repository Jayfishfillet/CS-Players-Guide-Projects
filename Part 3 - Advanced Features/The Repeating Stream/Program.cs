Console.Title = "The Repeating Stream";

Random random = new Random();
RecentNumbers recentNumbers = new RecentNumbers();
Thread numberThread = new Thread(() => NumberGenerator(random, recentNumbers));
numberThread.Start();

while (true)
{
    if (Console.ReadKey(true) != null)
    {
        lock (recentNumbers)
        {
            if (recentNumbers.LeastRecent == recentNumbers.MostRecent)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bingo! That's a repeat!\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nope, those don't match\n");
                Console.ResetColor();
            }
        }
    }
}

void NumberGenerator(Random random, RecentNumbers recentNumbers)
{
    while (true)
    {
        int newNumber = random.Next(10);
        Console.WriteLine($"Your new number is: {newNumber}\n");
        lock (recentNumbers)
        {
            recentNumbers.LeastRecent = recentNumbers.MostRecent;
            recentNumbers.MostRecent = newNumber;
        }
        Thread.Sleep(1000);
    }
}

class RecentNumbers
{
    public int LeastRecent { get; set; }
    public int MostRecent { get; set; }
}