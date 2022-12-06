using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private TargetBuilder _targetBuilder;

    Game _game = new Game();

    private void Start()
    {
        _game.Init(_targetBuilder);
    }
}
