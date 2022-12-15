using UnityEngine;

public class HUD : IController
{
    private EntryPoint _entryPoint;
    private HUDBehaviour _prefab;
    private HUDBehaviour _behaviour;
    private HUDLocation _location;
    private HUDContainerBehaviour _containerBehaviour;

    public HUDBehaviour Behaviour => _behaviour;
    public EntryPoint EntryPoint => _entryPoint;

    public void InitWithParams(EntryPoint entryPoint, HUDBehaviour prefab, HUDLocation location, HUDContainerBehaviour containerBehaviour)
    {
        _entryPoint = entryPoint;
        _prefab = prefab;
        _location = location;
        _containerBehaviour = containerBehaviour;
    }

    public void Init()
    {
        _behaviour = _containerBehaviour.CreateBehaviour(_prefab, _location);
        _behaviour.Clicked += OnClick;
        OnInit();
        _behaviour.Init();
    }

    public void Deinit()
    {
        _behaviour.Clicked -= OnClick;
        OnDeinit();
        _behaviour.Deinit();

        if (!_entryPoint.IsDisabled)
        {
            GameObject.Destroy(_behaviour.gameObject);
        }
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
