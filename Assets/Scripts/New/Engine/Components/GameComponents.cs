using UnityEngine;

public class GameComponents : MonoBehaviour
{
    [SerializeField] private GameComponent[] _components;

    private Game _game;

    public GameComponent[] Components => _components;

    public void Init(Game game)
    {
        _game = game;

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
