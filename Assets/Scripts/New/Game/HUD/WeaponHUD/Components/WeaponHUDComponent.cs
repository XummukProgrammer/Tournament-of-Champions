using UnityEngine;

public class WeaponHUDComponent : HUDComponent
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
