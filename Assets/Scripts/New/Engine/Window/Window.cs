using UnityEngine;

public class Window : IController
{
    private Game _game;
    private WindowBehaviour _prefab;
    private Transform _container;
    private WindowBehaviour _behaviour;

    public Game Game => _game;
    public WindowBehaviour Behaviour => _behaviour;

    public void InitWithParams(Game game, WindowBehaviour prefab, Transform container)
    {
        _game = game;
        _prefab = prefab;
        _container = container;
    }

    public void Init()
    {
    }

    public void Deinit()
    {
    }

    public void Update()
    {
        OnUpdate();
    }

    public void Create()
    {
        _behaviour = GameObject.Instantiate(_prefab, _container);
        OnCreate();
        _behaviour.Init();
    }

    public void Destroy()
    {
        OnDestroy();
        _behaviour.Deinit();
        GameObject.Destroy(_behaviour.gameObject);
    }

    public void Show()
    {
        _behaviour.Show();
        OnShow();
    }

    public void Hide()
    {
        _behaviour.Hide();
        OnHide();
    }

    public void OpenByAction()
    {
        var action = new WindowAction();
        action.Open(this);
        Game.ActonsQueue.AddAction(action);
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnCreate() { }
    protected virtual void OnDestroy() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
