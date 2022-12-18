public class LoseTimerHUDComponent<T> : HUDComponent<LoseTimerHUD, T> where T : MiniGame
{
    public void SetTimer(float timer)
    {
        Controller.SetTimer(timer);
    }
}
