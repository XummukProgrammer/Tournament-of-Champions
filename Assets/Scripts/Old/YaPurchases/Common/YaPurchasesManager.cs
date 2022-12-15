using System.Collections.Generic;

public class YaPurchasesManager
{
    private List<IYaPurchase> _purchases = new List<IYaPurchase>();

    private YandexSDK _sdk;
    private EntryPoint _entryPoint;

    public void Init(EntryPoint entryPoint)
    {
        _entryPoint = entryPoint;

        _sdk = YandexSDK.instance;
        _sdk.onPurchaseSuccess += OnPurchaseSuccess;
        _sdk.onPurchaseFailed += OnPurchaseFailed;

#if !UNITY_EDITOR && UNITY_WEBGL
        _sdk.InitializePurchases();
#endif
    }

    public void Deinit()
    {
        _sdk.onPurchaseSuccess -= OnPurchaseSuccess;
        _sdk.onPurchaseFailed -= OnPurchaseFailed;
    }

    private void OnPurchaseSuccess(string id)
    {
        foreach (var purchase in _purchases)
        {
            if (purchase.GetId() == id)
            {
                purchase.Receive(_entryPoint);
            }
        }
    }

    private void OnPurchaseFailed(string id)
    {
    }

    public void ProcessPurchase(string id)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        _sdk.ProcessPurchase(id);
#else
        OnPurchaseSuccess(id);
#endif
    }

    public void AddPurchase(IYaPurchase purchase)
    {
        _purchases.Add(purchase);
    }
}
