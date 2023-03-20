using EndGame.ActionManagement;
namespace EndGame.CharacterUnits;

public class CharacterUnit
{
    //Unit stats
    public string Name { get; init; }
    public int MaxHP { get; init; }
    public int CurrentHP { get; set; }
    public bool isAlive { get; set; } = true;
    public List<Action<CharacterUnit>> Actions { get; init; }

    public CharacterUnit(string name, ActionManager actionManager, int maxHP)
    {
        Name = name;
        Actions = actionManager.actionList;
        CurrentHP = MaxHP = maxHP;
    }

    public void PerformAction(int index, CharacterUnit target)
    {
        Console.Write(Name + " ");
        Actions[index].Invoke(target);
    }
}

class Enemy : CharacterUnit
{
    public Enemy(string name, ActionManager actionManager, int maxHP) : base(name, actionManager, maxHP)
    {
    }
}

class Hero : CharacterUnit
{
    public Hero(string name, ActionManager actionManager, int maxHP) : base(name, actionManager, maxHP)
    {
    }
}