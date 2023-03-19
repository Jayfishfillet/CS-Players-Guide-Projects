using EndGame.CharacterUnits;
using System.Data.Common;

namespace EndGame.Battle;

class Battle
{
    int round = 1;
    bool battleOver = false;

    Random random = new();
    private List<CharacterUnit> heroParty = new();
    private List<CharacterUnit> enemyParty = new();

    public Battle(List<CharacterUnit> heroParty, List<CharacterUnit> enemyParty)
    {
        this.heroParty = heroParty;
        this.enemyParty = enemyParty;
    }

    public void BeginBattle()
    {
        Console.Clear();
        while (!battleOver)
        {
            PartyChecker(heroParty, "Hero Party");
            PartyChecker(enemyParty, "Enemy Party");
            if (!battleOver)
            {
                Console.WriteLine($"==========Round: {round}==========\n");
                TurnManager();
                round++;
            }
        }

        void TurnManager()
        {
            foreach (CharacterUnit hero in heroParty)
            {
                if (hero.isAlive)
                {
                    Console.WriteLine($"It is {hero.Name}'s turn...\n");
                    Thread.Sleep(500);
                    hero.PerformAction(random.Next(hero.Actions.Count), enemyParty[random.Next(enemyParty.Count)]);
                    Thread.Sleep(2000);
                }
            }
            foreach (CharacterUnit enemy in enemyParty)
            {
                if (enemy.isAlive)
                {
                    Console.WriteLine($"It is {enemy.Name}'s turn...\n");
                    Thread.Sleep(500);
                    enemy.PerformAction(random.Next(enemy.Actions.Count), heroParty[random.Next(heroParty.Count)]);
                    Thread.Sleep(2000);
                }
            }
        }

        void PartyChecker(List<CharacterUnit> party, string partyName)
        {
            if (party.All(p => p.isAlive == false))
            {
                battleOver = true;
                Console.WriteLine($"{partyName} has been defeated.");
            }
        }
    }
}