public class CoinHUDComponent<T> : HUDComponent<T> where T : MiniGame
{
    protected override HUD CreateController(HUDManager hudManager)
    {
        return hudManager.CreateAndAddController<CoinHUD>(Prefab, Location);
    }

    protected void SetScoreAttribute(ScoreAttribute scoreAttribute)
    {
        (Controller as CoinHUD).SetScoreAttribute(scoreAttribute);
    }
}
