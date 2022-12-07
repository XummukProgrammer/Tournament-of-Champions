using UnityEngine;

public class Game
{
    string[] _levelsChain;
    int _currentLevelChainNumber = -1;
    string _currentLevelChainId;

    TargetBuilder _targetBuilder;
    Player _player = new Player();

    Camera _camera;
    GameState _state;

    public void Init(TargetBuilder targetBuilder, Camera camera, string[] levelsChain)
    {
        _state = GameState.InProgress;

        _targetBuilder = targetBuilder;
        _camera = camera;
        _levelsChain = levelsChain;

        _player.Init(this);

        IncrementLevelChain();
    }

    public void Update()
    {
        switch (_state)
        {
            case GameState.MainMenu:
                break;
            case GameState.PauseMenu:
                break;
            case GameState.InProgress:
                _player.Update();
                CheckWinCondition();
                break;
            case GameState.Win:
                Debug.Log("Win!!!");
                break;
            case GameState.Lose:
                break;
            default:
                break;
        }
    }

    public Target GetTargetInMouseArea()
    {
        RaycastHit2D hit = Physics2D.Raycast(_camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            var targetBehaviour = hit.collider.GetComponent<TargetBehaviour>();
            if (targetBehaviour != null)
            {
                return targetBehaviour.Controller;
            }
        }
        return null;
    }

    public void DestroyTarget(Target controller)
    {
        controller.Destroy();
        _targetBuilder.DestroyController(controller);
    }

    private void IncrementLevelChain()
    {
        ++_currentLevelChainNumber;

        if (_currentLevelChainNumber >= _levelsChain.Length)
        {
            _state = GameState.Win;
        }
        else
        {
            _currentLevelChainId = _levelsChain[_currentLevelChainNumber];
            _targetBuilder.Load(_currentLevelChainId);
        }
    }

    private void CheckWinCondition()
    {
        if (_targetBuilder.Controllers.Count == 0)
        {
            IncrementLevelChain();
        }
    }
}
