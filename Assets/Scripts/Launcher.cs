using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private TargetBuilder _targetBuilder;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameAsset _gameAsset;

    Game _game = new Game();

    private void Start()
    {
        _game.Init(_targetBuilder, _camera, _gameAsset.LevelsChain);
    }

    private void Update()
    {
        _game.Update();
    }
}
