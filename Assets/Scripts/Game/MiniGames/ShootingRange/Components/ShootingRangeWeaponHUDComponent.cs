public class ShootingRangeWeaponHUDComponent : WeaponHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnPostInit()
    {
        base.OnPostInit();

        var weapon = MiniGame.PlayerWeaponComponent;
        weapon.AmmoChanged += OnAmmoChanged;

        SetAmmo(weapon.CurrentAmmo);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            var weapon = MiniGame.PlayerWeaponComponent;
            weapon.AmmoChanged -= OnAmmoChanged;
        }
    }

    private void OnAmmoChanged(int ammo)
    {
        SetAmmo(ammo);
    }
}
