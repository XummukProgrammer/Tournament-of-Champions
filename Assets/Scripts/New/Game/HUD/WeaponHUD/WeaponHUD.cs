// TODO: ƒобавить взаимодействие с мини-игрой

public class WeaponHUD : HUD
{
    protected override void OnInit()
    {
        base.OnInit();

        //var weapon = Game.Player.Weapon;
        //weapon.AmmoChanged += OnAmmoChanged;

        //SetAmmo(weapon.CurrentAmmo);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        //var weapon = Game.Player.Weapon;
        //weapon.AmmoChanged -= OnAmmoChanged;
    }

    private void OnAmmoChanged(int ammo)
    {
        SetAmmo(ammo);
    }

    private void SetAmmo(int ammo)
    {
        var behaviour = Behaviour.GetComponent<WeaponHUDBehaviour>();
        if (behaviour != null)
        {
            behaviour.SetAmmo(ammo);
        }
    }
}
