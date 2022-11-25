namespace InventoryItems;

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
    public override string ToString() => "Arrow";
}
public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f)
    {
    }

    public override string ToString() => "Bow";
}

public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f)
    {
    }
    public override string ToString() => "Rope";
}

public class Water : InventoryItem
{
    public Water() : base(2f, 3f)
    {
    }
    public override string ToString() => "Water";
}

public class FoodRations : InventoryItem
{
    public FoodRations() : base(1f, .5f)
    {
    }
    public override string ToString() => "Food Rations";
}

public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f)
    {
    }
    public override string ToString() => "Sword";
}