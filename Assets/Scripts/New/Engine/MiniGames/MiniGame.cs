public class MiniGame
{
    private EntryPoint _entryPoint;
    private GameComponents _components;
    private MiniGameState _state = MiniGameState.Disable;

    public EntryPoint EntryPoint => _entryPoint;
    public MiniGameState State => _state;

    public void Init(EntryPoint entryPoint, GameComponents components)
    {
        _entryPoint = entryPoint;
        _components = components;

        _components.Init(this);

        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();

        _components.Deinit();
    }

    public void Update()
    {
        OnUpdate();

        switch (_state)
        {
            case MiniGameState.LoadResources:
                LoadResourcesStateUpdate();
                break;
            case MiniGameState.InProgress:
                InProgressStateUpdate();
                break;
            case MiniGameState.ShowWinWindow:
                ShowWinWindowStateUpdate();
                break;
            case MiniGameState.ShowLoseWindow:
                ShowLoseWindowStateUpdate();
                break;
            case MiniGameState.ShowRewardWindow:
                ShowRewardWindowStateUpdate();
                break;
            case MiniGameState.UnloadResources:
                UnloadResourcesStateUpdate();
                break;
            default:
                break;
        }
    }

    public void Start()
    {
        _state = MiniGameState.LoadResources;
        OnLoadResources();
    }

    private void LoadResourcesStateUpdate()
    {
        if (IsResourcesLoaded())
        {
            _state = MiniGameState.InProgress;
            OnInProgress();
        }
    }

    private void InProgressStateUpdate()
    {
        if (IsWin())
        {
            _state = MiniGameState.ShowWinWindow;
            OnWin();
            OnShowWinWindow();
        }
        else if (IsLose())
        {
            _state = MiniGameState.ShowLoseWindow;
            OnLose();
            OnShowLoseWindow();
        }
    }

    private void ShowWinWindowStateUpdate()
    {
        if (IsWinWindowShowed())
        {
            _state = MiniGameState.ShowRewardWindow;
            OnShowRewardWindow();
        }
    }

    private void ShowLoseWindowStateUpdate()
    {
        if (IsLoseWindowShowed())
        {
            _state = MiniGameState.UnloadResources;
            OnUnloadResources();
        }
    }

    private void ShowRewardWindowStateUpdate()
    {
        if (IsRewardWindowShowed())
        {
            _state = MiniGameState.UnloadResources;
            OnUnloadResources();
        }
    }

    private void UnloadResourcesStateUpdate()
    {
        if (IsResourcesUnloaded())
        {
            _state = MiniGameState.Disable;
            OnDisable();
        }
    }
    
    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnUpdate() { }

    protected virtual void OnLoadResources() { }
    protected virtual void OnUnloadResources() { }
    protected virtual void OnInProgress() { }
    protected virtual void OnWin() { }
    protected virtual void OnShowWinWindow() { }
    protected virtual void OnLose() { }
    protected virtual void OnShowLoseWindow() { }
    protected virtual void OnShowRewardWindow() { }
    protected virtual void OnDisable() { }

    protected virtual bool IsResourcesLoaded() { return false; }
    protected virtual bool IsResourcesUnloaded() { return false; }
    protected virtual bool IsWin() { return false; }
    protected virtual bool IsLose() { return false; }
    protected virtual bool IsWinWindowShowed() { return false; }
    protected virtual bool IsLoseWindowShowed() { return false; }
    protected virtual bool IsRewardWindowShowed() { return false; }
}
