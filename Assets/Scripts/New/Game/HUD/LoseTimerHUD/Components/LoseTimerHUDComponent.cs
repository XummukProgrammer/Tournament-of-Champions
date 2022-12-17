public class LoseTimerHUDComponent<T> : HUDComponent<T> where T : MiniGame
{
    protected override HUD CreateController(HUDManager hudManager)
    {
        return hudManager.CreateAndAddController<LoseTimerHUD>(Prefab, Location);
    }

    public void SetTimer(float timer)
    {
        (Controller as LoseTimerHUD).SetTimer(timer);
    }
}
