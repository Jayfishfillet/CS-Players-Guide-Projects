namespace EndGame.UnitActions;

public static class UnitActions
{
    public static List<Action> BasicActions = new List<Action>();
    static UnitActions()
    {
        BasicActions.Add(DoNothing);
    }
    public static void DoNothing()
    {
        Console.WriteLine("did nothing...\n");
    }
}