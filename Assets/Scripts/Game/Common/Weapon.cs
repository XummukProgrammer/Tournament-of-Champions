public class Weapon
{
    private string _id;
    private int _damage;
    private int _ammo;

    private int _currentAmmo;

    public string Id => _id;
    public int Damage => _damage;
    public int Ammo => _ammo;
    public int CurrentAmmo => _currentAmmo;

    public void Init(string id, int damage, int ammo)
    {
        _id = id;
        _damage = damage;
        _ammo = ammo;

        OnReloaded();
    }

    public bool TryShot(IShotable target)
    {
        if (_currentAmmo > 0)
        {
            target.Hit(_damage);
            --_currentAmmo;
            return true;
        }
        return false;
    }

    private void OnReloaded()
    {
        _currentAmmo = _ammo;
    }
}
