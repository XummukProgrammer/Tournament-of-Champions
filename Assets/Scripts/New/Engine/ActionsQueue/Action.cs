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

    public static event ConditionDelegate OnIsStart;
    public static event DefaultDelegate OnStart;
    
    public static event ConditionDelegate OnIsExecute;
    public static event DefaultDelegate OnExecute;

    public static event ConditionDelegate OnIsFinish;
    public static event DefaultDelegate OnFinish;

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

            OnStart?.Invoke();
        }
    }

    private void StartStateUpdate()
    {
        if (IsExecute())
        {
            _state = ActionState.Execute;

            OnExecute?.Invoke();
        }
    }

    private void ExecuteStateUpdate()
    {
        if (IsFinish())
        {
            _state = ActionState.Finish;

            OnFinish?.Invoke();
        }
    }

    private void FinishStateUpdate()
    {
        _state = ActionState.Destroy;
    }

    private bool IsStart()
    {
        return OnIsStart == null || OnIsStart();
    }

    private bool IsExecute()
    {
        return OnIsExecute == null || OnIsExecute();
    }

    private bool IsFinish()
    {
        return OnIsFinish == null || OnIsFinish();
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }
}
