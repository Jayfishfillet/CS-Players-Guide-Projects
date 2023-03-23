using EndGame.CharacterUnits;
using EndGame.Items;
using EndGame.UnitActions;

namespace EndGame.HelperMethods;
public static class HelperMethod
{
    public static void DeathCheck(CharacterUnit target)
    {
        if (target.CurrentHP <= 0)
        {
            target.isAlive = false;
            Console.WriteLine($"{target.Name} has been slain!");
            target.Inventory.Add(target.CurrentWeapon);
            target.CurrentWeapon = null;
        }
    }
    public static int Clamper(int hP)
    {
        return Math.Clamp(hP, 0, 999);
    }
    public static void AttackMessaging(CharacterUnit target)
    {
        Console.WriteLine($"{target.Name} has {Clamper(target.CurrentHP)}/{target.MaxHP} HP");
        DeathCheck(target);
        Console.WriteLine();
    }
    public static void UseHealingItem(CharacterUnit self, HealingItem healingItem)
    {
        Console.WriteLine($"{self.Name} used {healingItem.ItemName}");
        Console.WriteLine($"{healingItem.ItemName} restored {healingItem.HealAmount} HP!");
        if (healingItem.HealAmount + self.CurrentHP > self.MaxHP) self.CurrentHP = self.MaxHP;
        else self.CurrentHP += healingItem.HealAmount;
    }
    public static void EnemyHealingItemHandler(CharacterUnit self, CharacterUnit target, List<HealingItem> healingItems)
    {
        int randomItem = new Random().Next(healingItems.Count);

        if (self.Inventory.Count > 0 && (self.CurrentHP <= (self.MaxHP / 2)) && new Random().Next(4) == 0)
        {
            HelperMethod.UseHealingItem(self, healingItems[randomItem]);
            healingItems.Remove(healingItems[randomItem]);
        }
        else
        {
            self.PerformAction(new Random().Next(self.Actions.Count), target, self);
        }
    }
    public static void EquipWeapon(CharacterUnit self, Weapon weapon, List<Weapon> weapons)
    {

        if (self.CurrentWeapon != null)
        {
            self.Actions.Remove(self.CurrentWeapon.SpecialAttack);
            Console.WriteLine($"{self.CurrentWeapon.ItemName} has been unequipped.");
            self.Inventory.Add(self.CurrentWeapon);
            Thread.Sleep(500);
        }

        self.CurrentWeapon = weapon;
        Console.WriteLine($"And {self.Name} has equipped the {weapon.ItemName}");

    }
    public static void EnemyEquipHandler(CharacterUnit self, CharacterUnit target, List<Weapon> weapons)
    {
        if (self.CurrentWeapon == null)
        {
            self.CurrentWeapon = weapons[new Random().Next(weapons.Count)];
            Console.WriteLine($"{self.Name} has equipped the {self.CurrentWeapon.ItemName}");
            self.Inventory.Remove(self.CurrentWeapon);

            self.Actions.RemoveAll(a => a.Method.Name == nameof(UnitAction.BoneCrunch));
            self.Actions.Add(self.CurrentWeapon.SpecialAttack);
        }

        else if (self.CurrentWeapon != null || self.Name == "The Uncoded One")
        {
            self.Actions.Add(self.CurrentWeapon.SpecialAttack);
            self.Actions.RemoveAll(a => a.Method.Name == nameof(UnitAction.BoneCrunch));
            self.PerformAction(new Random().Next(self.Actions.Count), target, self);
        }
    }
    public static int ResolveDefense(CharacterUnit target, AttackType attackType)
    {
        if (target.resistanceType == attackType)
        {
            Console.WriteLine($"{target.DefenseModifier.skill} is lowering {attackType.ToString().ToUpper()} damage by {target.DefenseModifier.value * -1}\n");
            return target.DefenseModifier.value;
        }
        else return 0;
    }
    public static int CriticalRoll(int damage, int critChance)
    {
        if (new Random().Next(100) + 1 <= critChance)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("CRITICAL HIT");
            Console.ResetColor();

            return damage *= 2;
        }
        else return damage;
        
    }
    public static int IsValidSelection(CharacterUnit self, List<HealingItem> healingItems, ConsoleKey choice)
    {
        int selection = -1;
        switch (choice)
        {
            case ConsoleKey.NumPad1:
            case ConsoleKey.D1:
                selection = 0;
                break;
            case ConsoleKey.NumPad2:
            case ConsoleKey.D2:
                selection = 1;
                break;
            case ConsoleKey.NumPad3:
            case ConsoleKey.D3:
                selection = 2;
                break;
            case ConsoleKey.NumPad4:
            case ConsoleKey.D4:
                selection = 3;
                break;
            case ConsoleKey.NumPad5:
            case ConsoleKey.D5:
                selection = 4;
                break;
            case ConsoleKey.NumPad6:
            case ConsoleKey.D6:
                selection = 5;
                break;
        }

        if (selection >= 0 && selection < healingItems.Count)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}