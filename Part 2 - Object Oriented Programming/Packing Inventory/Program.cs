Console.Title = "Packing Inventory";

Pack AdventurerPack = new Pack(10, 20, 30);

while (true)
{
    Console.WriteLine("------------------------------------------------------------------");
    Console.WriteLine($"Pack Status: \nItems: {AdventurerPack.CurrentItems}/{AdventurerPack.MaxItems}, \nWeight: {AdventurerPack.CurrentWeight}/{AdventurerPack.MaxWeight} \nVolume:{AdventurerPack.CurrentVolume}/{AdventurerPack.MaxVolume}");
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
        Console.WriteLine("The pack is too full to add that right now.");
}



public class Pack
{
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    private InventoryItem[] items;

    public int CurrentItems { get; private set; } = 0;
    public float CurrentWeight { get; private set; }
    public float CurrentVolume { get; private set; }

    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        this.MaxItems = maxItems;
        this.MaxWeight = maxWeight;
        this.MaxVolume = maxVolume;


        items = new InventoryItem[maxItems];
    }

    public bool Add(InventoryItem item)
    {
        if (CurrentItems >= MaxItems) return false;
        if (CurrentVolume + item.ItemWeight > MaxWeight) return false;
        if (CurrentWeight + item.ItemVolume > MaxVolume) return false;

        items[CurrentItems] = item;
        CurrentItems++;
        CurrentWeight += item.ItemWeight;
        CurrentVolume += item.ItemVolume;
        return true;
    }
}


public class InventoryItem
{
    public float ItemWeight { get; protected set; }
    public float ItemVolume { get; protected set; }

    public InventoryItem(float itemWeight, float itemVolume)
    { 
        ItemWeight = itemWeight;
        ItemVolume = itemVolume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(.1f, .05f)
    {
    }
}
public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f)
    {
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f)
    {
    }
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f)
    {
    }
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, .5f)
    {
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f)
    {
    }
}