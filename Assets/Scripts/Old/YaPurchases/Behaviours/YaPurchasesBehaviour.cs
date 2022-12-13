using UnityEngine;

public class YaPurchasesBehaviour : MonoBehaviour
{
    private YaPurchasesManager _yaPurchasesManager;

    public void Init(YaPurchasesManager yaPurchasesManager)
    {
        _yaPurchasesManager = yaPurchasesManager;
    }

    public void ProcessPurchase(string id)
    {
        _yaPurchasesManager.ProcessPurchase(id);
    }
}
