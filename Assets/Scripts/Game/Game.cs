using UnityEngine;

public class Game
{
    public System.Action<int> LevelChanged;
    public System.Action Winned;
    public System.Action Losed;

    private Player _player = new Player();

    private Camera _camera;
    private GameState _state;

    private WeaponBehaviour _weaponBehaviour;
    private CursorBehaviour _cursorBehaviour;

    private DebugPanel _debugPanel = new DebugPanel();
    private LoseTimer _loseTimer = new LoseTimer();

    private YaAdsManager _yaAdsManager = new YaAdsManager();
    private YaPurchasesManager _yaPurchasesManager = new YaPurchasesManager();

    private Level _level = new Level();

    private HUDManager _hudManager = new HUDManager();

    public LoseTimer LoseTimer => _loseTimer;
    public HUDManager HUDManager => _hudManager;
    public Player Player => _player;

    public void Init(Camera camera, 
        string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, float playerWeaponReloadDelay,
        WeaponAccuracyBehaviour playerWeaponAccuracyBehaviour, float playerWeaponAccuracyChangeDelay,
        WeaponBehaviour weaponBehaviour, DebugPanelBehaviour debugPanelBehaviour, 
        LoseTimerBehaviour loseTimerBehaviour, CursorBehaviour cursorBehaviour,
        YaAdsBehaviour yaAdsBehaviour, YaPurchasesBehaviour yaPurchasesBehaviour,
        LevelAsset levelAsset, Transform controllersContainer,
        HUDContainerBehaviour hudContainerBehaviour, CoinHUDBehaviour _coinHUDPrefab)
    {
        Cursor.visible = false;

        _camera = camera;
        _weaponBehaviour = weaponBehaviour;
        _cursorBehaviour = cursorBehaviour;

        loseTimerBehaviour.Init(_loseTimer);

        _debugPanel.Init(debugPanelBehaviour);

        _yaAdsManager.Init(this);
        _yaAdsManager.AddReward(new YaAdsAddTimeReward());
        yaAdsBehaviour.Init(_yaAdsManager);

        _yaPurchasesManager.Init(this);
        _yaPurchasesManager.AddPurchase(new YaAddTimePurchase());
        yaPurchasesBehaviour.Init(_yaPurchasesManager);

        _level.Ended += OnLevelWin;

        _loseTimer.AddTime(999);

        _hudManager.Init(this, hudContainerBehaviour);
        _hudManager.CreateAndAddController<CoinHUD>(_coinHUDPrefab, HUDLocation.TopSideRight);

        StartGame(levelAsset, controllersContainer, 
            playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyBehaviour, playerWeaponAccuracyChangeDelay);
    }

    public void Deinit()
    {
        _yaAdsManager.Deinit();
        _yaPurchasesManager.Deinit();
        _hudManager.Deinit();

        _level.Ended -= OnLevelWin;
    }

    public void Update()
    {
        _debugPanel.Update();
        _loseTimer.Update();
        _hudManager.Update();

        switch (_state)
        {
            case GameState.MainMenu:
                break;
            case GameState.PauseMenu:
                break;
            case GameState.InProgress:
                _player.Update();
                _level.Update();
                if (CheckLoseCondition())
                {
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
        _level.DestroyTargetController(controller);
    }

    private void StartGame(LevelAsset levelAsset, Transform controllersContainer, string playerWeaponId, int playerWeaponDamage, int playerWeaponAmmo, 
        float playerWeaponReloadDelay, WeaponAccuracyBehaviour playerWeaponAccuracyBehaviour, float playerWeaponAccuracyChangeDelay)
    {
        _player.Init(this, playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyBehaviour, playerWeaponAccuracyChangeDelay,
            _weaponBehaviour, _cursorBehaviour);

        ResetGame();

        _level.Init(levelAsset, controllersContainer);
    }

    private void ResetGame()
    {
        SetState(GameState.InProgress);
        _level.Deinit();
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

    private void OnLevelWin()
    {
        SetState(GameState.Win);
        Winned?.Invoke();
    }
}
