public class ShootingRangeWinWindowComponent : WinWindowComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        MiniGame.Winned += OnGameWin;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.Winned -= OnGameWin;
    }
}
