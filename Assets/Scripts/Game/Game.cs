using UnityEngine;

public class Game
{
    public System.Action<int> LevelChanged;
    public System.Action Winned;

    string[] _levelsChain;
    int _currentLevelChainNumber = -1;
    string _currentLevelChainId;

    TargetBuilder _targetBuilder;
    Player _player = new Player();

    Camera _camera;
    GameState _state;

    WeaponBehaviour _weaponBehaviour;
    ScoreNumberBehaviour _scoreNumberBehaviour;

    DebugPanel _debugPanel = new DebugPanel();

    public void Init(TargetBuilder targetBuilder, Camera camera, string[] levelsChain, 
        string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, float playerWeaponReloadDelay, 
        Vector2[] playerWeaponAccuracyOffsets, float playerWeaponAccuracyChangeDelay,
        WeaponBehaviour weaponBehaviour, DebugPanelBehaviour debugPanelBehaviour, ScoreNumberBehaviour scoreNumberBehaviour)
    {
        _targetBuilder = targetBuilder;
        _camera = camera;
        _levelsChain = levelsChain;
        _weaponBehaviour = weaponBehaviour;
        _scoreNumberBehaviour = scoreNumberBehaviour;

        _debugPanel.Init(debugPanelBehaviour);

        StartGame(playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyOffsets, playerWeaponAccuracyChangeDelay);
    }

    public void Update()
    {
        _debugPanel.Update();

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

    public (Target, TargetZoneBehaviour) GetTargetInMouseArea(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);

        if (hit.collider != null)
        {
            var targetZoneBehaviour = hit.collider.GetComponent<TargetZoneBehaviour>();
            if (targetZoneBehaviour != null)
            {
                var targetBehaviour = targetZoneBehaviour.GetComponentInParent<TargetBehaviour>();
                if (targetBehaviour != null)
                {
                    return (targetBehaviour.Controller, targetZoneBehaviour);
                }
            }
        }
        return (null, null);
    }

    public void DestroyTarget(Target controller)
    {
        controller.Destroy();
        _targetBuilder.DestroyController(controller);
    }

    private void StartGame(string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, 
        float playerWeaponReloadDelay, Vector2[] playerWeaponAccuracyOffsets, float playerWeaponAccuracyChangeDelay)
    {
        _player.Init(this, playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyOffsets, playerWeaponAccuracyChangeDelay,
            _weaponBehaviour, _scoreNumberBehaviour);

        ResetGame();
        IncrementLevelChain();
    }

    private void ResetGame()
    {
        SetState(GameState.InProgress);
        _currentLevelChainNumber = -1;
    }

    private void IncrementLevelChain()
    {
        ++_currentLevelChainNumber;

        if (_currentLevelChainNumber >= _levelsChain.Length)
        {
            SetState(GameState.Win);
            Winned?.Invoke();
        }
        else
        {
            _currentLevelChainId = _levelsChain[_currentLevelChainNumber];
            _targetBuilder.Load(_currentLevelChainId);
            LevelChanged?.Invoke(_currentLevelChainNumber);
        }
    }

    private void CheckWinCondition()
    {
        if (_targetBuilder.Controllers.Count == 0)
        {
            IncrementLevelChain();
        }
    }

    private void SetState(GameState state)
    {
        _state = state;
        _debugPanel.UpdateInfo("state", $"Стейт: {_state}");
    }

    public Vector3 GetMousePosition()
    {
        return _camera.ScreenToWorldPoint(Input.mousePosition);
    }
}
