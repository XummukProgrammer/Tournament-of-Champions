public enum ActionState
{
    Active,
    Start,
    Execute,
    Finish,
    Destroy
}

public class Action
{
    private Game _game;
    private ActionState _state = ActionState.Active;

    public delegate void DefaultDelegate();
    public delegate bool ConditionDelegate();

    public ConditionDelegate IsStartDelegate;
    public DefaultDelegate StartDelegate;
    
    public ConditionDelegate IsExecuteDelegate;
    public DefaultDelegate ExecuteDelegate;

    public ConditionDelegate IsFinishDelegate;
    public DefaultDelegate FinishDelegate;

    public ActionState State => _state;
    protected Game Game => _game;

    public void Init(Game game)
    {
        _game = game;
        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
    }

    public void Update()
    {
        switch (_state)
        {
            case ActionState.Active:
                ActiveStateUpdate();
                break;
            case ActionState.Start:
                StartStateUpdate();
                break;
            case ActionState.Execute:
                ExecuteStateUpdate();
                break;
            case ActionState.Finish:
                FinishStateUpdate();
                break;
            default:
                break;
        }

        OnUpdate();
    }

    private void ActiveStateUpdate()
    {
        if (IsStart())
        {
            _state = ActionState.Start;

            StartDelegate?.Invoke();
        }
    }

    private void StartStateUpdate()
    {
        if (IsExecute())
        {
            _state = ActionState.Execute;

            ExecuteDelegate?.Invoke();
        }
    }

    private void ExecuteStateUpdate()
    {
        if (IsFinish())
        {
            _state = ActionState.Finish;

            FinishDelegate?.Invoke();
        }
    }

    private void FinishStateUpdate()
    {
        _state = ActionState.Destroy;
    }

    private bool IsStart()
    {
        return IsStartDelegate == null || IsStartDelegate();
    }

    private bool IsExecute()
    {
        return IsExecuteDelegate == null || IsExecuteDelegate();
    }

    private bool IsFinish()
    {
        return IsFinishDelegate == null || IsFinishDelegate();
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }
}
