using EndGame.CharacterUnits;
namespace EndGame.ActionManagement;

public class ActionManager
{
    public List<Action<CharacterUnit>> actionList = new();
    public ActionManager(params Action<CharacterUnit>[] actions)
    {
        foreach (Action<CharacterUnit> action in actions)
        {
            actionList.Add(action);
        }
    }
}