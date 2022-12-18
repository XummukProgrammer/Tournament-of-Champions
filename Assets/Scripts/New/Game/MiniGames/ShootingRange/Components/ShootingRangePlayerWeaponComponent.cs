using UnityEngine;

public class ShootingRangePlayerWeaponComponent : GameComponent<ShootingRangeMiniGame>
{
    public System.Action<int> AmmoChanged;
    public System.Action<Vector2> AccuracyChanged;

    [SerializeField] private WeaponAsset _asset;

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

    protected override void OnInit()
    {
        base.OnInit();

        _id = _asset.Id;
        _damage = _asset.Damage;
        _ammo = _asset.Ammo;
        _reloadDelay = _asset.ReloadDelay;
        _currentReloadDelay = 0f;

        _currentAccuracyOffsetIndex = 0;
        _accuracyChangeDelay = _asset.AccuracyChangeDelay;
        _accuracyChangeTime = _accuracyChangeDelay;
        _accuracyOffsets = _asset.AccuracyBehaviour.GetPoints();

        OnReloaded();
    }

    public override void OnUpdate()
    {
        float deltaTime = Time.deltaTime;

        ReloadProcess(deltaTime);
        AccuracyProcess(deltaTime);
    }

    public bool TryShot()
    {
        if (_currentAmmo > 0)
        {
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
