int kingdomPoints = 0;

Console.WriteLine("How Many estates does your kingdom have?");
kingdomPoints += Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many duchies are in your kingdom? ");
kingdomPoints += Convert.ToInt32(Console.ReadLine()) * 3;

Console.WriteLine("How many provinces within your kingdom?");
kingdomPoints += Convert.ToInt32(Console.ReadLine()) * 6;

Console.WriteLine($"Sire, your kingdom is worth {kingdomPoints} points.");