public class ShootingRangeLoseWindowComponent : LoseWindowComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        MiniGame.Losed += OnGameLose;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        MiniGame.Losed -= OnGameLose;
    }
}
