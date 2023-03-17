using EndGame.CharacterUnits;

namespace EndGame.UnitActions;

public static class UnitActions
{
    public static void DoNothing(CharacterUnit target)
    {
        Console.WriteLine("did NOTHING...");
        Console.WriteLine();
    }
    public static void Punch(CharacterUnit target)
    {
        Console.WriteLine($"used PUNCH on {target.Name}");
        Console.WriteLine();
    }
    public static void BoneCrunch(CharacterUnit target)
    {
        Console.WriteLine($"used BONE CRUNCH on {target.Name}");
        Console.WriteLine();
    }
}