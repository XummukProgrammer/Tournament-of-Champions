using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _name;
    [SerializeField] private TMPro.TMP_Text _ammo;

    public void Init(Weapon weapon)
    {
        _name.text = weapon.Id;

        weapon.AmmoChanged += OnWeaponAmmoChanged;

        OnWeaponAmmoChanged(weapon.Ammo);
    }

    private void OnWeaponAmmoChanged(int value)
    {
        _ammo.text = value.ToString();
    }
}