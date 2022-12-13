using UnityEngine;

public class CoinHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _coins;

    public void SetCoins(int coins)
    {
        _coins.text = coins.ToString();
    }
}
