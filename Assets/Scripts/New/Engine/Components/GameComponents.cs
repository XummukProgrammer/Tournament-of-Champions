using UnityEngine;

public class GameComponents : MonoBehaviour
{
    private BaseGameComponent[] _components;

    private MiniGame _miniGame;

    public void Init(MiniGame miniGame)
    {
        _miniGame = miniGame;
        _components = GetComponentsInChildren<BaseGameComponent>();

        foreach (var component in _components)
        {
            component.Init(_miniGame);
        }
    }

    public void Deinit()
    {
        foreach (var component in _components)
        {
            component.Deinit();
        }
    }

    public void OnUpdate()
    {
        foreach (var component in _components)
        {
            component.OnUpdate();
        }
    }
}
