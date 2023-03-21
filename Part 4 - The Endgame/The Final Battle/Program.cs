using EndGame.Battle;
using EndGame.CharacterUnits;
using EndGame.UnitActions;
using EndGame.ActionManagement;

Console.Title = "The Final Battle";

Console.Write("True Programmer! What is your name? ");
string? name = Console.ReadLine();

#region Hero Party
List<CharacterUnit> heroParty = new();
Hero trueProgrammer = new Hero(name ?? "Hero", new ActionManager(UnitActions.DoNothing, UnitActions.Punch), 25);
heroParty.Add(trueProgrammer);
#endregion

#region Enemy setup
List<CharacterUnit> enemyParty = new();
Enemy skeleton  = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch, UnitActions.DoNothing), 5);
Enemy skeleton2 = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch, UnitActions.DoNothing), 5);
Enemy skeleton3 = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch, UnitActions.DoNothing), 5);
Enemy Uncoded   = new Enemy("The Uncoded One", new ActionManager(UnitActions.Unraveling), 15);
#endregion

Battle battle = new(heroParty, null, 0);
int finishedBattle = 0;

ExecuteBattle(heroParty, enemyParty, battle, 1, skeleton);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 1) ExecuteBattle(heroParty, enemyParty, battle, 2, skeleton2, skeleton3);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 2) ExecuteBattle(heroParty, enemyParty, battle, 3, Uncoded);
if (heroParty.Any(p => p.isAlive == true) && finishedBattle == 3)
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
    battle.BeginBattle();
    enemyParty.Clear();
    finishedBattle = battleNumber;
}
 
