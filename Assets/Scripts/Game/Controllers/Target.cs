using System.Collections.Generic;
using UnityEngine;

public class Target : IShotable
{
    private TargetBehaviour _behaviour;
    private HealthAttribute _healthAttribute = new HealthAttribute();
    private AudioClip[] _hitSounds;
    private AudioClip _explosionSound;
    private ParticleSystem _hitParticle;

    public TargetBehaviour Behaviour => _behaviour;

    public void Init(Transform container, TargetBehaviour prefab, Vector3 position, AudioClip[] hitSounds, AudioClip explosionSound, ParticleSystem hitParticle, int healthValue)
    {
        _behaviour = GameObject.Instantiate(prefab, position, Quaternion.identity, container);
        _behaviour.Init(this);

        _healthAttribute.GiveValue(healthValue);

        _hitSounds = hitSounds;
        _explosionSound = explosionSound;

        _hitParticle = GameObject.Instantiate(hitParticle, _behaviour.transform.position, Quaternion.identity, _behaviour.transform);
    }

    public void Destroy()
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
}
