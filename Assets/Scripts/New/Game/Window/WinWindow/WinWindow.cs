public class WinWindow : Window
{
    protected override void OnInit()
    {
        base.OnInit();

        Game.Winned += OnGameWin;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        Game.Winned -= OnGameWin;
    }

    private void OnGameWin()
    {
        OpenByAction();
    }
}
