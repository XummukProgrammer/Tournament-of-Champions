using UnityEngine;

public class BaseGameComponent : MonoBehaviour
{
    public virtual void Init(MiniGame miniGame) { }
    public virtual void PostInit() { }
    public virtual void Deinit() { }

    public virtual void OnUpdate() { }
}

public class GameComponent<T> : BaseGameComponent where T : MiniGame
{
    private T _miniGame;

    protected T MiniGame => _miniGame;

    public override void Init(MiniGame miniGame) 
    {
        base.Init(miniGame);

        _miniGame = miniGame as T;
        OnInit();
    }

    public override void PostInit()
    {
        base.PostInit();

        OnPostInit();
    }

    public override void Deinit() 
    {
        base.Deinit();

        OnDeinit();
    }

    protected virtual void OnInit() { }
    protected virtual void OnPostInit() { }
    protected virtual void OnDeinit() { }
}
