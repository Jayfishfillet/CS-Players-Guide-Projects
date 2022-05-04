Console.Title = "Watchtower";

Console.Write("What is the X Value? ");
int xValue = Convert.ToInt32(Console.ReadLine());

Console.Write("What is the y value? ");
int yValue = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Enemy coordinates are: ({xValue},{yValue})");

if (xValue < 0)
{
    if (yValue > 0)
    {
        Console.WriteLine("The enemy is to the northwest!");
    }
    else if (yValue == 0)
    {
        Console.WriteLine("The enemy is to the west!");
    }
    else if (yValue < 0)
    {
        Console.WriteLine("The enemy is to the southwest!");
    }
}
else if (xValue == 0)
{
    if (yValue > 0)
    {
        Console.WriteLine("The enemy is to the north!");
    }
    else if (yValue == 0)
    {
        Console.WriteLine("The enemy is here!!");
    }
    else if (yValue < 0)
    {
        Console.WriteLine("The enemy is to the south!");
    }
}
else if (xValue > 0)
{
    if (yValue > 0)
    {
        Console.WriteLine("The enemy is to the northeast!");
    }
    else if (yValue == 0)
    {
        Console.WriteLine("The enemy is to the east!");
    }
    else if (yValue < 0)
    {
        Console.WriteLine("The enemy is to the southeast!");
    }
}