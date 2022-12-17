public class ShootingRangeWinWindowComponent : WinWindowComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        MiniGame.Winned += OnGameWin;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.Winned -= OnGameWin;
    }
}
