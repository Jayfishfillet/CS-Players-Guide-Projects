using EndGame.CharacterUnits;

namespace EndGame.Battle;

class Battle
{
    byte round = 1;
    Random random = new();
    private List<Hero> heroParty = new();
    private List<Enemy> enemyParty = new();

    public Battle(List<Hero> heroParty, List<Enemy> enemyParty)
    {
        this.heroParty = heroParty;
        this.enemyParty = enemyParty;
    }

    public void BeginBattle()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine($"It is round: {round}");
            TurnManager();
            round++;
        }

        void TurnManager()
        {
            foreach (Hero hero in heroParty)
            {
                Console.WriteLine($"It is {hero.Name}'s turn...");
                Thread.Sleep(500);
                hero.PerformAction(random.Next(hero.Actions.Count), enemyParty[random.Next(enemyParty.Count)]);
                Thread.Sleep(2000);
            }
            foreach (Enemy enemy in enemyParty)
            {
                Console.WriteLine($"It is {enemy.Name}'s turn...");
                Thread.Sleep(500);
                enemy.PerformAction(random.Next(enemy.Actions.Count), heroParty[random.Next(heroParty.Count)]);
                Thread.Sleep(2000);
            }
        }
    }
}