using UnityEngine;

public class GameComponent : MonoBehaviour
{
    private MiniGame _miniGame;

    protected MiniGame MiniGame => _miniGame;

    public void Init(MiniGame miniGame) 
    {
        _miniGame = miniGame;
        OnInit();
    }

    public void Deinit() 
    {
        OnDeinit();
    }

    protected virtual void OnInit() { }
    protected virtual void OnDeinit() { }
    public virtual void OnUpdate() { }
}
