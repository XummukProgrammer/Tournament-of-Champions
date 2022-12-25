using UnityEngine;

public class ShootingRangeLevelComponent : GameComponent<ShootingRangeMiniGame>
{
    public System.Action Passed;

    [SerializeField] private LevelAsset _asset;

    private Level _level = new Level();

    public Level Level => _level;

    public void Load()
    {
        _level.Init(_asset, MiniGame.LoseTimerComponent);

        _level.Ended += OnLevelWin;
    }

    public void Unload()
    {
        _level.Ended -= OnLevelWin;
        _level.Deinit();
    }

    public void DestroyTarget(Target controller)
    {
        _level.DestroyTargetController(controller);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        _level.Update();
    }

    private void OnLevelWin()
    {
        MiniGame.OnLevelWin();
    }
}
