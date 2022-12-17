public class ShootingRangeWeaponHUDComponent : WeaponHUDComponent<ShootingRangeMiniGame>
{
    protected override void OnInit()
    {
        base.OnInit();

        var weapon = MiniGame.PlayerComponent.Weapon;
        weapon.AmmoChanged += OnAmmoChanged;

        SetAmmo(weapon.CurrentAmmo);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!MiniGame.EntryPoint.IsDisabled)
        {
            var weapon = MiniGame.PlayerComponent.Weapon;
            weapon.AmmoChanged -= OnAmmoChanged;
        }
    }

    private void OnAmmoChanged(int ammo)
    {
        SetAmmo(ammo);
    }
}
