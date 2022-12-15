using UnityEngine;

public class GameComponents : MonoBehaviour
{
    private GameComponent[] _components;

    private MiniGame _miniGame;

    public void Init(MiniGame miniGame)
    {
        _miniGame = miniGame;
        _components = GetComponentsInChildren<GameComponent>();

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
}
