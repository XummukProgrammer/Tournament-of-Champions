using UnityEngine;

public class WeaponHUDBehaviour : HUDBehaviour
{
    [SerializeField] private TMPro.TMP_Text _ammo;

    public void SetAmmo(int ammo)
    {
        _ammo.text = ammo.ToString();
    }
}
