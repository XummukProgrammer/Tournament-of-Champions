using UnityEngine;

public class ParticleEffect : Effect
{
    private ParticleSystem _particlePrefab;
    private ParticleSystem _particleObject;

    private bool _isDestroy;

    public void SetParticlePrefab(ParticleSystem particlePrefab)
    {
        _particlePrefab = particlePrefab;
    }

    public void Destroy()
    {
        _isDestroy = true;
    }

    protected override void OnInit()
    {
        base.OnInit();

        _particleObject = GameObject.Instantiate(_particlePrefab, Container);
        _isDestroy = false;
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        if (!EntryPoint.IsDisabled)
        {
            GameObject.Destroy(_particleObject.gameObject);
        }
    }

    protected override void OnPlay()
    {
        base.OnPlay();

        _particleObject.transform.position = Parent.position;
        _particleObject.Play();
    }

    protected override void OnStop()
    {
        base.OnStop();

        _particleObject.Stop();
    }

    public override bool IsDestroy()
    {
        return _isDestroy;
    }
}
