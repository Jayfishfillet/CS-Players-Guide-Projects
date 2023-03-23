using EndGame.CharacterUnits;
using EndGame.Items;
using EndGame.HelperMethods;
using System;

namespace EndGame.UnitActions;

public static class UnitAction
{
    public static void DoNothing(CharacterUnit target, CharacterUnit self)
    {
        Console.WriteLine($"{self.Name} DID NOTHING.");
        Console.WriteLine();
    }
    public static void UseItem(CharacterUnit target, CharacterUnit self)
    {
        List<HealingItem> healingItems = self.Inventory?.Where(i => i != null && i.Type == Itemtype.Healing).OfType<HealingItem>().ToList();

        if (self.GetType() == typeof(Enemy))
        {
            HelperMethod.EnemyHealingItemHandler(self, target, healingItems);
        }

        else if (self.GetType() == typeof(Hero) && self.Inventory.Count <= 0)
        {
            Console.WriteLine($"{self.Name} fumbles around in their bag, its empty!");
        }

        else if (self.GetType() == typeof(Hero) && self.Inventory.Count != 0)
        {
            Console.WriteLine("+++++++++ Select Item +++++++++\n");
            foreach (HealingItem item in healingItems)
            {
                Console.WriteLine($"{healingItems.IndexOf(item) + 1} - {item.ItemName}");
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++");

            var choice = Console.ReadKey(true).Key;
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    {
                        HelperMethod.UseHealingItem(self, healingItems[0]);
                        self.Inventory.Remove(healingItems[0]);
                        Console.WriteLine();
                    }
                    return;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    {
                        Console.WriteLine($"{self.Name} used {healingItems[1].ItemName}");
                        self.Inventory.Remove(healingItems[1]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    {
                        Console.WriteLine($"{self.Name} used {healingItems[2].ItemName}");
                        self.Inventory.Remove(healingItems[2]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    {
                        Console.WriteLine($"{self.Name} used {healingItems[3].ItemName}");
                        self.Inventory.Remove(healingItems[3]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    {
                        Console.WriteLine($"{self.Name} used {healingItems[4].ItemName}");
                        self.Inventory.Remove(healingItems[4]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    {
                        Console.WriteLine($"{self.Name} used {healingItems[5].ItemName}");
                        self.Inventory.Remove(healingItems[5]);
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
    public static void Equip(CharacterUnit target, CharacterUnit self)
    {
        List<Weapon> weapons = self.Inventory?.Where(i => i != null && i.Type == Itemtype.Weapon).OfType<Weapon>().ToList();

        if (self.GetType() == typeof(Enemy))
        {
            HelperMethod.EnemyEquipHandler(self, target, weapons);
        }

        else if (self.GetType() == typeof(Hero) && weapons.Count == 0)
        {
            Console.WriteLine($"{self.Name} fumbles around in their bag, its empty!");
        }

        else
        {
            Console.WriteLine("\n++++++++ Select Weapon ++++++++\n");
            foreach (Weapon weapon in weapons)
            {
                Console.WriteLine($"{weapons.IndexOf(weapon) + 1} - {weapon.ItemName}");
            }
            Console.WriteLine("\n+++++++++++++++++++++++++++++++");

            var choice = Console.ReadKey(true).Key;
            switch (choice)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    {
                        HelperMethod.EquipWeapon(self, weapons[0], weapons);
                        self.Inventory.Remove(weapons[0]);
                        Console.WriteLine();
                    }
                    return;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    {
                        HelperMethod.EquipWeapon(self, weapons[1], weapons);
                        self.Inventory.Remove(weapons[1]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    {
                        HelperMethod.EquipWeapon(self, weapons[2], weapons);
                        self.Inventory.Remove(weapons[2]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    {
                        HelperMethod.EquipWeapon(self, weapons[3], weapons);
                        self.Inventory.Remove(weapons[3]);
                        Console.WriteLine();
                    }
                    return;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    {
                        HelperMethod.EquipWeapon(self, weapons[4], weapons);
                        self.Inventory.Remove(weapons[4]);
                        Console.WriteLine();
                    }
                    break;
                case ConsoleKey.NumPad6:
                case ConsoleKey.D6:
                    {
                        HelperMethod.EquipWeapon(self, weapons[5], weapons);
                        self.Inventory.Remove(weapons[5]);
                        Console.WriteLine();
                    }
                    break;
            }
        }
    }
    public static void Punch(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(1 + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} used PUNCH on {target.Name}...");

        Console.WriteLine($"PUNCH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");

        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void BoneCrunch(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(new Random().Next(2) + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} used BONE CRUNCH on {target.Name}...");

        Console.WriteLine($"BONE CRUNCH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Bite(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(1 + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} BIT {target.Name}...");

        Console.WriteLine($"BITE did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Unraveling(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(new Random().Next(5) + HelperMethod.ResolveDefense(target, AttackType.Decoding));
        Console.WriteLine($"{self.Name} used UNRAVELING on {target.Name}...");

        Console.WriteLine($"UNRAVELING did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }

    //Weapon Actions
    public static void Slash(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} SLASHED {target.Name}...");

        Console.WriteLine($"SLASH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Stab(CharacterUnit target, CharacterUnit self)
    {
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} STABBED {target.Name}...");

        Console.WriteLine($"STAB did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void QuickShot(CharacterUnit target, CharacterUnit self)
    {
        Random random = new();
        int hitRoll = random.Next(2);

        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        Console.WriteLine($"{self.Name} used QUICK SHOT on {target.Name}...");

        if (hitRoll <= 0)
        {
            Console.WriteLine($"QUICKSHOT did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
            target.CurrentHP -= damage;
        }
        else if (hitRoll > 0)
        {
            Console.WriteLine("QUICKSHOT MISSED");
        }

        HelperMethod.AttackMessaging(target);
    }
}

public enum AttackType { Normal, Decoding, None }