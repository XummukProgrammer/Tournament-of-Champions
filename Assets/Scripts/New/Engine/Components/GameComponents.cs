using UnityEngine;

public class GameComponents : MonoBehaviour
{
    private GameComponent[] _components;

    private Game _game;

    public void Init(Game game)
    {
        _game = game;
        _components = GetComponentsInChildren<GameComponent>();

        foreach (var component in _components)
        {
            component.Init(_game);
        }
    }

    public void Deinit()
    {
        foreach (var component in _components)
        {
            component.Deinit(_game);
        }
    }
}
