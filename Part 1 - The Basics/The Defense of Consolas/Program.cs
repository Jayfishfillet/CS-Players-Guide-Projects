Console.Title = "The Defense of Consolas";
Console.WriteLine("Defend Consolas!");

Console.Write("What Row is being targeted? ");
int targetRow = Convert.ToInt32(Console.ReadLine());

Console.Write("Which Column? is going to be hit? ");
int targetColumn = Convert.ToInt32(Console.ReadLine());

string westMage = $"{targetRow}, {targetColumn - 1} ";
string northMage = $"{targetRow + 1}, {targetColumn} ";
string eastMage = $"{targetRow}, {targetColumn + 1} ";
string southMage = $"{targetRow - 1}, {targetColumn} ";

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("Roger that! Deploying shield mages to:");
Console.WriteLine(westMage);
Console.WriteLine(northMage);
Console.WriteLine(eastMage);
Console.WriteLine(southMage);

Console.ReadKey();