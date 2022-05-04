Console.Title = "Repairing the Clocktower";

Console.WriteLine("Pick a number to flow into the Clocktower");
int number = Convert.ToInt32(Console.ReadLine());

if (number % 2 == 0)
{
    Console.WriteLine("Tick");
}
else
{
    Console.WriteLine("Tock");
}

