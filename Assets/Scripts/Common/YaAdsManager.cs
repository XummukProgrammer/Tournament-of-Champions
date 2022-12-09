public class YaAdsManager
{
    private LoseTimer _loseTimer;

    public void Init(LoseTimer loseTimer)
    {
        _loseTimer = loseTimer;

        var sdk = YandexSDK.instance;
        sdk.onInterstitialShown += OnInterstitialShown;
    }

    private void OnInterstitialShown()
    {
        _loseTimer.AddTime(999);
    }
}
