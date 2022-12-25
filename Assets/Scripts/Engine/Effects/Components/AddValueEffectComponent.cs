using UnityEngine;

public class AddValueEffectComponent<T> : GameComponent<T> where T : MiniGame
{
    [SerializeField] private AddValueEffectBehaviour _prefab;
    [SerializeField] private Vector2 _offset;

    protected void Play(Transform parent, int addValue)
    {
        CreateEffect(parent, addValue);
    }

    private void CreateEffect(Transform parent, int value)
    {
        var effect = MiniGame.EntryPoint.EffectsManager.CreateAndAddEffect<AddValueEffect>((AddValueEffect effect) =>
        {
            effect.SetPrefab(_prefab);
            effect.SetAddValue(value);
            effect.SetOffset(_offset);
        }, EffectContainerType.Canvas);

        effect.Play(parent);
    }
}
