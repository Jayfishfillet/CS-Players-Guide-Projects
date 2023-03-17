using EndGame.Battle;
using EndGame.CharacterUnits;
using EndGame.UnitActions;

Console.Title = "Endgame: Building Character";

#region Hero Party
List<Hero> heroParty = new List<Hero>();
Hero trueProgrammer = new Hero("Skeleton 1", UnitActions.BasicActions);
heroParty.Add(trueProgrammer);
#endregion

#region EnemyParty
List<Enemy> enemyParty = new List<Enemy>();
Enemy skeleton = new Enemy("Skeleton 2", UnitActions.BasicActions);
enemyParty.Add(skeleton);
#endregion

Battle firstBattle = new(heroParty, enemyParty);
firstBattle.BeginBattle();