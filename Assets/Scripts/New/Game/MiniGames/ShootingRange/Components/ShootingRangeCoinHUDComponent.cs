public class ShootingRangeCoinHUDComponent : CoinHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        SetScoreAttribute(MiniGame.PlayerComponent.ScoreAttribute);
    }
}
