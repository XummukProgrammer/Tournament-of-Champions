public class LoseWindow : Window
{
    protected override void OnInit()
    {
        base.OnInit();

        Game.Losed += OnGameLose;

        Hide();
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        Game.Losed -= OnGameLose;
    }

    private void OnGameLose()
    {
        Show();
    }
}
