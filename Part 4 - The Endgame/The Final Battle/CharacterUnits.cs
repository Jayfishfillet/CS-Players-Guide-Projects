using EndGame.ActionManagement;
using EndGame.Items;
using EndGame.UnitActions;
using EndGame.Battles;
using System;

namespace EndGame.CharacterUnits;

public class CharacterUnit
{
    //Unit stats
    public string Name { get; init; }
    public int MaxHP { get; init; }
    public int CurrentHP { get; set; }
    public List<Item> Inventory { get; set; }
    public Weapon? CurrentWeapon { get; set; } = null;
    public bool isAlive { get; set; } = true;
    public bool CanEquip { get; set; }
    public Party party { get; init; }
    public (string skill, int value) DefenseModifier { get; set; }
    public AttackType resistanceType { get; set; }
    public List<Action<CharacterUnit, CharacterUnit>> Actions { get; init; }

    public CharacterUnit(string name, ActionManager actionManager, int maxHP, ref List<Item> inventory, bool canEquip)
    {
        Name = name;
        Actions = actionManager.actionList;
        CurrentHP = MaxHP = maxHP;
        Inventory = inventory;
        CanEquip = canEquip;
    }

    public void PerformAction(int index, CharacterUnit target, CharacterUnit self)
    {
        if (target.isAlive)
        {
            Actions[index].Invoke(target, self);
        }
    }

    public int ChooseAction(Battle battle)
    {
        int selectedIndex = -1;

        while (selectedIndex < 0)
        {
            if (CurrentWeapon != null)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("{0,26}", $"Current Weapon: {CurrentWeapon.ItemName}");
                Console.ResetColor();
            }
            Console.WriteLine("++++++ Available Actions ++++++\n");
            if (CurrentWeapon != null && !Actions.Contains(CurrentWeapon.SpecialAttack))
            {
                Actions.Add(CurrentWeapon.SpecialAttack);
            }
            foreach (Action<CharacterUnit, CharacterUnit> action in Actions)
            {
                Console.WriteLine($"{Actions.IndexOf(action) + 1} - {action.Method.Name}");
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++");

            var keyPressed = Console.ReadKey(true).Key;

            selectedIndex = keyPressed switch
            {
                ConsoleKey.D1 or ConsoleKey.NumPad1 => 0,
                ConsoleKey.D2 or ConsoleKey.NumPad2 => 1,
                ConsoleKey.D3 or ConsoleKey.NumPad3 => 2,
                ConsoleKey.D4 or ConsoleKey.NumPad4 => 3,
                ConsoleKey.D5 or ConsoleKey.NumPad5 => 4,
                ConsoleKey.D6 or ConsoleKey.NumPad6 => 5,
                ConsoleKey.D7 or ConsoleKey.NumPad7 => 6,
                ConsoleKey.D8 or ConsoleKey.NumPad8 => 7,
                ConsoleKey.D9 or ConsoleKey.NumPad7 => 8,
                _ => -1,
            };

            if (selectedIndex < 0 || selectedIndex >= Actions.Count)
            {
                battle.BattleDisplay();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Invalid Selection, please try again\n");
                Console.ResetColor();
                selectedIndex = -1;
            }
        }

        return selectedIndex;
    }

    public enum Party { Hero, Enemy }
}

class Enemy : CharacterUnit
{
    public Enemy(string name, ActionManager actionManager, int maxHP, ref List<Item> inventory, bool canEquip) : base(name, actionManager, maxHP, ref inventory, canEquip)
    {
        party = Party.Enemy;
    }
}

class Hero : CharacterUnit
{
    public Hero(string name, ActionManager actionManager, int maxHP, ref List<Item> inventory, bool canEquip) : base(name, actionManager, maxHP, ref inventory, canEquip)
    {
        party = Party.Enemy;
    }
}