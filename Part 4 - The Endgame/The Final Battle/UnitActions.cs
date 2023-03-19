using EndGame.CharacterUnits;

namespace EndGame.UnitActions;

public static class UnitActions
{
    public static void Punch(CharacterUnit target)
    {
        int damage = 3;
        Console.WriteLine($"used PUNCH on {target.Name}");
        if (target.CurrentHP > 0)
        {
            Console.WriteLine($"PUNCH did {damage} damage!");
            target.CurrentHP -= damage;
        }
        else Console.WriteLine("PUNCH did no damage");
        Console.WriteLine($"{target.Name} has {HPClamper(target.CurrentHP)}/{target.MaxHP}");
        DeathCheck(target);
        Console.WriteLine();
    }
    public static void BoneCrunch(CharacterUnit target)
    {
        Console.WriteLine($"used BONE CRUNCH on {target.Name}");
        if (target.CurrentHP > 0)
        {
            int damageRoll = new Random().Next(2);
            Console.WriteLine($"BONE CRUNCH did {damageRoll} damage!");
            target.CurrentHP -= damageRoll;
        }
        else Console.WriteLine("BONE CRUNCH did no damage");
        Console.WriteLine($"{target.Name} has {HPClamper(target.CurrentHP)}/{target.MaxHP}");
        Console.WriteLine();
    }

    private static void DeathCheck(CharacterUnit target)
    {
        if (target.CurrentHP <= 0)
        {
            target.isAlive = false;
            Console.WriteLine($"{target.Name} has been slain!");
        }
    }

    private static int HPClamper(int hP)
    {
        return Math.Clamp(hP, 0, 100);
    }
}