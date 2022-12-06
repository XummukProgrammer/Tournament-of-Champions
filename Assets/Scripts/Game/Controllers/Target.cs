using UnityEngine;

public class Target
{
    private TargetBehaviour _behaviour;
    private HealthAttribute _healthAttribute = new HealthAttribute();

    public void Init(Transform container, TargetBehaviour prefab, Vector3 position)
    {
        _behaviour = GameObject.Instantiate(prefab, position, Quaternion.identity, container);
        _behaviour.Init(this);

        _healthAttribute.GiveValue(2);
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
    }

    public bool IsDied()
    {
        return _healthAttribute.Value == 0;
    }
}
