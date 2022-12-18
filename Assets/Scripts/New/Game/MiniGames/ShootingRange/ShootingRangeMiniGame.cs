using UnityEngine;

public class ShootingRangeMiniGame : MiniGame
{
    public System.Action<int> LevelChanged;
    public System.Action Winned;
    public System.Action Losed;

    private bool _isLevelWin = false;

    private ShootingRangePlayerComponent _playerComponent;
    private ShootingRangePlayerWeaponComponent _playerWeaponComponent;
    private ShootingRangeLevelComponent _levelComponent;
    private ShootingRangeLoseTimerComponent _loseTimerComponent;

    public ShootingRangePlayerComponent PlayerComponent => GetPlayerComponent();
    public ShootingRangePlayerWeaponComponent PlayerWeaponComponent => GetPlayerWeaponComponent();
    public ShootingRangeLevelComponent LevelComponent => GetLevelComponent();
    public ShootingRangeLoseTimerComponent LoseTimerComponent => GetLoseTimerComponent();

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

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();
    }

    protected override void OnLoadResources()
    {
        base.OnLoadResources();
    }

    protected override void OnUnloadResources()
    {
        base.OnUnloadResources();
    }

    protected override void OnInProgress()
    {
        base.OnInProgress();

        LevelComponent.Load();
    }

    protected override void OnWin()
    {
        base.OnWin();

        Winned?.Invoke();
    }

    protected override void OnShowWinWindow()
    {
        base.OnShowWinWindow();
    }

    protected override void OnLose()
    {
        base.OnLose();

        Losed?.Invoke();
    }

    protected override void OnShowLoseWindow()
    {
        base.OnShowLoseWindow();
    }

    protected override void OnShowRewardWindow()
    {
        base.OnShowRewardWindow();
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        LevelComponent.Unload();
    }

    protected override bool IsResourcesLoaded()
    {
        return true;
    }

    protected override bool IsResourcesUnloaded()
    {
        return true;
    }

    protected override bool IsWin()
    {
        return _isLevelWin;
    }

    protected override bool IsLose()
    {
        return GetLoseTimerComponent().IsLose();
    }

    protected override bool IsWinWindowShowed()
    {
        return false;
    }

    protected override bool IsLoseWindowShowed()
    {
        return false;
    }

    protected override bool IsRewardWindowShowed()
    {
        return false;
    }

    private ShootingRangePlayerComponent GetPlayerComponent()
    {
        if (_playerComponent == null)
        {
            _playerComponent = Components.GetComponentInChildren<ShootingRangePlayerComponent>();
        }
        return _playerComponent;
    }

    private ShootingRangePlayerWeaponComponent GetPlayerWeaponComponent()
    {
        if (_playerWeaponComponent == null)
        {
            _playerWeaponComponent = Components.GetComponentInChildren<ShootingRangePlayerWeaponComponent>();
        }
        return _playerWeaponComponent;
    }

    private ShootingRangeLevelComponent GetLevelComponent()
    {
        if (_levelComponent == null)
        {
            _levelComponent = Components.GetComponentInChildren<ShootingRangeLevelComponent>();
        }
        return _levelComponent;
    }

    private ShootingRangeLoseTimerComponent GetLoseTimerComponent()
    {
        if (_loseTimerComponent == null)
        {
            _loseTimerComponent = Components.GetComponentInChildren<ShootingRangeLoseTimerComponent>();
        }
        return _loseTimerComponent;
    }

    public void OnLevelWin()
    {
        _isLevelWin = true;
    }
}
