using UnityEngine;

public class HUD : IController
{
    private Game _game;
    private HUDBehaviour _prefab;
    private HUDBehaviour _behaviour;
    private HUDLocation _location;
    private HUDContainerBehaviour _containerBehaviour;

    public HUDBehaviour Behaviour => _behaviour;
    public Game Game => _game;

    public void InitWithParams(Game game, HUDBehaviour prefab, HUDLocation location, HUDContainerBehaviour containerBehaviour)
    {
        _game = game;
        _prefab = prefab;
        _location = location;
        _containerBehaviour = containerBehaviour;
    }

    public void Init()
    {
        _behaviour = _containerBehaviour.CreateBehaviour(_prefab, _location);
        _behaviour.Clicked += OnClick;
        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
        _behaviour.Clicked -= OnClick;
        GameObject.Destroy(_behaviour.gameObject);
    }

    public void Update()
    {
        OnUpdate();
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

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnClick() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
