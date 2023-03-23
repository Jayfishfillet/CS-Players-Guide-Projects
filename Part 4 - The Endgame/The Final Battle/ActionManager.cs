using EndGame.CharacterUnits;
namespace EndGame.ActionManagement;

public class ActionManager
{
    public List<Action<CharacterUnit, CharacterUnit>> actionList = new();
    public ActionManager(params Action<CharacterUnit, CharacterUnit>[] actions)
    {
        foreach (Action<CharacterUnit, CharacterUnit> action in actions)
        {
            actionList.Add(action);
        }
    }
}