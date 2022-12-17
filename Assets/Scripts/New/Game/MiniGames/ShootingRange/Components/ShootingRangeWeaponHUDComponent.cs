public class ShootingRangeWeaponHUDComponent : WeaponHUDComponent
{
    protected override void OnInit()
    {
        base.OnInit();

        var weapon = (MiniGame as ShootingRangeMiniGame).PlayerComponent.Weapon;
        weapon.AmmoChanged += OnAmmoChanged;

        SetAmmo(weapon.CurrentAmmo);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            var weapon = (MiniGame as ShootingRangeMiniGame).PlayerComponent.Weapon;
            weapon.AmmoChanged -= OnAmmoChanged;
        }
    }

    private void OnAmmoChanged(int ammo)
    {
        SetAmmo(ammo);
    }
}
