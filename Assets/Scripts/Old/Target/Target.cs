using UnityEngine;

public class Target : IController, IShotable
{
    private TargetBehaviour _prefab;
    private Vector3 _position;
    private TargetBehaviour _behaviour;

    private HealthAttribute _healthAttribute = new HealthAttribute();
    private int _healthValue;

    private ParticleSystem _hitParticlePrefab;
    private ParticleSystem _hitParticle;

    private AudioClip[] _hitSounds;
    private AudioClip _explosionSound;

    private TargetZoneScore[] _zoneScores;

    public TargetBehaviour Behaviour => _behaviour;

    public void InitWithParams(TargetBehaviour prefab, Vector3 position, 
        AudioClip[] hitSounds, AudioClip explosionSound, 
        ParticleSystem hitParticle, int healthValue, TargetZoneScore[] zoneScores)
    {
        _prefab = prefab;
        _position = position;
        _hitSounds = hitSounds;
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

        var randomHitSound = _hitSounds[Random.Range(0, _hitSounds.Length)];
        AudioSource.PlayClipAtPoint(randomHitSound, _behaviour.transform.position);

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
