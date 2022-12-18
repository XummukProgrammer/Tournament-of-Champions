using System.Collections.Generic;

public class ActionsQueue
{
    private EntryPoint _entryPoint;
    private List<Action> _actions = new List<Action>();

    public void Init(EntryPoint entryPoint)
    {
        _entryPoint = entryPoint;
    }

    public void Deinit()
    {
        foreach (var action in _actions)
        {
            action.Deinit();
        }

        _actions.Clear();
    }

    public void Update()
    {
        if (_actions.Count == 0)
        {
            return;
        }

        var action = _actions[0];

        action.Update();

        if (action.State == ActionState.Destroy)
        {
            action.Deinit();
            _actions.Remove(action);
        }
    }

    public void AddAction(Action action)
    {
        action.Init(_entryPoint);
        _actions.Add(action);
    }
}
