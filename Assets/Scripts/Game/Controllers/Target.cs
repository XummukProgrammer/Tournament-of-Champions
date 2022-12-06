using System.Collections.Generic;
using UnityEngine;

public class Target
{
    private TargetBehaviour _behaviour;
    private HealthAttribute _healthAttribute = new HealthAttribute();
    private AudioClip[] _hitSounds;

    public void Init(Transform container, TargetBehaviour prefab, Vector3 position, AudioClip[] hitSounds)
    {
        _behaviour = GameObject.Instantiate(prefab, position, Quaternion.identity, container);
        _behaviour.Init(this);

        _healthAttribute.GiveValue(999);

        _hitSounds = hitSounds;
    }

    public void Destroy()
    {
        if (_behaviour != null)
        {
            GameObject.Destroy(_behaviour.gameObject);
            _behaviour = null;
        }
    }

    public void Hit()
    {
        _healthAttribute.TakeValue(1);

        var randomHitSound = _hitSounds[Random.Range(0, _hitSounds.Length)];
        AudioSource.PlayClipAtPoint(randomHitSound, _behaviour.transform.position);
    }

    public bool IsDied()
    {
        return _healthAttribute.Value == 0;
    }
}
