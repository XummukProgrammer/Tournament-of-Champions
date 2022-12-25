using UnityEngine;

public class Effect
{
    private EntryPoint _entryPoint;
    private Transform _container;
    private Transform _parent;

    protected Transform Container => _container;
    protected Transform Parent => _parent;
    protected EntryPoint EntryPoint => _entryPoint;

    public void Init(EntryPoint entryPoint, Transform container)
    {
        _entryPoint = entryPoint;
        _container = container;

        OnInit();
    }

    public void Deinit()
    {
        OnDeinit();
    }

    public void Play(Transform parent)
    {
        _parent = parent;
        OnPlay();
    }

    public void Stop()
    {
        OnStop();
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    protected virtual void OnPlay() { }
    protected virtual void OnStop() { }

    public virtual bool IsDestroy() { return false; }
}
