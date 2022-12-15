using UnityEngine;

public class ShootingRangeMiniGame : MiniGame
{
    public System.Action<int> LevelChanged;
    public System.Action Winned;
    public System.Action Losed;

    private Level _level = new Level();
    private LoseTimer _loseTimer = new LoseTimer();

    private bool _isWin = false;
    private bool _isLose = false;

    public Level Level => _level;
    public LoseTimer LoseTimer => _loseTimer;

    public void DestroyTarget(Target controller)
    {
        _level.DestroyTargetController(controller);
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

    protected override void OnInit() 
    {
        base.OnInit();
    }

    protected override void OnDeinit() 
    {
        base.OnDeinit();
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        _level.Update();
        _loseTimer.Update();
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

        //_player.Init(this, playerWeaponId, playerWeaponDamage, playerWeaponAmmo, playerWeaponReloadDelay, playerWeaponAccuracyBehaviour, playerWeaponAccuracyChangeDelay,
        //    _cursorBehaviour);

        //_level.Init(levelAsset, controllersContainer);

        _level.Ended += OnLevelWin;

        _loseTimer.AddTime(999);
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

        _level.Ended -= OnLevelWin;
        _level.Deinit();
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
        return _isWin; 
    }

    protected override bool IsLose() 
    {
        return _loseTimer.IsLose();
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

    private void OnLevelWin()
    {
        _isWin = true;
    }
}
