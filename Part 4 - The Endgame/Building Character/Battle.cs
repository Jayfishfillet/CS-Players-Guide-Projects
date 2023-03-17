using EndGame.CharacterUnits;

namespace EndGame.Battle;

class Battle
{
    byte round = 0;
    private List<Hero> heroParty = new();
    private List<Enemy> enemyParty = new();

    public Battle(List<Hero> heroParty, List<Enemy> enemyParty)
    {
        this.heroParty = heroParty;
        this.enemyParty = enemyParty;
    }

    public void BeginBattle()
    {
        while (true)
        {
            TurnManager();
        }

        void TurnManager()
        { 
            round++;
            foreach (Hero hero in heroParty) 
            {
                Console.WriteLine($"It is {hero.Name}'s turn...");
                Thread.Sleep(500);
                hero.PerformAction(0);
                Thread.Sleep(2000);
            }
            foreach (Enemy enemy in enemyParty) 
            {
                Console.WriteLine($"It is {enemy.Name}'s turn...");
                Thread.Sleep(500);
                enemy.PerformAction(0);
                Thread.Sleep(2000);
            }
        }
    }
}