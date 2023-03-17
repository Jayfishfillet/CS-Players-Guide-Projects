namespace EndGame.UnitActions;

public static class UnitActions
{
    public static List<Action> BasicActions = new List<Action>();
    static UnitActions()
    {
        BasicActions.Add(DoNothing);
        BasicActions.Add(Cheer);
        BasicActions.Add(Stare);
    }
    public static void DoNothing()
    {
        Console.WriteLine("did nothing...");
        Console.WriteLine();
    }
    public static void Cheer()
    {
        Console.WriteLine("raised their hands up and shouted!");
        Console.WriteLine();
    }
    public static void Stare()
    {
        Console.WriteLine("stared off into space.");
        Console.WriteLine();
    }
}