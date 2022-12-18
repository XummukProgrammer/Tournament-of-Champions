using UnityEngine;

public class Target : IController
{
    private string _id;

    private TargetBehaviour _prefab;
    private Vector3 _position;
    private TargetBehaviour _behaviour;

    private HealthAttribute _healthAttribute = new HealthAttribute();
    private int _healthValue;

    private ParticleSystem _hitParticlePrefab;
    private ParticleSystem _hitParticle;

    private AudioClip _explosionSound;

    private TargetZoneScore[] _zoneScores;

    public string Id => _id;
    public TargetBehaviour Behaviour => _behaviour;

    public void InitWithParams(string id, TargetBehaviour prefab, Vector3 position, 
        AudioClip explosionSound, 
        ParticleSystem hitParticle, int healthValue, TargetZoneScore[] zoneScores)
    {
        _id = id;
        _prefab = prefab;
        _position = position;
        _explosionSound = explosionSound;
        _zoneScores = zoneScores;
        _hitParticlePrefab = hitParticle;
        _healthValue = healthValue;
    }

    public void Init()
    {
        _behaviour = GameObject.Instantiate(_prefab);
        _behaviour.transform.position = _position;
        _behaviour.Init(this);

        _healthAttribute.GiveValue(_healthValue);

        _hitParticle = GameObject.Instantiate(_hitParticlePrefab, _behaviour.transform.position, Quaternion.identity, _behaviour.transform);
    }

    public void Deinit()
    {
        if (_behaviour != null)
        {
            GameObject.Destroy(_behaviour.gameObject);
            _behaviour = null;
        }
    }

    public void Hit(int damage)
    {
        _healthAttribute.TakeValue(damage);

        if (IsDied())
        {
            AudioSource.PlayClipAtPoint(_explosionSound, _behaviour.transform.position);
        }

        _hitParticle.Play();
    }

    public bool IsDied()
    {
        return _healthAttribute.Value == 0;
    }

    public int GetScoreWithZone(string zoneId)
    {
        foreach (var zoneScore in _zoneScores)
        {
            if (zoneScore.Id == zoneId)
            {
                return zoneScore.Score;
            }
        }
        return 0;
    }
}
