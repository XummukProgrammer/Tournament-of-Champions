public class CoinHUDComponent : HUDComponent
{
    protected override HUD CreateController(HUDManager hudManager)
    {
        return hudManager.CreateAndAddController<CoinHUD>(Prefab, Location);
    }
}
