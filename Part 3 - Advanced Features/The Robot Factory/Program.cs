using System.Dynamic;

Console.Title = "The Robot Factory";

dynamic robot;
int robotID = 1;

while (true)
{
    robot = new ExpandoObject();

    robot.ID = robotID;
    Console.WriteLine($"You are making Robot ID: {robot.ID}\n");
    Console.Write("Would you like to name the Robot? ");
    string? input = Console.ReadLine();
    if (input == "yes")
    {
        Console.Write("Please enter a name: ");
        robot.Name = Console.ReadLine().ToLower();
    }
    else
    {
        Console.WriteLine("Moving on...\n");
        Thread.Sleep(1500);
    }

    Console.Write("Would you like to customize the size? ");
    input = Console.ReadLine();
    if (input == "yes")
    {
        Console.Write("Please enter a height: ");
        robot.Height = Console.ReadLine().ToLower();
        Console.Write("Please enter a width: ");
        robot.Width = Console.ReadLine().ToLower();
    }
    else
    {
        Console.WriteLine("Moving on...\n");
        Thread.Sleep(1500);
    }

    Console.Write("Would you like to have colored markings? ");
    input = Console.ReadLine();
    if (input == "yes")
    {
        Console.Write("Please enter a color for the markings: ");
        robot.Color = Console.ReadLine().ToLower();
    }
    else
    {
        Console.WriteLine("Completing build...\n");
        Thread.Sleep(1500);
    }

    Console.WriteLine("\n====================COMPLETED ROBOT=======================");
    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }
    Console.WriteLine("==========================================================\n");

    robotID ++;
}