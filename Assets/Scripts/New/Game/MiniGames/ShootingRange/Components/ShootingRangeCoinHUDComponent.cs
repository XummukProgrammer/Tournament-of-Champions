public class ShootingRangeCoinHUDComponent : CoinHUDComponent
{
    protected override void OnInit()
    {
        base.OnInit();

        SetScoreAttribute((MiniGame as ShootingRangeMiniGame).PlayerComponent.ScoreAttribute);
    }
}
