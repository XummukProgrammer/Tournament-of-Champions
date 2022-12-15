using System.Collections.Generic;

public class YaAdsManager
{
    private List<IYaAdsReward> _rewards = new List<IYaAdsReward>();

    private YandexSDK _sdk;
    private EntryPoint _entryPoint;

    public void Init(EntryPoint entryPoint)
    {
        _entryPoint = entryPoint;

        _sdk = YandexSDK.instance;
        _sdk.onInterstitialShown += OnInterstitialShown;
        _sdk.onInterstitialFailed += OnInterstitialFailed;
        _sdk.onRewardedAdOpened += OnRewardedAdOpened;
        _sdk.onRewardedAdReward += OnRewardedAdReward;
        _sdk.onRewardedAdClosed += OnRewardedAdClosed;
    }

    public void Deinit()
    {
        _sdk.onInterstitialShown -= OnInterstitialShown;
        _sdk.onInterstitialFailed -= OnInterstitialFailed;
        _sdk.onRewardedAdOpened -= OnRewardedAdOpened;
        _sdk.onRewardedAdReward -= OnRewardedAdReward;
        _sdk.onRewardedAdClosed -= OnRewardedAdClosed;
    }

    private void OnInterstitialShown()
    {
    }

    private void OnInterstitialFailed(string error)
    {
    }

    private void OnRewardedAdOpened(int placement)
    {
    }

    private void OnRewardedAdReward(string placement)
    {
        foreach (var reward in _rewards)
        {
            if (reward.GetPlacement() == placement)
            {
                reward.Receive(_entryPoint);
            }
        }
    }

    private void OnRewardedAdClosed(int placement)
    {
    }

    public void AddReward(IYaAdsReward reward)
    {
        _rewards.Add(reward);
    }

    public void ShowInterstitial()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        _sdk.ShowInterstitial();
#endif
    }

    public void ShowRewarded(string placement)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        _sdk.ShowRewarded(placement);
#else
        OnRewardedAdReward(placement);
#endif
    }
}
