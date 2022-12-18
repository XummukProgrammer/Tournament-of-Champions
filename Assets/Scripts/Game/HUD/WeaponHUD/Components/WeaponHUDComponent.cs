public class WeaponHUDComponent<T> : HUDComponent<WeaponHUD, T> where T : MiniGame
{
    public void SetAmmo(int ammo)
    {
        Controller.SetAmmo(ammo);
    }
}
