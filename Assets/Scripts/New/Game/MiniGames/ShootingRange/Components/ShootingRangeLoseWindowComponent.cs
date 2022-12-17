public class ShootingRangeLoseWindowComponent : LoseWindowComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        MiniGame.Losed += OnGameLose;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.Losed -= OnGameLose;
    }
}
