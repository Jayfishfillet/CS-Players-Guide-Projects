Console.WriteLine("Welcome traveler, What is your name?");
string myName = Console.ReadLine().ToLower();

Console.WriteLine((myName == "jay") ? "Ahhh, Jay welcome back! enjoy a 50% discount!" : "This is what we have for sale.");

Console.WriteLine("What would you like to see the price of?");
Console.WriteLine("1 - Rope");
Console.WriteLine("2 - Torches");
Console.WriteLine("3 - Climbing Equipment");
Console.WriteLine("4 - Clean Water");
Console.WriteLine("5 - Machete");
Console.WriteLine("6 - Canoe");
Console.WriteLine("7 - Food Supplies");

float choice = Convert.ToSingle(Console.ReadLine());

float itemCost = choice switch
{
    1 => 10f,
    2 => 15f,
    3 => 25f,
    4 => 1f,
    5 => 20f,
    6 => 200f,
    7 => 1f,
    _ => 0f

};

if (myName == "jay")
{
    itemCost /= 2;
}

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