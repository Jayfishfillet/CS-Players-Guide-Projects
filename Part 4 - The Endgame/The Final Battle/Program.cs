using EndGame.Battles;
using EndGame.CharacterUnits;
using EndGame.UnitActions;
using EndGame.Items;

Console.Title = "The Final Battle";

Console.Write("Who is you? ");
string? name = Console.ReadLine();

#region Hero Party
List<Item> heroInventory = new() { new HealingItem("Hi-Potion", 15), new HealingItem("Mega-Potion", 25), new HealingItem("Elixir", 50), new Weapon("Binary Bowcaster", 2, UnitAction.BinaryShot), new Weapon("Flux Katana", 3, UnitAction.VariableSlash) };
List<CharacterUnit> heroParty = new();
Hero trueProgrammer = new Hero(name ?? "Hero", new(UnitAction.DoNothing, UnitAction.Punch, UnitAction.UseItem, UnitAction.Equip), 25, ref heroInventory, true) { CurrentWeapon = new Weapon("Sword of Creation", 1, UnitAction.CodeforgeSlash), DefenseModifier = ("OBJECT SIGHT", -2), resistanceType = AttackType.Decoding };
Hero vinFletcher    = new Hero("Vin Fletcher", new(UnitAction.DoNothing, UnitAction.Punch, UnitAction.UseItem, UnitAction.Equip), 20, ref heroInventory, true) { CurrentWeapon = new Weapon("Vin's Bow", 6, UnitAction.QuickShot), resistanceType = AttackType.None };
heroParty.Add(trueProgrammer);
heroParty.Add(vinFletcher);
#endregion

#region Enemy setup
List<Item> enemyInventory = new();
List<CharacterUnit> enemyParty = new();
Enemy skeleton     = new Enemy("Skeleton", new(UnitAction.BoneCrunch, UnitAction.UseItem, UnitAction.Equip), 10, ref enemyInventory, true) { CurrentWeapon = new Weapon("Dagger", 1, UnitAction.Stab), resistanceType = AttackType.None };
Enemy skeleton2    = new Enemy("Skeleton", new(UnitAction.BoneCrunch, UnitAction.UseItem, UnitAction.Equip), 10, ref enemyInventory, true) { resistanceType = AttackType.None };
Enemy skeleton3    = new Enemy("Skeleton", new(UnitAction.BoneCrunch, UnitAction.UseItem, UnitAction.Equip), 10, ref enemyInventory, true) { resistanceType = AttackType.None };
Enemy stoneAmarok  = new Enemy("Stone Amarok", new(UnitAction.Bite), 8, ref enemyInventory, false) { DefenseModifier = ("STONE ARMOR", -1), resistanceType = AttackType.Normal };
Enemy stoneAmarok2 = new Enemy("Stone Amarok", new(UnitAction.Bite), 8, ref enemyInventory, false) { DefenseModifier = ("STONE ARMOR", -1), resistanceType = AttackType.Normal };
Enemy Uncoded      = new Enemy("The Uncoded One", new(UnitAction.Unraveling, UnitAction.ReCompile, UnitAction.UseItem, UnitAction.Equip), 200, ref enemyInventory, true) { CurrentWeapon = new Weapon("Staff of Decoding", 9, UnitAction.Decompile), DefenseModifier = ("BINARY BARRIER", -1), resistanceType = AttackType.Normal };
#endregion

Battle battle = new(heroParty, null, 0);
int finishedBattle = 0;

ExecuteBattle(heroParty, enemyParty, battle, 1, skeleton);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 1) ExecuteBattle(heroParty, enemyParty, battle, 2, skeleton2, skeleton3);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 2) ExecuteBattle(heroParty, enemyParty, battle, 3, stoneAmarok, stoneAmarok2);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 3) ExecuteBattle(heroParty, enemyParty, battle, 4, Uncoded);

if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 4)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nYou have defeated The Uncoded one! You have returned programming to the lands!");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nYou've fallen to The Uncoded One and his army...His reign of terror continues to plague the lands.");
    Console.ResetColor();
}

Console.WriteLine("Press any Key to Exit.");
Console.ReadKey(true);

void ExecuteBattle(List<CharacterUnit> heroParty, List<CharacterUnit> enemyParty, Battle battle, int battleNumber, params CharacterUnit[] enemies)
{
    foreach (CharacterUnit u in enemies) { enemyParty.Add(u);}
    battle = new(heroParty, enemyParty, battleNumber);
    enemyInventory.Clear();
    if (finishedBattle == 0)
    {
        enemyInventory.Add(new HealingItem("Potion", 10));
    }
    if (finishedBattle == 1)
    {
        enemyInventory.Add(new HealingItem("Potion", 10));
        enemyInventory.Add(new Weapon("Dagger", 2, UnitAction.Stab));
        enemyInventory.Add(new Weapon("Dagger", 2, UnitAction.Stab));
    }
    if (finishedBattle == 2)
    {
        enemyInventory.Add(new HealingItem("Potion", 10));
    }
    if (finishedBattle == 3)
    {
        enemyInventory.Add(new HealingItem("Hi-Potion", 15));
        enemyInventory.Add(new HealingItem("Elixir", 50));
    }

    battle.BeginBattle();
    enemyParty.Clear();
    finishedBattle = battleNumber;
}