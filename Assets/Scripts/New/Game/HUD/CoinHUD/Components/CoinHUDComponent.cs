public class CoinHUDComponent : HUDComponent
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
