using UnityEngine;

public class Window : IController
{
    private EntryPoint _entryPoint;
    private WindowBehaviour _prefab;
    private Transform _container;
    private WindowBehaviour _behaviour;

    public EntryPoint EntryPoint => _entryPoint;
    public WindowBehaviour Behaviour => _behaviour;

    public void InitWithParams(EntryPoint entryPoint, WindowBehaviour prefab, Transform container)
    {
        _entryPoint = entryPoint;
        _prefab = prefab;
        _container = container;
    }

    public void Init()
    {
        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
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

        EntryPoint.ActonsQueue.AddAction(action);
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnCreate() { }
    protected virtual void OnDestroy() { }
    protected virtual void OnUpdate() { }
    protected virtual void OnShow() { }
    protected virtual void OnHide() { }

    public virtual bool IsClose() { return false;  }
}
