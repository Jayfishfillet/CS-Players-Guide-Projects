using EndGame.Battle;
using EndGame.CharacterUnits;
using EndGame.UnitActions;
using EndGame.ActionManagement;


Console.Title = "Endgame: Building Character";

Console.Write("True Programmer! What is your name? ");
string? name = Console.ReadLine();

#region Hero Party
List<CharacterUnit> heroParty = new();
Hero trueProgrammer = new Hero(name ?? "Hero", new ActionManager(UnitActions.Punch), 25);
heroParty.Add(trueProgrammer);
#endregion

#region EnemyParty
List<CharacterUnit> enemyParty = new();
Enemy skeleton = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch), 5);
enemyParty.Add(skeleton);
#endregion


Battle firstBattle = new(heroParty, enemyParty);
firstBattle.BeginBattle();