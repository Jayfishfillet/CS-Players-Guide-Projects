using EndGame.ActionManagement;

namespace EndGame.CharacterUnits;

public class CharacterUnit
{
    //Unit stats
    public string Name { get; init; }
    public byte HP { get; set; }

    //Unit Information
    public List<Action<CharacterUnit>> Actions { get; init; }

    public CharacterUnit(string name, ActionManager actionManager)
    {
        Name = name;
        Actions = actionManager.actionList;
    }

    public void PerformAction(int index, CharacterUnit target)
    {
        Console.Write(Name + " ");
        Actions[index].Invoke(target);
    }
}

class Enemy : CharacterUnit
{
    public Enemy(string name, ActionManager actionManager) : base(name, actionManager)
    {
    }
}

class Hero : CharacterUnit
{
    public Hero(string name, ActionManager actionManager) : base(name, actionManager)
    {
    }
}