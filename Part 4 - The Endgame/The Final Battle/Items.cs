using EndGame.CharacterUnits;

namespace EndGame.Items;

public class Item
{
    public Itemtype Type { get; init; }
    public string? ItemName { get; init; }
}

public class HealingItem : Item
{
    public int HealAmount { get; init; }
    public HealingItem(string itemName, int healAmount)
    {
        Type = Itemtype.Healing;
        ItemName = itemName;
        HealAmount = healAmount;
    }
}

public class Weapon : Item
{
    public int AttackDamage { get; init; }
    public Action<CharacterUnit, CharacterUnit> SpecialAttack { get; init; }
    public Weapon(string itemName, int attackDamage, Action<CharacterUnit, CharacterUnit> specialAttack)
    {
        Type = Itemtype.Weapon;
        ItemName = itemName;
        AttackDamage = attackDamage;
        SpecialAttack = specialAttack;
    }
}

public enum Itemtype { Weapon, Healing, Armor }