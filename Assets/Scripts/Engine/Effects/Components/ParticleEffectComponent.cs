using UnityEngine;

public class ParticleEffectComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private ParticleSystem _prefab;

    private ParticleEffect _particleEffect;

    protected override void OnInit()
    {
        base.OnInit();

        _particleEffect = MiniGame.EntryPoint.EffectsManager.CreateAndAddEffect<ParticleEffect>((ParticleEffect effect) =>
        {
            effect.SetParticlePrefab(_prefab);
        }, EffectContainerType.World);
    }

    protected override void OnDeinit()
    {
        base.OnDeinit();

        _particleEffect.Destroy();
    }

    public void Play(Transform parent)
    {
        _particleEffect.Play(parent);
    }

    public void Stop()
    {
        _particleEffect.Stop();
    }

    protected void Destroy()
    {
        _particleEffect.Destroy();
    }
}
