using EndGame.CharacterUnits;
using EndGame.HelperMethods;
using EndGame.Items;
using EndGame.UnitActions;
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
                    hero.PerformAction(hero.ChooseAction(), randomAliveUnit[random.Next(randomAliveUnit.Count)], hero);
                    Thread.Sleep(2500);
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
                    if (!enemy.CanEquip)
                    {
                        enemy.PerformAction(random.Next(enemy.Actions.Count), randomAliveUnit[random.Next(randomAliveUnit.Count)], enemy);
                    }
                    if (enemy.CanEquip)
                    {
                        enemy.PerformAction(enemy.Actions.IndexOf(UnitAction.Equip), randomAliveUnit[random.Next(randomAliveUnit.Count)], enemy);
                    }
                    Thread.Sleep(2500);
                }
            }
        }


        void DefeatCheck(List<CharacterUnit> party, string partyName)
        {
            if (party.All(p => p.isAlive == false))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{partyName} has been defeated.");
                Console.ResetColor();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey(true);

                if (party == heroParty)
                {
                    TransferInventory(party, enemyParty);
                }
                else
                {
                    TransferInventory(party, heroParty);
                }

                battleOver = true;

            }

            void TransferInventory(List<CharacterUnit> losingParty, List<CharacterUnit> winningParty)
            {
                foreach (CharacterUnit unit in losingParty)
                {
                    foreach (Item item in unit.Inventory)
                    {
                        winningParty.ForEach(winner => winner.Inventory.Add(item));
                    }
                    unit.Inventory.Clear();
                }
            }

        }

        void BattleDisplay()
        {
            Console.Clear();
            Console.WriteLine($"===================== Battle: {battleNumber} | Round: {round} =====================\n");
            foreach (Hero hero in heroParty)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0, -15} ({1}/{2}) | {3}", hero.Name, Math.Clamp(hero.CurrentHP, 0, 999), hero.MaxHP, "Weapon: " + hero.CurrentWeapon.ItemName ?? "No Weapon");
                Console.ResetColor();
            }
            Console.WriteLine("\n-------------------------------VS-------------------------------\n");
            foreach (Enemy enemy in enemyParty)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0,40} ({1}/{2}) | {3}", enemy.Name, Math.Clamp(enemy.CurrentHP, 0, 999), enemy.MaxHP, "Weapon: " + (enemy.CurrentWeapon?.ItemName ?? "None"));
                Console.ResetColor();
            }
            Console.WriteLine("================================================================\n");
        }
    }
}

