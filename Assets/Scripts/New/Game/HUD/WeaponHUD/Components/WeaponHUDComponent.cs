public class WeaponHUDComponent<T> : HUDComponent<T> where T : MiniGame
{
    protected override HUD CreateController(HUDManager hudManager)
    {
        return hudManager.CreateAndAddController<WeaponHUD>(Prefab, Location);
    }

    public void SetAmmo(int ammo)
    {
        (Controller as WeaponHUD).SetAmmo(ammo);
    }
}
