using EndGame.CharacterUnits;
namespace EndGame.UnitActions;

public static class UnitActions
{
    public static void DoNothing(CharacterUnit target)
    {
        Console.WriteLine("DID NOTHING.");
        Console.WriteLine();
    }
    public static void UseItem(CharacterUnit target)
    { 
        
    }
    public static void Punch(CharacterUnit target)
    {
        int damage = 2;
        Console.WriteLine($"used PUNCH on {target.Name}...");

        Console.WriteLine($"PUNCH did {damage} damage!");
        target.CurrentHP -= damage;

        AttackMessaging(target);
    }
    public static void BoneCrunch(CharacterUnit target)
    {
        int damage = new Random().Next(2);
        Console.WriteLine($"used BONE CRUNCH on {target.Name}...");

        Console.WriteLine($"BONE CRUNCH did {damage} damage!");
        target.CurrentHP -= damage;

        AttackMessaging(target);
    }

    public static void Unraveling(CharacterUnit target)
    {
        int damage = new Random().Next(5);
        Console.WriteLine($"used UNRAVELING on {target.Name}...");

        Console.WriteLine($"UNRAVELING did {damage} damage!");
        target.CurrentHP -= damage;

        AttackMessaging(target);
    }

    private static void DeathCheck(CharacterUnit target)
    {
        if (target.CurrentHP <= 0)
        {
            target.isAlive = false;
            Console.WriteLine($"{target.Name} has been slain!");
        }
    }

    //Helper methods
    private static int HPClamper(int hP)
    {
        return Math.Clamp(hP, 0, 100);
    }

    private static void AttackMessaging(CharacterUnit target)
    {
        Console.WriteLine($"{target.Name} has {HPClamper(target.CurrentHP)}/{target.MaxHP} HP");
        DeathCheck(target);
        Console.WriteLine();
    }
}