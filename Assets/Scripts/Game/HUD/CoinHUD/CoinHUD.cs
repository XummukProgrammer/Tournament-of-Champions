public class CoinHUD : HUD
{
    private ScoreAttribute _scoreAttribute;

    public void SetScoreAttribute(ScoreAttribute scoreAttribute)
    {
        _scoreAttribute = scoreAttribute;
        scoreAttribute.ValueChanged += OnCoinsChange;

        SetCoins(scoreAttribute.Value);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        _scoreAttribute.ValueChanged -= OnCoinsChange;
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
