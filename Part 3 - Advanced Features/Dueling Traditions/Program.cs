using Pack;
using InventoryItems;

namespace DuelingTraditions;

class program
{
    static void Main(string[] args)
    {
        Console.Title = "Dueling Traditions via Packing Inventory";

        Pack.Pack AdventurerPack = new Pack.Pack();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine($"Pack Status: \nItems: {AdventurerPack.CurrentItems}/{AdventurerPack.MaxItems}, \nWeight: {AdventurerPack.CurrentWeight}/{AdventurerPack.MaxWeight} \nVolume:{AdventurerPack.CurrentVolume}/{AdventurerPack.MaxVolume}");
            Console.WriteLine($"\n{AdventurerPack.ToString()}");
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("\nWhat would you like to add to the pack?");
            Console.WriteLine("Arrow");
            Console.WriteLine("Bow");
            Console.WriteLine("Rope");
            Console.WriteLine("Water");
            Console.WriteLine("Food");
            Console.WriteLine("Sword\n");

            string choice = Console.ReadLine().ToLower();

            InventoryItem addedItem = choice switch
            {
                "arrow" => new Arrow(),
                "bow" => new Bow(),
                "rope" => new Rope(),
                "water" => new Water(),
                "food" => new FoodRations(),
                "sword" => new Sword(),
            };

            if (!AdventurerPack.Add(addedItem))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The pack is too full to add that right now.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1500);
            }
        }
    }
}



