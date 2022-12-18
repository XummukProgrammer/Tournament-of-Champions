public class ShootingRangeLoseTimerHUDComponent : LoseTimerHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        UpdateTimer();
    }

    public override void OnUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        SetTimer(MiniGame.LoseTimerComponent.LoseTime);
    }
}
