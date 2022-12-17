public class WeaponHUD : HUD
{
    public void SetAmmo(int ammo)
    {
        var behaviour = Behaviour.GetComponent<WeaponHUDBehaviour>();
        if (behaviour != null)
        {
            behaviour.SetAmmo(ammo);
        }
    }
}
