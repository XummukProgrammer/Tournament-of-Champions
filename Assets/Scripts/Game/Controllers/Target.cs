using UnityEngine;

public class Target
{
    private TargetBehaviour _behaviour;

    public void Init(Transform container, TargetBehaviour prefab, Vector3 position)
    {
        _behaviour = GameObject.Instantiate(prefab, position, Quaternion.identity, container);
    }

    public void Destroy()
    {
        if (_behaviour != null)
        {
            GameObject.Destroy(_behaviour);
            _behaviour = null;
        }
    }
}
