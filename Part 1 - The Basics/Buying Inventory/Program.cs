Console.WriteLine("Welcome traveler, here is what we have for sale");
Console.WriteLine("What would you like to see the price of?");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

int choice = Convert.ToInt32(Console.ReadLine());

int itemCost = choice switch
{
    1 => 10,
    2 => 15,
    3 => 25,
    4 => 1,
    5 => 20,
    6 => 200,
    7 => 1,
    _ => 0

};

string merchantResponse = choice switch
{
    1 => $"Rope costs {itemCost} Gold",
    2 => $"Torches cost {itemCost} Gold",
    3 => $"Climbing Equipment costs {itemCost} Gold",
    4 => $"Clean water costs {itemCost} Gold",
    5 => $"A machete costs {itemCost} Gold",
    6 => $"A canoe costs {itemCost} Gold",
    7 => $"Food supplies costs {itemCost} Gold",
    _ => $"Im sorry, we have {itemCost} of those."
};

Console.WriteLine(merchantResponse);