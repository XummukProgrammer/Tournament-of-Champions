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

    public void Init(TargetBuilder targetBuilder, Camera camera, string[] levelsChain, string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, float playerWeaponReloadDelay, WeaponBehaviour weaponBehaviour)
    {
        _targetBuilder = targetBuilder;
        _camera = camera;
        _levelsChain = levelsChain;
        _weaponBehaviour = weaponBehaviour;

        StartGame(playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay);
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

    private void StartGame(string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, float playerWeaponReloadDelay)
    {
        _player.Init(this, playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, _weaponBehaviour);

        ResetGame();
        IncrementLevelChain();
    }

    private void ResetGame()
    {
        _state = GameState.InProgress;
        _currentLevelChainNumber = -1;
    }

    private void IncrementLevelChain()
    {
        ++_currentLevelChainNumber;

        if (_currentLevelChainNumber >= _levelsChain.Length)
        {
            _state = GameState.Win;
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
}
