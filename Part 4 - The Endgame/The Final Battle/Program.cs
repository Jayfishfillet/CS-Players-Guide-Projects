using EndGame.Battle;
using EndGame.CharacterUnits;
using EndGame.UnitActions;
using EndGame.ActionManagement;

Console.Title = "Endgame: Building Character";

Console.Write("True Programmer! What is your name? ");
string? name = Console.ReadLine();

#region Hero Party
List<Hero> heroParty = new List<Hero>();
Hero trueProgrammer = new Hero(name, new ActionManager(UnitActions.Punch));
heroParty.Add(trueProgrammer);
#endregion

#region EnemyParty
List<Enemy> enemyParty = new List<Enemy>();
Enemy skeleton = new Enemy("Skeleton", new ActionManager(UnitActions.BoneCrunch));
enemyParty.Add(skeleton);
#endregion


Battle firstBattle = new(heroParty, enemyParty);
firstBattle.BeginBattle();