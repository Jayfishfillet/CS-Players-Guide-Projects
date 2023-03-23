using EndGame.CharacterUnits;
using EndGame.Items;
using EndGame.HelperMethods;

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
        List<HealingItem>? healingItems = self.Inventory?.Where(i => i != null && i.Type == Itemtype.Healing).OfType<HealingItem>().Distinct().ToList();
        try
        {

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
                Console.WriteLine("++++++++++++++ Select Item ++++++++++++++\n");
                foreach (HealingItem item in healingItems)
                {
                    Console.WriteLine($"{healingItems.IndexOf(item) + 1} - {item.ItemName}");
                }
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++");

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
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[1]);
                            self.Inventory.Remove(healingItems[1]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[2]);
                            self.Inventory.Remove(healingItems[2]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[3]);
                            self.Inventory.Remove(healingItems[3]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[4]);
                            self.Inventory.Remove(healingItems[4]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[5]);
                            self.Inventory.Remove(healingItems[5]);
                            Console.WriteLine();
                        }
                        break;
                    default:
                        {
                            HelperMethod.UseHealingItem(self, healingItems[0]);
                            Console.WriteLine($"{self.Name} used {healingItems[0].ItemName}");
                            self.Inventory.Remove(healingItems[0]);
                            Console.WriteLine();
                        }
                        break;
                }

            }
        }
        catch (Exception)
        {
            HelperMethod.UseHealingItem(self, healingItems[0]);
            self.Inventory.Remove(healingItems[0]);
            Console.WriteLine();
        }

    }
    public static void Equip(CharacterUnit target, CharacterUnit self)
    {
        List<Weapon>? weapons = self.Inventory?.Where(i => i != null && i.Type == Itemtype.Weapon).OfType<Weapon>().Distinct().ToList();

        try
        {
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
                Console.WriteLine("\n+++++++++++++ Select Weapon +++++++++++++\n");
                foreach (Weapon weapon in weapons)
                {
                    Console.WriteLine($"{weapons.IndexOf(weapon) + 1} - {weapon.ItemName}");
                }
                Console.WriteLine("\n+++++++++++++++++++++++++++++++++++++++++");

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
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        {
                            HelperMethod.EquipWeapon(self, weapons[6], weapons);
                            self.Inventory.Remove(weapons[6]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        {
                            HelperMethod.EquipWeapon(self, weapons[7], weapons);
                            self.Inventory.Remove(weapons[7]);
                            Console.WriteLine();
                        }
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        {
                            HelperMethod.EquipWeapon(self, weapons[8], weapons);
                            self.Inventory.Remove(weapons[8]);
                            Console.WriteLine();
                        }
                        break;
                }
            }
        }
        catch (Exception)
        {
            HelperMethod.EquipWeapon(self, weapons[0], weapons);
            self.Inventory.Remove(weapons[0]);
            Console.WriteLine();
        }
    }
    public static void Punch(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 5;
        int damage = HelperMethod.Clamper(1 + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} used PUNCH on {target.Name}...");

        Console.WriteLine($"PUNCH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");

        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void BoneCrunch(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 5;
        int damage = HelperMethod.Clamper(new Random().Next(2) + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} used BONE CRUNCH on {target.Name}...");

        Console.WriteLine($"BONE CRUNCH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Bite(CharacterUnit target, CharacterUnit self)
    {
        
        int critChance = 5;
        int damage = HelperMethod.Clamper(1 + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} BIT {target.Name}...");
        Console.WriteLine($"BITE did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Unraveling(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 50;
        int damage = HelperMethod.Clamper((new Random().Next(8) + 1) + HelperMethod.ResolveDefense(target, AttackType.Decoding));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} used UNRAVELING on {target.Name}...");
        Console.WriteLine($"UNRAVELING did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void ReCompile(CharacterUnit target, CharacterUnit self)
    {
        int healAmount = 10;
        Console.WriteLine($"{self.Name} used RECOMPILE...");
        Console.WriteLine($"{self.Name} resotred {healAmount} HP!");
        self.CurrentHP += healAmount;
    }

    //Weapon Actions
    public static void Slash(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 8;
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} SLASHED {target.Name}...");
        Console.WriteLine($"SLASH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void VariableSlash(CharacterUnit target, CharacterUnit self)
    {
        int multipleAttack = new Random().Next(1, 4);
        int critChance = 10;
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance) * multipleAttack;

        Console.WriteLine($"{self.Name} SLASHED at {target.Name} {multipleAttack} time(s)...");
        Console.WriteLine($"Variable Slash did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void CodeforgeSlash(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 0;
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} SLASHED {target.Name}...");
        Console.WriteLine($"CODEFORGE SLASH did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("CodeForge Slash Empowered the Sword of Creation! Attack increased by 1!");
        Console.ResetColor();
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
        self.CurrentWeapon.AttackDamage++;
    }
    public static void Stab(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 5;
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} STABBED {target.Name}...");
        Console.WriteLine($"STAB did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void QuickShot(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 10;
        Random random = new();
        int hitRoll = random.Next(1, 3);

        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} used QUICK SHOT on {target.Name}...");

        if (hitRoll > 1)
        {
            Console.WriteLine($"QUICKSHOT did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
            target.CurrentHP -= damage;
        }
        else if (hitRoll <= 1)
        {
            Console.WriteLine("QUICKSHOT MISSED");
        }

        HelperMethod.AttackMessaging(target);
    }
    public static void BinaryShot(CharacterUnit target, CharacterUnit self)
    {
        int multipleAttack = 2;
        int critChance = 20;
        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Normal));
        damage = HelperMethod.CriticalRoll(damage, critChance) * multipleAttack;

        Console.WriteLine($"{self.Name} SHOT at {target.Name} {multipleAttack} times...");
        Console.WriteLine($"BINARY SHOT did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
        target.CurrentHP -= damage;
        HelperMethod.AttackMessaging(target);
    }
    public static void Decompile(CharacterUnit target, CharacterUnit self)
    {
        int critChance = 50;
        Random random = new();
        int hitRoll = random.Next(5);

        int damage = HelperMethod.Clamper(self.CurrentWeapon.AttackDamage + HelperMethod.ResolveDefense(target, AttackType.Decoding));
        damage = HelperMethod.CriticalRoll(damage, critChance);

        Console.WriteLine($"{self.Name} used DECOMPILE on {target.Name}...");

        if (hitRoll <= 0)
        {
            Console.WriteLine($"DECOMPILE did {damage} {AttackType.Normal.ToString().ToUpper()} damage!");
            target.CurrentHP -= damage;
        }
        else if (hitRoll > 0)
        {
            Console.WriteLine("DECOMPILE MISSED");
        }

        HelperMethod.AttackMessaging(target);
    }
}

public enum AttackType { Normal, Decoding, None }