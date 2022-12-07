using UnityEngine;

public class Weapon
{
    private string _id;
    private int _damage;
    private int _ammo;
    private float _reloadDelay;

    private int _currentAmmo;
    private float _currentReloadDelay;

    public string Id => _id;
    public int Damage => _damage;
    public int Ammo => _ammo;
    public int CurrentAmmo => _currentAmmo;

    public void Init(string id, int damage, int ammo, float reloadDelay)
    {
        _id = id;
        _damage = damage;
        _ammo = ammo;
        _reloadDelay = reloadDelay;
        _currentReloadDelay = 0f;

        OnReloaded();
    }

    public void Update()
    {
        if (_currentReloadDelay > 0f)
        {
            float deltaTime = Time.deltaTime;
            _currentReloadDelay -= deltaTime;

            if (_currentReloadDelay <= 0f)
            {
                _currentReloadDelay = 0f;
                OnReloaded();
            }
        }
    }

    public bool TryShot(IShotable target)
    {
        if (_currentAmmo > 0)
        {
            target.Hit(_damage);
            --_currentAmmo;

            if (_currentAmmo == 0)
            {
                StartReload();
            }

            return true;
        }
        return false;
    }

    private void StartReload()
    {
        _currentReloadDelay = _reloadDelay;
    }

    private void OnReloaded()
    {
        _currentAmmo = _ammo;
    }
}
