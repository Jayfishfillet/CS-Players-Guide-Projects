namespace EndGame.CharacterUnits;

class CharacterUnit
{
    //Unit stats
    public string Name { get; init; }
    public byte HP { get; set; }

    //Unit Information
    protected Party unitParty;
    protected enum Party { Hero, Monster }
    protected List<Action> Actions { get; init; }

    public CharacterUnit(string name, List<Action> unitActions)
    {
        Name = name;
        Actions = unitActions;
    }

    public void PerformAction(int index)
    {
        Console.Write(Name + " ");
        Actions[index].Invoke();
    }
}

class Enemy : CharacterUnit
{
    public Enemy(string name, List<Action> unitActions) : base(name, unitActions)
    {
    }
}

class Hero : CharacterUnit
{
    public Hero(string name, List<Action> unitActions) : base(name, unitActions)
    {
    }
}