public class ShootingRangeLoseTimerHUDComponent : LoseTimerHUDComponent
{
    protected override void OnInit()
    {
        base.OnInit();

        UpdateTimer();
    }

    public void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        SetTimer((MiniGame as ShootingRangeMiniGame).LoseTimerComponent.LoseTime);
    }
}
