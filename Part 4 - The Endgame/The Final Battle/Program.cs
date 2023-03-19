using EndGame.Battle;
using EndGame.CharacterUnits;
using EndGame.UnitActions;
using EndGame.ActionManagement;
using System.IO;


Console.Title = "Endgame: Building Character";

Console.Write("True Programmer! What is your name? ");
string? name = Console.ReadLine();

#region Hero Party
byte battleCompleted = 0;
List<CharacterUnit> heroParty = new();
Hero trueProgrammer = new Hero(name ?? "Hero", new ActionManager(UnitActions.Punch), 25);
heroParty.Add(trueProgrammer);
#endregion

#region Enemy setup
List<CharacterUnit> enemyParty = new();

Enemy skeleton  = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch), 5);
Enemy skeleton2 = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch), 5);
Enemy skeleton3 = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch), 5);
Enemy Uncoded   = new Enemy("The Uncoded One", new ActionManager(UnitActions.Unraveling), 15);
enemyParty.Add(skeleton);
#endregion

//First Battle
Battle firstBattle = new(heroParty, enemyParty, 1);
firstBattle.BeginBattle();
enemyParty.Clear();
battleCompleted = 1;

//Second Battle
if (heroParty.Any(p => p.isAlive == true) && battleCompleted == 1)
{
    Battle secondBattle = new(heroParty, enemyParty, 2);
    enemyParty.Add(skeleton2);
    enemyParty.Add(skeleton3);
    secondBattle.BeginBattle();
    enemyParty.Clear();
    battleCompleted = 2;
}

//Third Battle
if (heroParty.Any(p => p.isAlive == true) && battleCompleted == 2)
{
    Battle ThirdBattle = new(heroParty, enemyParty, 3);
    enemyParty.Add(Uncoded);
    ThirdBattle.BeginBattle();
    enemyParty.Clear();
    battleCompleted = 3;
}

if (heroParty.Any(p => p.isAlive == true) && battleCompleted == 3)
{
    Console.WriteLine("\nThe smoky form of the Uncoded One disintegrates, binary streams flowing out of it until it bursts apart in a dazzling blue light. You have done it. You have defeated the Uncoded One");
}
else
{
    Console.WriteLine("\nYour party has been defeated by The Uncoded One and his army. Game Over.");
}
