public class ShootingRangeCoinHUDComponent : CoinHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        SetScoreAttribute(MiniGame.PlayerComponent.ScoreAttribute);
    }
}
