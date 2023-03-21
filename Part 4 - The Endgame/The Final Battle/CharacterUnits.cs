using EndGame.ActionManagement;
using System.Runtime.CompilerServices;
using System.Text;

namespace EndGame.CharacterUnits;

public class CharacterUnit
{
    //Unit stats
    public string Name { get; init; }
    public int MaxHP { get; init; }
    public int CurrentHP { get; set; }
    public bool isAlive { get; set; } = true;
    public List<Action<CharacterUnit>> Actions { get; init; }

    public CharacterUnit(string name, ActionManager actionManager, int maxHP)
    {
        Name = name;
        Actions = actionManager.actionList;
        CurrentHP = MaxHP = maxHP;
    }

    public void PerformAction(int index, CharacterUnit target)
    {
        Console.Write(Name + " ");
        Actions[index].Invoke(target);
    }

    public int ChooseAction()
    {
        Console.WriteLine($"----------Available Actions---------\n");
        foreach (Action<CharacterUnit> action in Actions)
        {
            Console.WriteLine($"{Actions.IndexOf(action) + 1} - {action.Method.Name}");
        }
        Console.WriteLine($"\n-----------------------------------");
        try
        {
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 0,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 1,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 2,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 3,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 4
            };
        }
        catch (SwitchExpressionException)
        {
            return 0;
        }
    }
}

class Enemy : CharacterUnit
{
    public Enemy(string name, ActionManager actionManager, int maxHP) : base(name, actionManager, maxHP)
    {
    }
}

class Hero : CharacterUnit
{
    public Hero(string name, ActionManager actionManager, int maxHP) : base(name, actionManager, maxHP)
    {
    }
}