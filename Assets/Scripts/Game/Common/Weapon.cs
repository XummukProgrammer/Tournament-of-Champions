using UnityEngine;

public class Weapon
{
    public System.Action<int> AmmoChanged;
    public System.Action<Vector2> AccuracyChanged;

    private string _id;
    private int _damage;
    private int _ammo;
    private float _reloadDelay;

    private int _currentAmmo;
    private float _currentReloadDelay;

    private Vector2[] _accuracyOffsets;
    private int _currentAccuracyOffsetIndex;
    private float _accuracyChangeDelay;
    private float _accuracyChangeTime;

    public string Id => _id;
    public int Damage => _damage;
    public int Ammo => _ammo;
    public int CurrentAmmo => _currentAmmo;
    public Vector2 CurrentAccuracyOffset => _accuracyOffsets[_currentAccuracyOffsetIndex];

    public void Init(string id, int damage, int ammo, float reloadDelay, Vector2[] accuracyOffsets, float accuracyChangeDelay)
    {
        _id = id;
        _damage = damage;
        _ammo = ammo;
        _reloadDelay = reloadDelay;
        _currentReloadDelay = 0f;
        _accuracyOffsets = accuracyOffsets;

        _currentAccuracyOffsetIndex = 0;
        _accuracyChangeDelay = accuracyChangeDelay;
        _accuracyChangeTime = _accuracyChangeDelay;

        OnReloaded();
    }

    public void Update()
    {
        float deltaTime = Time.deltaTime;

        ReloadProcess(deltaTime);
        AccuracyProcess(deltaTime);
    }

    public bool TryShot(IShotable target)
    {
        if (_currentAmmo > 0)
        {
            target.Hit(_damage);
            SetCurrentAmmo(_currentAmmo - 1);

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
        SetCurrentAmmo(_ammo);
    }

    private void SetCurrentAmmo(int ammo)
    {
        _currentAmmo = ammo;
        AmmoChanged?.Invoke(_currentAmmo);
    }

    private void ReloadProcess(float deltaTime)
    {
        if (_currentReloadDelay > 0f)
        {
            _currentReloadDelay -= deltaTime;

            if (_currentReloadDelay <= 0f)
            {
                _currentReloadDelay = 0f;
                OnReloaded();
            }
        }
    }

    private void AccuracyProcess(float deltaTime)
    {
        _accuracyChangeTime -= deltaTime;
        if (_accuracyChangeTime <= 0f)
        {
            _accuracyChangeTime = _accuracyChangeDelay;

            ++_currentAccuracyOffsetIndex;

            if (_currentAccuracyOffsetIndex >= _accuracyOffsets.Length)
            {
                _currentAccuracyOffsetIndex = 0;
            }

            AccuracyChanged?.Invoke(CurrentAccuracyOffset);
        }
    }
}
