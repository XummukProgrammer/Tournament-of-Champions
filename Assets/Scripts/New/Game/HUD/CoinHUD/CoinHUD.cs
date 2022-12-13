public class CoinHUD : HUD
{
    protected override void OnInit() 
    {
        base.OnInit();

        var scoreAttribute = Game.Player.ScoreAttribute;
        scoreAttribute.ValueChanged += OnCoinsChange;

        SetCoins(scoreAttribute.Value);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        var scoreAttribute = Game.Player.ScoreAttribute;
        scoreAttribute.ValueChanged -= OnCoinsChange;
    }

    private void OnCoinsChange(int prevValue, int nextValue)
    {
        SetCoins(nextValue);
    }

    private void SetCoins(int coins)
    {
        var behaviour = Behaviour.GetComponent<CoinHUDBehaviour>();
        if (behaviour != null)
        {
            behaviour.SetCoins(coins);
        }
    }
}
