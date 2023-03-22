using EndGame.CharacterUnits;
using System;

namespace EndGame.Battle;

class Battle
{
    int round = 1;
    public bool heroTurn = true;
    bool battleOver = false;
    private int battleNumber;
    Random random = new();
    private List<CharacterUnit> heroParty = new();
    private List<CharacterUnit> enemyParty = new();

    public Battle(List<CharacterUnit> heroParty, List<CharacterUnit> enemyParty, int battleNumber)
    {
        this.heroParty = heroParty;
        this.enemyParty = enemyParty;
        this.battleNumber = battleNumber;
    }

    public void BeginBattle()
    {
        Console.Clear();
        while (!battleOver)
        {
            //DefeatCheck(heroParty, "Hero Party");
            //DefeatCheck(enemyParty, "Enemy Party");
            if (!battleOver)
            {
                HeroTurn();
                EnemyTurn();
                BattleDisplay();
                DefeatCheck(heroParty, "Hero Party");
                DefeatCheck(enemyParty, "Enemy Party");

                round++;
            }
        }

        void HeroTurn()
        {
            foreach (CharacterUnit hero in heroParty)
            {
                if (hero.isAlive && enemyParty.Any(e => e.isAlive))
                {
                    BattleDisplay();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"It is {hero.Name}'s turn...\n");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    var randomAliveUnit = enemyParty.Where(e => e.isAlive).ToList();
                    hero.PerformAction(hero.ChooseAction(), randomAliveUnit[random.Next(randomAliveUnit.Count)]);
                    heroTurn = false;
                    Thread.Sleep(2000);
                }
            }
        }
        void EnemyTurn()
        {
            foreach (CharacterUnit enemy in enemyParty)
            {
                if (enemy.isAlive && heroParty.Any(h => h.isAlive))
                {
                    BattleDisplay();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"It is {enemy.Name}'s turn...\n");
                    Console.ResetColor();
                    Thread.Sleep(500);
                    var randomAliveUnit = heroParty.Where(e => e.isAlive).ToList();
                    enemy.PerformAction(random.Next(enemy.Actions.Count), randomAliveUnit[random.Next(randomAliveUnit.Count)]);
                    heroTurn = true;
                    Thread.Sleep(2000);
                }
            }
        }


        void DefeatCheck(List<CharacterUnit> party, string partyName)
        {
            if (party.All(p => p.isAlive == false))
            {
                battleOver = true;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{partyName} has been defeated.");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);
            }
        }

        void BattleDisplay()
        {
            Console.Clear();
            Console.WriteLine($"===================== Battle: {battleNumber} | Round: {round} =====================");
            foreach (Hero hero in heroParty)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-10} ({1}/{2})", hero.Name, Math.Clamp(hero.CurrentHP, 0, 999), hero.MaxHP);
                Console.ResetColor();
            }
            Console.WriteLine("-------------------------------VS-------------------------------");
            foreach (Enemy enemy in enemyParty)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0,56} ({1}/{2})", enemy.Name, Math.Clamp(enemy.CurrentHP, 0, 999), enemy.MaxHP);
                Console.ResetColor();
            }
            Console.WriteLine("================================================================\n");
        }
    }
}

