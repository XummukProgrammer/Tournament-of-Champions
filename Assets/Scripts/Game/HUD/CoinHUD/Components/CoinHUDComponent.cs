public class CoinHUDComponent<T> : HUDComponent<CoinHUD, T> where T : MiniGame
{
    protected void SetScoreAttribute(ScoreAttribute scoreAttribute)
    {
        Controller.SetScoreAttribute(scoreAttribute);
    }
}
