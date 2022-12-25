using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager
{
    public delegate void PreInitDelegate<T>(T effect);

    private EntryPoint _entryPoint;
    private Transform _container;
    private List<Effect> _effects = new List<Effect>();
    private List<Effect> _destroyEffects = new List<Effect>();

    public void Init(EntryPoint entryPoint, Transform container)
    {
        _entryPoint = entryPoint;
        _container = container;
    }

    public void Deinit()
    {
        foreach (var effect in _effects)
        {
            effect.Deinit();
        }

        _effects.Clear();
    }

    public void Update()
    {
        foreach (var effect in _effects)
        {
            if (effect.IsDestroy())
            {
                _destroyEffects.Add(effect);
            }
        }

        foreach (var effect in _destroyEffects)
        {
            effect.Deinit();
            _effects.Remove(effect);
        }

        _destroyEffects.Clear();
    }

    public T CreateAndAddEffect<T>(PreInitDelegate<T> preInitDelegate) where T : Effect
    {
        var effect = Activator.CreateInstance<T>();
        preInitDelegate?.Invoke(effect);
        effect.Init(_entryPoint, _container);
        _effects.Add(effect);
        return effect;
    }
}
