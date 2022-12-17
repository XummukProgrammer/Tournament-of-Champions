public class ShootingRangeLoseTimerHUDComponent : LoseTimerHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

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
