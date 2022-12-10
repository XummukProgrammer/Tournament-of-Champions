using UnityEngine;

public class YaAdsBehaviour : MonoBehaviour
{
    private YaAdsManager _yaAdsManager;

    public void Init(YaAdsManager yaAdsManager)
    {
        _yaAdsManager = yaAdsManager;
    }

    public void ShowInterstitial()
    {
        _yaAdsManager.ShowInterstitial();
    }

    public void ShowRewarded(string placement)
    {
        _yaAdsManager.ShowRewarded(placement);
    }
}
