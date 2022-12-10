using UnityEngine;

public class Game
{
    public System.Action<int> LevelChanged;
    public System.Action Winned;
    public System.Action Losed;

    string[] _levelsChain;
    int _currentLevelChainNumber = -1;
    string _currentLevelChainId;

    TargetBuilder _targetBuilder;
    Player _player = new Player();

    Camera _camera;
    GameState _state;

    WeaponBehaviour _weaponBehaviour;
    ScoreNumberBehaviour _scoreNumberBehaviour;
    CursorBehaviour _cursorBehaviour;

    DebugPanel _debugPanel = new DebugPanel();
    LoseTimer _loseTimer = new LoseTimer();

    YaAdsManager _yaAdsManager = new YaAdsManager();
    YaPurchasesManager _yaPurchasesManager = new YaPurchasesManager();

    public LoseTimer LoseTimer => _loseTimer;

    public void Init(TargetBuilder targetBuilder, Camera camera, string[] levelsChain, 
        string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, float playerWeaponReloadDelay,
        WeaponAccuracyBehaviour playerWeaponAccuracyBehaviour, float playerWeaponAccuracyChangeDelay,
        WeaponBehaviour weaponBehaviour, DebugPanelBehaviour debugPanelBehaviour, ScoreNumberBehaviour scoreNumberBehaviour, 
        LoseTimerBehaviour loseTimerBehaviour, CursorBehaviour cursorBehaviour,
        YaAdsBehaviour yaAdsBehaviour, YaPurchasesBehaviour yaPurchasesBehaviour)
    {
        Cursor.visible = false;

        _targetBuilder = targetBuilder;
        _camera = camera;
        _levelsChain = levelsChain;
        _weaponBehaviour = weaponBehaviour;
        _scoreNumberBehaviour = scoreNumberBehaviour;
        _cursorBehaviour = cursorBehaviour;

        loseTimerBehaviour.Init(_loseTimer);

        _debugPanel.Init(debugPanelBehaviour);

        _yaAdsManager.Init(this);
        _yaAdsManager.AddReward(new YaAdsAddTimeReward());
        yaAdsBehaviour.Init(_yaAdsManager);

        _yaPurchasesManager.Init(this);
        _yaPurchasesManager.AddPurchase(new YaAddTimePurchase());
        yaPurchasesBehaviour.Init(_yaPurchasesManager);

        StartGame(playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyBehaviour, playerWeaponAccuracyChangeDelay);
    }

    public void Deinit()
    {
        _yaAdsManager.Deinit();
        _yaPurchasesManager.Deinit();
    }

    public void Update()
    {
        _debugPanel.Update();
        _loseTimer.Update();

        switch (_state)
        {
            case GameState.MainMenu:
                break;
            case GameState.PauseMenu:
                break;
            case GameState.InProgress:
                _player.Update();
                if (CheckWinCondition())
                {
                    IncrementLevelChain();
                }
                else if (CheckLoseCondition())
                {
                    _targetBuilder.DestroyAllControllers();
                    SetState(GameState.Lose);
                    Losed?.Invoke();
                }
                break;
            case GameState.Win:
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
        float playerWeaponReloadDelay, WeaponAccuracyBehaviour playerWeaponAccuracyBehaviour, float playerWeaponAccuracyChangeDelay)
    {
        _player.Init(this, playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyBehaviour, playerWeaponAccuracyChangeDelay,
            _weaponBehaviour, _scoreNumberBehaviour, _cursorBehaviour);

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
            _targetBuilder.Load(_currentLevelChainId, _loseTimer);
            LevelChanged?.Invoke(_currentLevelChainNumber);
        }
    }

    private bool CheckWinCondition()
    {
        if (_targetBuilder.Controllers.Count == 0)
        {
            return true;
        }
        return false;
    }

    private bool CheckLoseCondition()
    {
        return _loseTimer.IsLose();
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
