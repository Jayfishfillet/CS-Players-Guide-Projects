namespace EndGame.Items;

public class Item
{
    public Itemtype Type { get; init; }
    public string? ItemName { get; init; }
}

public class Potion : Item
{
    public readonly int HpValue = 10;
    public Potion()
    {
        Type = Itemtype.Healing;
        ItemName = "Healing Potion";
    }

}

public enum Itemtype { Weapon, Healing, Armor }