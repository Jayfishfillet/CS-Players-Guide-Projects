using EndGame.CharacterUnits;
using System;

namespace EndGame.Battle;

class Battle
{
    byte round = 1;
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
                hero.PerformAction(GetActionList(hero.Actions));
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

    int GetActionList(List<Action> actionList)
    {
        byte index = 0;
        Console.WriteLine("What will you do?");
        Console.WriteLine();
        Console.WriteLine("Available Actions:");
        foreach (Action action in actionList)
        {
            Console.WriteLine($"{index} - {action.Method.Name}");
            index++;
        }
        Console.WriteLine();

        return Console.ReadKey(true).Key switch
        {
            ConsoleKey.D0 or ConsoleKey.NumPad0 => 0,
            ConsoleKey.D1 or ConsoleKey.NumPad1 => 1,
            ConsoleKey.D2 or ConsoleKey.NumPad2 => 2,
            ConsoleKey.D3 or ConsoleKey.NumPad3 => 3,
            ConsoleKey.D4 or ConsoleKey.NumPad4 => 4,
            _ => 0
        }; ;
    }
}