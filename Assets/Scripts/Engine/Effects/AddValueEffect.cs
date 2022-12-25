using UnityEngine;

public class AddValueEffect : Effect
{
    private int _addValue;

    private AddValueEffectBehaviour _prefab;
    private AddValueEffectBehaviour _object;
    private Vector2 _offset;

    private bool _isDestroy;

    public void SetAddValue(int value)
    {
        _addValue = value;
    }

    public void SetPrefab(AddValueEffectBehaviour prefab)
    {
        _prefab = prefab;
    }

    public void SetOffset(Vector2 offset)
    {
        _offset = offset;
    }

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnDeinit() 
    { 
        base.OnDeinit();

        Destroy();
    }

    protected override void OnPlay() 
    { 
        base.OnPlay();

        _object = GameObject.Instantiate(_prefab, Container);
        _object.Init(_addValue);
        _object.transform.position = Parent.transform.position + new Vector3(_offset.x, _offset.y, 0);
        _object.AnimationFinished += OnAnimationFinished;
    }

    protected override void OnStop() 
    { 
        base.OnStop();

        Destroy();
    }

    public override bool IsDestroy() 
    { 
        return _isDestroy; 
    }

    private void Destroy()
    {
        _isDestroy = false;

        _object.AnimationFinished -= OnAnimationFinished;

        if (!EntryPoint.IsDisabled)
        {
            GameObject.Destroy(_object.gameObject);
        }
    }

    private void OnAnimationFinished()
    {
        Destroy();
    }
}
