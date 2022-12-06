using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private TargetBuilder _targetBuilder;
    [SerializeField] private Camera _camera;

    Game _game = new Game();

    private void Start()
    {
        _game.Init(_targetBuilder, _camera);
    }

    private void Update()
    {
        _game.Update();
    }
}
